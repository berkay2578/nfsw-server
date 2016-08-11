using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using OfflineServer.Servers.Database;
using OfflineServer.Servers.Database.Entities;

namespace OfflineServer
{
    public partial class MainWindow : MetroWindow
    {
        private DispatcherTimer RandomPersonaInfo = new DispatcherTimer();
        public Access Access { get; set; }

        public MainWindow()
        {
            ExtraFunctions.log("Application started.", "MainThread");

            #region Culture Independency
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
            XmlLanguage xMarkup = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.Name);
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(xMarkup));
            FrameworkContentElement.LanguageProperty.OverrideMetadata(typeof(System.Windows.Documents.TextElement), new FrameworkPropertyMetadata(xMarkup));
            ExtraFunctions.log("Culture independency achieved.", "MainThread");
            #endregion

            vCreateDb();

            Access = new Access();

            ExtraFunctions.log("Starting session.", "MainThread");
            Access.CurrentSession.startSession();
            InitializeComponent();
            SetupComponents();
        }

        private void vCreateDb()
        {
            if (!File.Exists("ServerData\\Personas.db"))
            {
                ExtraFunctions.log("Database doesn't exist!", "vCreateDb", 1);
                if (!Directory.Exists("ServerData")) Directory.CreateDirectory("ServerData");
                
                var sessionFactory = SessionManager.createDatabase();
                ExtraFunctions.log("Created database successfully.", "vCreateDb");
                ExtraFunctions.log("Inserting filler entries.", "vCreateDb");

                using (var session = sessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        PersonaEntity personaEntity = new PersonaEntity();
                        personaEntity.boost = 7331;
                        personaEntity.cash = 1337;
                        personaEntity.iconIndex = 27;
                        personaEntity.id = 100;
                        personaEntity.level = 60;
                        personaEntity.motto = "test";
                        personaEntity.name = "DEBUG";
                        personaEntity.percentageOfLevelCompletion = 0;
                        personaEntity.rating = 8752;
                        personaEntity.reputationInLevel = 0;
                        personaEntity.reputationInTotal = 9999999;
                        personaEntity.score = 2578;
                        
                        CarEntity carEntity = new CarEntity();
                        carEntity.baseCarId = 1816139026L;
                        carEntity.carId = 1;
                        carEntity.durability = 100;
                        carEntity.heatLevel = 6;
                        carEntity.paints = "<Paints/>";
                        carEntity.performanceParts = "<PerformanceParts/>";
                        carEntity.physicsProfileHash = -846723009L;
                        carEntity.raceClass = CarClass.A;
                        carEntity.rating = 750;
                        carEntity.resalePrice = 123456789;
                        carEntity.skillModParts = "<SkillModParts/>";
                        carEntity.vinyls = "<Vinyls/>";
                        carEntity.visualParts = "<VisualParts/>";

                        personaEntity.addCar(carEntity);
                        session.Save(personaEntity);
                        transaction.Commit();
                        ExtraFunctions.log("Database actions finalized.", "vCreateDb");
                    }
                }                
            } else { ExtraFunctions.log("Database already exists, skipping creation.", "vCreateDb"); }
        }

        private void SetupComponents()
        {
            #region FlipViewPersona
            FlipViewPersonaImage.HideControlButtons();

            Grid[] aFlipViewAvatarArray = new Grid[28];
            for (int i = 0; i < 28; i++)
            {
                Grid Grid_FlipViewDummy;
                Image Image_FlipViewDummy;
                Image_FlipViewDummy = new Image() { Margin = new Thickness(7d), HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Stretch = Stretch.Uniform, Source = (ImageSource)BitmapFrame.Create(new Uri("pack://application:,,,/OfflineServer;component/images/NFSW_Avatars/Avatar_" + i.ToString() + ".png", UriKind.Absolute)) };
                Grid_FlipViewDummy = new Grid() { Margin = new Thickness(-8d) };
                Grid_FlipViewDummy.Children.Add(Image_FlipViewDummy);
                Image t1 = new Image() { Source = Image_FlipViewDummy.Source };
                t1.Effect = new System.Windows.Media.Effects.BlurEffect() { Radius = 7.5d };
                Grid_FlipViewDummy.Background = new VisualBrush((Visual)t1);
                aFlipViewAvatarArray[i] = Grid_FlipViewDummy;
            }
            FlipViewPersonaImage.ItemsSource = aFlipViewAvatarArray;

            Binding indexBind = new Binding()
            {
                Path = new PropertyPath("ActivePersona.IconIndex"),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                Mode = BindingMode.TwoWay,
                Source = Access.CurrentSession
            };
            FlipViewPersonaImage.SelectedIndex = Access.CurrentSession.ActivePersona.IconIndex;
            BindingOperations.SetBinding(FlipViewPersonaImage, FlipView.SelectedIndexProperty, indexBind);
            #endregion

            #region MetroTile -> Random Persona Info
            tRandomPersonaInfo_Tick(null, null);
            RandomPersonaInfo.Tick += new EventHandler(tRandomPersonaInfo_Tick);
            RandomPersonaInfo.Interval = new TimeSpan(0, 0, 10);
            RandomPersonaInfo.Start();
            #endregion
        }

        private void tRandomPersonaInfo_Tick(object sender, EventArgs e)
        {
            DockPanel dNewInfoContent = Access.CurrentSession.Engine.Achievements.generateNewAchievement();
            metrotileRandomPersonaInfo.Content = dNewInfoContent;
        }

        private async void buttonStartServer_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //test
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Yes, please.",
                NegativeButtonText = "Go away!",
                ColorScheme = MetroDialogOptions.ColorScheme
            };

            MessageDialogResult result = await this.ShowMessageAsync("Hello!", "It seems like this is your first time running this build of the Offline Server! Would you like some help?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

            if (result != MessageDialogResult.FirstAuxiliary)
            {

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
                        new Binding() {
                            Converter = new STEditConverter(this),
                            Path = new PropertyPath("ActivePersona.SelectedCar." + ((sender as Button).Name).Remove(0, 6)),
                            UpdateSourceTrigger = UpdateSourceTrigger.LostFocus,
                            Mode = BindingMode.TwoWay,
                            Source = Access.CurrentSession
                        });
                    flyoutGaragePartInfo.IsOpen = !flyoutGaragePartInfo.IsOpen;
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
                    BindingOperations.ClearBinding(_Window.tbGaragePartInfo, MVVMSyntax._TextProperty);
                    _Window.flyoutGaragePartInfo.IsOpen = false;
                    MessageBox.Show(ex.Message, "ERROR: Not valid input", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
        }

        #region PersonaList related events
        private void datagridPersonaList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Persona mSelectedPersona = datagridPersonaList.SelectedItem as Persona;
            Access.CurrentSession.ActivePersona = mSelectedPersona;
        }

        private void flyoutBasicPersonaInfo_IsOpenChanged(object sender, RoutedEventArgs e)
        {
            if (!flyoutBasicPersonaInfo.IsOpen)
            {
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

        private void MetroWindow_Closing(object sender, CancelEventArgs e)
        {
            ExtraFunctions.log("Shutting down offline server.", "MainThread");

            // https://github.com/foxglovesec/Potato/blob/master/source/NHttp/NHttp/HttpServer.cs#L261
            Access.sHttp.nServer.Stop();
            Access.sHttp.nServer.Dispose();
            ExtraFunctions.log("Shutdown completed.", "HttpServer");

            Access.sXmpp.shutdown();

            NfswSession.dbConnection.Close();
            NfswSession.dbConnection.Dispose();

            ExtraFunctions.log("Killing main thread.\r\n", "GarbageCollector");
        }
    }
}