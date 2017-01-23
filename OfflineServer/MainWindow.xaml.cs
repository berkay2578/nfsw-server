using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using NHibernate;
using OfflineServer.Data;
using OfflineServer.Servers.Database;
using OfflineServer.Servers.Database.Entities;
using OfflineServer.Servers.Database.Management;
using OfflineServer.Servers.IPC;
using System;
using System.ComponentModel;
using System.Data.SQLite;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using static OfflineServer.Servers.IPC.AddonManagerTalk;

namespace OfflineServer
{
    public partial class MainWindow : MetroWindow
    {
        private DispatcherTimer RandomPersonaInfo = new DispatcherTimer();
        private CustomDialog carDialog;
        private Process nfsWorldProcess;
        public Access Access { get; set; }
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public MainWindow()
        {
            log.Debug("MawinWindow loading...");

            #region Culture Independency
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
            XmlLanguage xMarkup = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.Name);
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(xMarkup));
            FrameworkContentElement.LanguageProperty.OverrideMetadata(typeof(System.Windows.Documents.TextElement), new FrameworkPropertyMetadata(xMarkup));
            log.Info("Culture independency achieved.");
            #endregion

            vCreateDb();

            Access = new Access();

            log.Info("Starting session.");
            Access.CurrentSession.startSession();

            InitializeComponent();
            SetupComponents();

            Access.addonManagerTalk = new AddonManagerTalk();

