using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.ComponentModel;
using System.Data.SQLite;
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

namespace OfflineServer
{   
    public partial class MainWindow : MetroWindow
    {
        public NfswSession mCurrentSession { get; set; } = new NfswSession();
        private DispatcherTimer tRandomPersonaInfo = new DispatcherTimer();
        private HTTPServer sHttp = new HTTPServer();

        public MainWindow()
        {
            #region Culture Independency
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
            XmlLanguage xMarkup = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.Name);
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(xMarkup));
            FrameworkContentElement.LanguageProperty.OverrideMetadata(typeof(System.Windows.Documents.TextElement), new FrameworkPropertyMetadata(xMarkup));
            #endregion

            if (!File.Exists("ServerData\\PersonaData.db")) vCreateDB();
            
            mCurrentSession.StartSession();
            InitializeComponent();
            SetupComponents();
        }

        private void vCreateDB()
        {
            Directory.CreateDirectory("ServerData");

            File.WriteAllText("ServerData\\test.xml", "<Test xmlns:i=\"\"><localtest/></Test>");

            SQLiteConnection.CreateFile("ServerData\\PersonaData.db");
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=\"ServerData\\PersonaData.db\";Version=3;");
            m_dbConnection.Open();
            string sql = "create table personas (Id bigint, IconIndex smallint, Name varchar(14), Motto varchar(30), Level smallint, IGC int, Boost int, ReputationPercentage smallint, LevelReputation int, TotalReputation int, Garage longtext, Inventory longtext)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into personas (Id, IconIndex, Name, Motto, Level, IGC, Boost, ReputationPercentage, LevelReputation, TotalReputation, Garage, Inventory) values (0, 27, 'Debug', 'Test Build', 69, 0, 0, 0, 0, 699, 'GaragePlaceholder', 'InventoryPlaceholder')";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into personas (Id, IconIndex, Name, Motto, Level, IGC, Boost, ReputationPercentage, LevelReputation, TotalReputation, Garage, Inventory) values (1, 26, 'DefaultProfile', 'Literally, the first.', 1, 25000, 1500, 0, 0, 0, 'GaragePlaceholder2', 'InventoryPlaceholder2')";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
            m_dbConnection.Dispose();
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
                Path = new PropertyPath("mPersona.shAvatarIndex"),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                Mode = BindingMode.TwoWay,
                Source = mCurrentSession
            };
            FlipViewPersonaImage.SelectedIndex = mCurrentSession.mPersona.shAvatarIndex;
            BindingOperations.SetBinding(FlipViewPersonaImage, FlipView.SelectedIndexProperty, indexBind);
            #endregion

            #region MetroTile -> Random Persona Info
            tRandomPersonaInfo_Tick(null, null);
            tRandomPersonaInfo.Tick += new EventHandler(tRandomPersonaInfo_Tick);
            tRandomPersonaInfo.Interval = new TimeSpan(0, 0, 10);
            tRandomPersonaInfo.Start();
            #endregion
        }

        private void tRandomPersonaInfo_Tick(object sender, EventArgs e)
        {
            DockPanel dNewInfoContent = mCurrentSession.mEngine.mAchievements.GenerateNewAchievement();
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
                    /* Cheeky little trick to restart timer */ tRandomPersonaInfo.Stop(); /* -> */ tRandomPersonaInfo.Start();
                    tRandomPersonaInfo_Tick(null, null);
                    break;
            }
        }

        #region PersonaList related events
        private void datagridPersonaList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Persona mSelectedPersona = datagridPersonaList.SelectedItem as Persona;
            mCurrentSession.mPersona = mSelectedPersona;
        }

        private void flyoutBasicPersonaInfo_IsOpenChanged(object sender, RoutedEventArgs e)
        {
            if (!flyoutBasicPersonaInfo.IsOpen)
            {
                Int32 iPersonaIndex = mCurrentSession.mPersonaList.IndexOf(mCurrentSession.mPersonaList.First<Persona>(sPersona => sPersona.iId == mCurrentSession.mPersona.iId));
                mCurrentSession.mPersonaList[iPersonaIndex] = mCurrentSession.mPersona;
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
            sHttp.nServer.Stop();
            sHttp.nServer.Dispose();

            NfswSession.dbConnection.Close();
            NfswSession.dbConnection.Dispose();
        }
    }

}