            Access.mainWindow = this;
            log.Debug("Access.mainWindow set.");
        }

        private void vCreateDb()
        {
            if (!DataEx.db_ServerExists)
            {
                log.Warn("Database doesn't exist!");
                if (!Directory.Exists(DataEx.dir_Database)) Directory.CreateDirectory(DataEx.dir_Database);

                log.Info("Creating database.");
                ISessionFactory sessionFactory = SessionManager.createDatabase();

                log.Info("Setting minimum pkPersonaId to 100.");
                using (var sqliteConnection = new SQLiteConnection("Data Source=\"" + DataEx.db_Server + "\";Version=3;"))
                {
                    sqliteConnection.Open();
                    SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO sqlite_sequence (name, seq) VALUES ('Personas', 99)", sqliteConnection);
                    insertSQL.ExecuteNonQuery();
                    sqliteConnection.Close();
                }

                log.Info("Inserting filler entries.");
                using (var session = sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    UserEntity userEntity = new UserEntity();
                    userEntity.defaultPersonaIdx = 0;

                    for (int i = 0; i <= 20; i++)
                    {
                        PersonaEntity personaEntity = new PersonaEntity();
                        personaEntity.boost = 7331;
                        personaEntity.cash = 1337;
                        personaEntity.currentCarIndex = 0;
                        personaEntity.iconIndex = 27;
                        personaEntity.level = 60;
                        personaEntity.motto = "test";
                        personaEntity.name = "DEBUG Id" + (i + 100);
                        personaEntity.percentageOfLevelCompletion = 100;
                        personaEntity.rating = 8752;
                        personaEntity.reputationInLevel = 9999;
                        personaEntity.reputationInTotal = 99999999;
                        personaEntity.score = 2578;

                        CarEntity carEntity = new CarEntity();
                        carEntity.baseCarId = 1816139026L;
                        carEntity.durability = 100;
                        carEntity.heatLevel = 6;
                        carEntity.carId = 1;
                        carEntity.paints = "<Paints/>";
                        carEntity.performanceParts = "<PerformanceParts/>";
                        carEntity.physicsProfileHash = 4123572107L;
                        carEntity.raceClass = CarClass.A;
                        carEntity.rating = 750;
                        carEntity.resalePrice = 123456789;
                        carEntity.skillModParts = "<SkillModParts/>";
                        carEntity.vinyls = "<Vinyls/>";
                        carEntity.visualParts = "<VisualParts/>";

                        personaEntity.addCar(carEntity);
                        session.Save(personaEntity);
                    }
                    session.Save(userEntity);
                    transaction.Commit();
                    log.Info("Database actions finalized.");
                }
            }
            else { log.Info("Database already exists, skipping creation."); }
        }

        private void SetupComponents()
        {
            #region FlipViewPersona
            FlipViewPersonaImage.HideControlButtons();

            Image[] aFlipViewAvatarArray = new Image[28];
            for (int i = 0; i < 28; i++)
            {
                Image avatarImage = new Image()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Stretch = Stretch.UniformToFill,
                    RenderSize = new Size(126, 128),
                    Source = (ImageSource)BitmapFrame.Create(new Uri("pack://application:,,,/OfflineServer;component/images/NFSW_Avatars/Avatar_" + i.ToString() + ".png", UriKind.Absolute))
                };
                aFlipViewAvatarArray[i] = avatarImage;
            }
            FlipViewPersonaImage.ItemsSource = aFlipViewAvatarArray;

            Binding indexBind = new Binding()
            {
                Path = new PropertyPath("ActivePersona.IconIndex"),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                Mode = BindingMode.TwoWay,
                Delay = 1000,
                Source = Access.CurrentSession
            };
            BindingOperations.SetBinding(FlipViewPersonaImage, FlipView.SelectedIndexProperty, indexBind);
            #endregion

            #region MetroTile -> Random Persona Info
            tRandomPersonaInfo_Tick(null, null);
            RandomPersonaInfo.Tick += new EventHandler(tRandomPersonaInfo_Tick);
            RandomPersonaInfo.Interval = new TimeSpan(0, 0, 10);
            RandomPersonaInfo.Start();
            #endregion

            #region carDialog
            Binding lBindSelect = new Binding()
            {
                Path = new PropertyPath("language.Select"),
                Mode = BindingMode.OneWay,
                Source = Access.dataAccess.appSettings.uiSettings
            };
            Binding lBindCancel = new Binding()
            {
                Path = new PropertyPath("language.Cancel"),
                Mode = BindingMode.OneWay,
                Source = Access.dataAccess.appSettings.uiSettings
            };
            Binding lBindSelectCar = new Binding()
            {
                Path = new PropertyPath("language.AddACarText"),
                Mode = BindingMode.OneWay,
                Source = Access.dataAccess.appSettings.uiSettings
            };

            ComboBox carComboBox = new ComboBox();
            carComboBox.SetValue(Canvas.LeftProperty, 5d);
            carComboBox.SetValue(Canvas.TopProperty, 20d);
            carComboBox.Width = 297d;
            carComboBox.ItemsSource = CarDefinitions.physicsProfileHashNormal.Values;
            carComboBox.SelectedIndex = 0;

            Button selectButton = new Button();
            selectButton.SetValue(Canvas.LeftProperty, 148d);
            selectButton.SetValue(Canvas.TopProperty, 54d);
            selectButton.Width = 80d;
            selectButton.Click += (object sender, RoutedEventArgs routedEventArgs) =>
            {
                selectButton.IsEnabled = false;

                CarEntity carEntity = new CarEntity();
                carEntity.baseCarId = CarDefinitions.baseCarId.FirstOrDefault(key => key.Value == carComboBox.SelectedItem.ToString()).Key;
                carEntity.carId = Access.CurrentSession.ActivePersona.Cars.Last().CarId + 1;
                carEntity.durability = 100;
                carEntity.heatLevel = 1;
                carEntity.paints = "<Paints/>";
                carEntity.performanceParts = "<PerformanceParts/>";
                carEntity.physicsProfileHash = CarDefinitions.physicsProfileHashNormal.FirstOrDefault(key => key.Value == carComboBox.SelectedItem.ToString()).Key;
                carEntity.raceClass = CarClass.E;
                carEntity.rating = 123;
                carEntity.resalePrice = 0;
                carEntity.skillModParts = "<SkillModParts/>";
                carEntity.vinyls = "<Vinyls/>";
                carEntity.visualParts = "<VisualParts/>";
                PersonaManagement.addCar(carEntity);
                DialogManager.HideMetroDialogAsync(this, carDialog);
            };

            Button cancelButton = new Button();
            cancelButton.SetValue(Canvas.LeftProperty, 233d);
            cancelButton.SetValue(Canvas.TopProperty, 54d);
            cancelButton.Width = 70d;
            cancelButton.Click += (object sender, RoutedEventArgs routedEventArgs) =>
            {
                DialogManager.HideMetroDialogAsync(this, carDialog);
            };

            Canvas canvas = new Canvas();
            canvas.Children.Add(carComboBox);
            canvas.Children.Add(selectButton);
            canvas.Children.Add(cancelButton);

            carDialog = new CustomDialog();
            carDialog.Height = 200d;
            carDialog.Content = canvas;

            // internationalization
            BindingOperations.SetBinding(carDialog, CustomDialog.TitleProperty, lBindSelectCar);
            BindingOperations.SetBinding(selectButton, Button.ContentProperty, lBindSelect);
            BindingOperations.SetBinding(cancelButton, Button.ContentProperty, lBindCancel);
            #endregion
        }

        private void tRandomPersonaInfo_Tick(object sender, EventArgs e)
        {
            DockPanel dNewInfoContent = Access.CurrentSession.Engine.Achievements.generateNewAchievement();
            metrotileRandomPersonaInfo.Content = dNewInfoContent;
        }

        private async void buttonStartServer_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // not implemented for internationalization on purpose

            if (Access.sHttp == null)
                Access.sHttp = new Servers.Http.HttpServer();
            if (Access.sXmpp == null)
                Access.sXmpp = new Servers.Xmpp.BasicXmppServer(true);

            #region NFS World Path checking
            if (String.IsNullOrWhiteSpace(Access.dataAccess.appSettings.nfsw_exe))
            {
                RegistryKey regBaseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                RegistryKey nfswKey = regBaseKey.OpenSubKey(@"Software\Electronic Arts\Need For Speed World\", false);

                if (nfswKey == null)
                {
                    regBaseKey.Dispose();
                    nfswKey.Dispose();
                    regBaseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                    nfswKey = regBaseKey.OpenSubKey(@"Software\Electronic Arts\Need For Speed World\", false);
                }

                if (nfswKey == null)
                {
                    OpenFileDialog findNfswDialog = new OpenFileDialog()
                    {
                        CheckFileExists = true,
                        CheckPathExists = true,
                        DefaultExt = ".exe",
                        AddExtension = true,
                        Multiselect = false,
                        Title = "Please select nfsw.exe"
                    };
                    if (findNfswDialog.ShowDialog() == true)
                    {
                        String selectedExe = findNfswDialog.FileName;
                        if (File.Exists(selectedExe))
                        {
                            Access.dataAccess.appSettings.nfsw_exe = selectedExe;
                            Access.dataAccess.appSettings.saveInstance();
                        }
                    }
                }
                else
                {
                    Object installDir = nfswKey.GetValue("GameInstallDir");
                    if (installDir != null)
                    {
                        Access.dataAccess.appSettings.nfsw_exe = Path.Combine(installDir.ToString(), "Data", "nfsw.exe");
                        Access.dataAccess.appSettings.saveInstance();
                    }

                }
                regBaseKey.Dispose();
                nfswKey.Dispose();
            }
            #endregion

            if (String.IsNullOrWhiteSpace(Access.dataAccess.appSettings.nfsw_exe))
            {
                await this.ShowMessageAsync(Access.dataAccess.appSettings.uiSettings.language.InformUserError,
                                            "NFSW.exe wasn't located.", MessageDialogStyle.Affirmative);
                return;
            }

            try
            {
                nfsWorldProcess = new Process();
                nfsWorldProcess.StartInfo.FileName = Access.dataAccess.appSettings.nfsw_exe;
                nfsWorldProcess.StartInfo.Arguments = String.Format("EU http://127.0.0.1:{0}/ a 1", Access.sHttp.port);
                nfsWorldProcess.EnableRaisingEvents = true;
                nfsWorldProcess.Exited += (object o, EventArgs eArgs) =>
                {
                    if (Access.sXmpp != null)
                        Access.sXmpp.shutdown();
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        NFSWRunningOverlay.Visibility = Visibility.Collapsed;
                        ActualNFSWRunningOverlay.Visibility = Visibility.Collapsed;
                    }));
                    Access.CurrentSession.ActivePersona.TimePlayed = "";
                    nfsWorldProcess.Dispose();
                };
                if (nfsWorldProcess.Start())
                {
                    NFSWRunningOverlay.Visibility = Visibility.Visible;
                    await this.ShowMessageAsync("Servers are up and running!", "NFS: World should launch in a moment.", MessageDialogStyle.Affirmative);
                    ActualNFSWRunningOverlay.Visibility = Visibility.Visible;
                }
                else
                {
                    nfsWorldProcess.Dispose();
                    throw new Exception("NFS: World couldn't be started, maybe it's already running?");
                }
            }
            catch (Exception ex)
            {
                log.Error("Exception occured while trying to start " + Access.dataAccess.appSettings.nfsw_exe, ex);
                await this.ShowMessageAsync(Access.dataAccess.appSettings.uiSettings.language.InformUserError,
                                "An exception occured while trying to start NFS: World. The exception was logged.", MessageDialogStyle.Affirmative);
            }

        }

        private void Button_ClickHandler(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "buttonOpenBasicPersonaInfo":
                    flyoutBasicPersonaInfo.IsOpen = !flyoutBasicPersonaInfo.IsOpen;
                    break;
                case "buttonOpenDetailedPersonaInfo":
                    flyoutDetailedPersonaInfo.IsOpen = !flyoutDetailedPersonaInfo.IsOpen;
                    break;
                case "buttonOpenPersonaList":
                    flyoutPersonaList.IsOpen = !flyoutPersonaList.IsOpen;
                    break;
                case "buttonUpdatePersonaInfoTile":
                    RandomPersonaInfo.Stop();
                    tRandomPersonaInfo_Tick(null, null);
                    RandomPersonaInfo.Start();
                    break;
                case "buttonPaints":
                case "buttonPerformanceParts":
                case "buttonSkillModParts":
                case "buttonVinyls":
                case "buttonVisualParts":
                    tbGaragePartInfo.SetBinding(MVVMSyntax._TextProperty,
                        new Binding()
                        {
                            Converter = new STEditConverter(this),
                            Path = new PropertyPath("ActivePersona.SelectedCar." + ((sender as Button).Name).Remove(0, 6)),
                            UpdateSourceTrigger = UpdateSourceTrigger.LostFocus,
                            Mode = BindingMode.TwoWay,
                            Source = Access.CurrentSession
                        });
                    flyoutGaragePartInfo.IsOpen = !flyoutGaragePartInfo.IsOpen;
                    break;
                case "buttonAddCar":
                    this.ShowMetroDialogAsync(carDialog, new MetroDialogSettings() { AnimateHide = true, AnimateShow = true });
                    break;
                case "buttonRemoveCar":
                    if (listCar.Items.Count > 1)
                    {
                        Int32 selectedItemIndex = listCar.SelectedIndex;
                        if (selectedItemIndex != -1)
                        {
                            PersonaManagement.removeCar((Car)listCar.Items[selectedItemIndex]);
                            listCar.SelectedIndex = Math.Min(selectedItemIndex, listCar.Items.Count - 1);
                        }
                        else
                        {
                            new ToolTip() { Content = Access.dataAccess.appSettings.uiSettings.language.RemoveCarNoSelectedCarError, StaysOpen = false, IsOpen = true };
                        }
                    }
                    else
                    {
                        new ToolTip() { Content = Access.dataAccess.appSettings.uiSettings.language.RemoveCarLastCarError, StaysOpen = false, IsOpen = true };
                    }
                    break;
                case "buttonSettings":
                    flyoutSettings.IsOpen = !flyoutSettings.IsOpen;
                    break;
                case "buttonAddonManager":
                    if (!AddonManagerTalk.isAddonManagerRunning && AddonManagerTalk.isWaitingForClient)
                    {
                        String addonManagerLocation = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "AddonManager.exe");
                        if (!File.Exists(addonManagerLocation))
                        {
                            this.ShowMessageAsync(Access.dataAccess.appSettings.uiSettings.language.InformUserInformation,
                                Access.dataAccess.appSettings.uiSettings.language.AddonManagerNotFoundError);
                            return;
                        }

                        Access.addonManagerTalk.initialize();
                        String args = String.Format("/catalogs '{0}' /baskets '{1}' /accents '{2}' /themes '{3}' /languages '{4}' /memorypatches '{5}' /logs '{6}' /offlineServer {7}",
                            Path.GetFullPath(DataEx.dir_HttpServerCatalogs),
                            Path.GetFullPath(DataEx.dir_HttpServerBaskets),
                            Path.GetFullPath(DataEx.dir_Accents),
                            Path.GetFullPath(DataEx.dir_Themes),
                            Path.GetFullPath(DataEx.dir_Languages),
                            Path.GetFullPath(DataEx.dir_MemoryPatches),
                            Path.GetFullPath(DataEx.dir_Logs),
                            Access.addonManagerTalk.port);
                        Process.Start(addonManagerLocation, args);
                    }
                    break;
            }
        }
        public class STEditConverter : IValueConverter
        {
            private MainWindow _Window;
            public STEditConverter(MainWindow dlWindow)
            {
                _Window = dlWindow;
            }

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return value.ToString();
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                try
                {
                    return System.Xml.Linq.XElement.Parse(value.ToString());
                }
                catch (Exception ex)
                {
                    Clipboard.SetText(value.ToString(), TextDataFormat.UnicodeText);
                    BindingOperations.ClearBinding(_Window.tbGaragePartInfo, MVVMSyntax._TextProperty);
                    _Window.flyoutGaragePartInfo.IsOpen = false;
                    MessageBox.Show(String.Format("{0}\r\n\r\nNote: Your input is copied to your clipboard.", ex.Message), "ERROR: Not valid input", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
        }

        #region Persona flyout events
        private void datagridPersonaList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Persona mSelectedPersona = datagridPersonaList.SelectedItem as Persona;
            Access.CurrentSession.ActivePersona = mSelectedPersona;
        }

        private void flyoutBasicPersonaInfo_IsOpenChanged(object sender, RoutedEventArgs e)
        {
            if (!flyoutBasicPersonaInfo.IsOpen)
            {
                textboxPersonaName.Text = textboxPersonaName.Text.Trim();
                Int32 iPersonaIndex = Access.CurrentSession.PersonaList.IndexOf(Access.CurrentSession.PersonaList.First<Persona>(sPersona => sPersona.Id == Access.CurrentSession.ActivePersona.Id));
                Access.CurrentSession.PersonaList[iPersonaIndex] = Access.CurrentSession.ActivePersona;
            }
        }
        #endregion

        #region FlipViewPersonaImage events
        private void FlipViewPersonaImage_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as FlipView).ShowControlButtons();
        }

        private void FlipViewPersonaImage_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as FlipView).HideControlButtons();
        }
        #endregion

        #region Theme error proofing
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Access.dataAccess.appSettings.uiSettings.style.applyNewStyle();
            FlipViewPersonaImage.IsNavigationEnabled = true;
        }
        #endregion

        #region Ensuring no empty persona names
        private void textboxPersonaName_LostFocus(object sender, RoutedEventArgs e)
        {
            textboxPersonaName.Text = textboxPersonaName.Text.Trim();
            if (textboxPersonaName.Text.Length < 1)
            {
                informUser(Access.dataAccess.appSettings.uiSettings.language.InformUserWarning,
                            Access.dataAccess.appSettings.uiSettings.language.ErrorEmptyPersonaName);
                if (textboxPersonaName.CanUndo)
                {
                    do
                    {
                        textboxPersonaName.Undo();
                    } while (textboxPersonaName.Text.Trim().Length < 1);
                }
                else
                {
                    textboxPersonaName.Text = "CHANGE ME";
                }
            }
        }
        #endregion

        #region Functions/Voids to remove if not needed later
        public async void informUser(String messageTitle, String messageText)
        {
            await this.ShowMessageAsync(messageTitle, messageText, MessageDialogStyle.Affirmative);
        }
        #endregion

        private void MetroWindow_Closing(object sender, CancelEventArgs e)
        {
            log.Info("Shutting down offline server.");

            if (AddonManagerTalk.isAddonManagerRunning || AddonManagerTalk.isWaitingForClient)
            {
                log.Info("Closing existing AddonManager IPC Talk.");
                Access.addonManagerTalk.notify(IPCPacketType.offlineServerClosing);
                Access.addonManagerTalk.shutdown();
            }

            if (Access.sHttp != null && Access.sXmpp != null)
            {
                // https://github.com/foxglovesec/Potato/blob/master/source/NHttp/NHttp/HttpServer.cs#L261
                Access.sHttp.nServer.Stop();
                Access.sHttp.nServer.Dispose();
                log.Info("Shutdown of HttpServer has been completed.");

                Access.sXmpp.shutdown();
            }

            SessionManager.getSessionFactory().Close();

            log.Info("Killing main thread.");
            Application.Current.Shutdown();
        }
    }
}