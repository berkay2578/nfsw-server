using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace OfflineServer
{

    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// NOT actual achievements, only readings from API.
    /// </summary>
    public class Achievements
    {
        private Random rPseudo;
        private DockPanel dpAchievement;
        private ImageBrush ibAchievementBackground;
        private TextBlock tblockAchievementDescription;
        private static class tAchievement
        {
            public const Int32 TreasureHunt = 1;
            public const Int32 FarthestJumpDistance = 2;
        }

        private void vReDefine()
        {
            rPseudo = new Random();
            ibAchievementBackground = new ImageBrush()
            {
                Stretch = Stretch.Fill
            };
            tblockAchievementDescription = new TextBlock()
            {
                Text = "DEBUG PLACEHOLDER",
                Padding = new Thickness(6d),
                Background = new SolidColorBrush(Color.FromArgb(122, 0, 0, 0)),
                VerticalAlignment = VerticalAlignment.Bottom,
                TextTrimming = TextTrimming.CharacterEllipsis,
                Height = 30
            };
            DockPanel.SetDock(tblockAchievementDescription, Dock.Bottom);
            dpAchievement = new DockPanel()
            {
                Background = ibAchievementBackground
            };
            dpAchievement.Children.Add(tblockAchievementDescription);
        }

        public Achievements()
        {
            vReDefine();
        }

        public DockPanel GenerateNewAchievement()
        {
            String sCurrentText = tblockAchievementDescription.Text;
            reroll:

            vReDefine();

            switch (rPseudo.Next(1, 3))
            {
                case tAchievement.TreasureHunt:
                    {
                        ibAchievementBackground.ImageSource = (ImageSource)BitmapFrame.Create(new Uri("pack://application:,,,/OfflineServer;component/images/NFSW_Achievements/TreasureHuntStreak.png", UriKind.RelativeOrAbsolute));
                        tblockAchievementDescription.Text = "Your longest TH Streak was 8, on persona 'Default Profile 1'."; // PLACEHOLDER, mPersona->bIsTHBrokenForViewModel, mPersona->iTHStreak, TH class?
                        break;
                    }
                case tAchievement.FarthestJumpDistance:
                    { 
                        ibAchievementBackground.ImageSource = (ImageSource)BitmapFrame.Create(new Uri("pack://application:,,,/OfflineServer;component/images/NFSW_Achievements/JumpDistance.png", UriKind.RelativeOrAbsolute));
                        tblockAchievementDescription.Text = "Your farthest jump distance was 12.87 meters, on persona 'Default Profile 1'."; // PLACEHOLDER, mEngine->API->JumpDistance, mmmph...
                        break;
                    }
            }
            if (tblockAchievementDescription.Text.Equals(sCurrentText)) goto reroll;

            return dpAchievement;
        }
    }

    /// <summary>
    /// SpeedAPI equivalent for the offline server.
    /// </summary>
    public class ServerDataAPI
    {

    }

    public class Car
    {
        public Int32 iCarId;
        public Int32 iCarIndex;
        public Int64 iPhysicsProfileHash;
    }

    public class Cars : IEnumerable<Car>
    {
        private List<Car> mCarsArray;
        

        public void Add(Car newCarEntry)
        {
            mCarsArray.Add(newCarEntry);
        }

        public Int32 iAmount
        {
            get
            {
                Int32 calculate = 13;
                return calculate;
            }
        }

        public void Initialize()
        {

        }

        public IEnumerator<Car> GetEnumerator()
        {
            foreach (Car CarEntry in mCarsArray)
            {
                if (CarEntry != null)
                {
                    yield return CarEntry;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    /// <summary>
    /// Class containing all of the required variables and initializers to create and use a Server Engine.
    /// </summary>
    /// <remarks>This is NOT to be confused with the NFS:W Game Engines. Server Engines are custom prices and patches.</remarks>
    public class Engine
    {
        /// <summary>
        /// For future use.
        /// </summary>
        public enum EngineType
        {
            Default = 0,
            Custom = 1,
            Debug = 2
        }

        public Int32 iEngineIndex = 0;
        public Achievements mAchievements = new Achievements();
        public ServerDataAPI mServerDataAPI;

        public void LoadEngine(EngineType mEngine, Int32 EngineIndex = 0)
        {
            switch (mEngine)
            {
                case EngineType.Default:
                    break;
                case EngineType.Custom:
                    break;
                case EngineType.Debug:
                    break;
            }
        }
    }

    /// <summary>
    /// Class containing all of the required variables and initializers to create and use a local Persona.
    /// </summary>
    public class Persona : ObservableObject
    {
        /// <summary>
        /// For future use.
        /// </summary>
        public enum PersonaType
        {
            Basic = 0,
            Detailed = 1,
            Debug = 2
        }

        private Int64 _iId;
        public Int64 iId
        {
            get { return _iId; }
            set
            {
                _iId = value;
                RaisePropertyChangedEvent("iId");
            }
        }

        private Int16 _shAvatarIndex;
        public Int16 shAvatarIndex {
            get { return _shAvatarIndex; }
            set
            {
                _shAvatarIndex = (Int16)((value <= 0) ? 0 : (value >= 27) ? 27 : value);
                RaisePropertyChangedEvent("shAvatarIndex");
            }
        }

        private String _sName;
        public String sName
        {
            get { return _sName; }
            set
            {
                _sName = value;
                RaisePropertyChangedEvent("sName");
            }
        }

        private String _sMotto;
        public String sMotto
        {
            get { return _sMotto; }
            set
            {
                _sMotto = value;
                RaisePropertyChangedEvent("sMotto");
            }
        }

        private Int16 _shLevel;
        public Int16 shLevel {
            get { return _shLevel; }
            set
            {
                _shLevel = value;
                RaisePropertyChangedEvent("shLevel");
            }
        }

        private Int32 _iCash;
        public Int32 iCash
        {
            get { return _iCash; }
            set
            {
                _iCash = value;
                RaisePropertyChangedEvent("iCash");
                RaisePropertyChangedEvent("iCashForView");
            }
        }
        public String iCashForView
        {
            get
            {
                return iCash == 0 ? "\r\n\r\n\r\n0.":iCash.ToString("#\r\n##,#\r\n###\r\n###")+".";
            }
        }

        private Int32 _iBoost;
        public Int32 iBoost
        {
            get { return _iBoost; }
            set
            {
                _iBoost = value;
                RaisePropertyChangedEvent("iBoost");
                RaisePropertyChangedEvent("iBoostForView");
            }
        }
        public String iBoostForView
        {
            get
            {
                return iBoost == 0 ? "\r\n\r\n\r\n0." : iBoost.ToString("#\r\n##,#\r\n###\r\n###")+".";
            }
        }

        private Int16 _iPercentageOfLevelCompletion;
        public Int16 iPercentageOfLevelCompletion
        {
            get { return _iPercentageOfLevelCompletion; }
            set
            {
                _iPercentageOfLevelCompletion = value;
                RaisePropertyChangedEvent("iPercentageOfLevelCompletion");
            }
        }

        private Int32 _iReputationInLevel;
        public Int32 iReputationInLevel
        {
            get { return _iReputationInLevel; }
            set
            {
                _iReputationInLevel = value;
                RaisePropertyChangedEvent("iReputationInLevel");
            }
        }

        private Int32 _iReputationInTotal;
        public Int32 iReputationInTotal
        {
            get { return _iReputationInTotal; }
            set
            {
                _iReputationInTotal = value;
                RaisePropertyChangedEvent("iReputationInTotal");
            }
        }

        private Cars _mCars;
        public Cars mCars
        {
            get { return _mCars; }
            set
            {
                _mCars = value;
                RaisePropertyChangedEvent("mCars");
            }
        }

        /// <summary>
        /// Initializes the Persona class with the given parameter values.
        /// </summary>
        public Persona(Int64 personaId, Int16 personaAvatarIndex, String personaName, String personaMotto, Int16 personaLevel, Int32 personaCash, Int32 personaBoost, Int16 personaPercentageOfLevel, Int32 personaReputationLevel, Int32 personaReputationTotal)
        {
            this.iId = personaId;
            this.shAvatarIndex = personaAvatarIndex;
            this.sName = personaName;
            this.sMotto = personaMotto;
            this.shLevel = personaLevel;
            this.iCash = personaCash;
            this.iBoost = personaBoost;
            this.iPercentageOfLevelCompletion = personaPercentageOfLevel;
            this.iReputationInLevel = personaReputationLevel;
            this.iReputationInTotal = personaReputationTotal;
            this.mCars = new Cars(); //////////////PLACEHOLDER!!!!
        }

        /// <summary>
        /// Initializes the Persona class with the given persona.
        /// </summary>
        public Persona(Persona persona)
        {
            this.iId = persona.iId;
            this.shAvatarIndex = persona.shAvatarIndex;
            this.sName = persona.sName;
            this.sMotto = persona.sMotto;
            this.shLevel = persona.shLevel;
            this.iCash = persona.iCash;
            this.iBoost = persona.iBoost;
            this.iPercentageOfLevelCompletion = persona.iPercentageOfLevelCompletion;
            this.iReputationInLevel = persona.iReputationInLevel;
            this.iReputationInTotal = persona.iReputationInTotal;
            this.mCars = new Cars(); //////////////PLACEHOLDER!!!!
        }

        /// <summary>
        /// Converts the Persona to its multilined string equivalent.
        /// </summary>
        public override String ToString()
        {
            string sPersonaData = "Persona Information: {" + Environment.NewLine +
                "   Id: " + iId.ToString() + Environment.NewLine +
                "   Avatar Index: " + shAvatarIndex.ToString() + Environment.NewLine +
                "   Name: " + sName + Environment.NewLine +
                "   Motto: " + sMotto + Environment.NewLine +
                "   Level: " + shLevel.ToString() + Environment.NewLine +
                "   Cash: " + iCash.ToString() + Environment.NewLine +
                "   Boost: " + iBoost.ToString() + Environment.NewLine +
                "}";
            return sPersonaData;
        }

        /// <summary>
        /// Reads the registered personas from a fixed-string database file and returns them.
        /// </summary>
        /// <remarks>This is NOT dynamic, this only reads from the database.</remarks>
        /// <returns>An initialized "List<Persona>" containing the database entries for the personas.</returns>
        public static List<Persona> GetCurrentPersonaList()
        {
            List<Persona> listPersona = new List<Persona>();

            string sql = "select * from personas order by Id asc";
            SQLiteCommand command = new SQLiteCommand(sql, MainWindow.dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Persona dummyPersona = new Persona((Int64)reader[0], (Int16)reader[1], (String)reader[2], (String)reader[3], (Int16)reader[4], (Int32)reader[5], (Int32)reader[6], (Int16)reader[7], (Int32)reader[8], (Int32)reader[9]);
                listPersona.Add(dummyPersona);
            }

            return listPersona;
        }
    }
    
    public class NfswSession : ObservableObject
    {
        public Engine mEngine = new Engine();
        private Persona _mPersona;
        public Persona mPersona
        {
            get { return _mPersona; }
            set
            {
                if (this._mPersona != value)
                {
                    this._mPersona = value;
                    RaisePropertyChangedEvent("mPersona");
                }
            }
        }
        private List<Persona> _mPersonaList;
        public List<Persona> mPersonaList {
            get { return _mPersonaList; }
            set { if (_mPersonaList != value) { _mPersonaList = value; RaisePropertyChangedEvent("mPersonaList"); } }
        }
        public string PermanentSession;
        public string UserSettings;

        public void StartSession()
        {
            MainWindow.dbConnection = new SQLiteConnection("Data Source=\"Server Data\\PersonaData.db\";Version=3;");
            MainWindow.dbConnection.Open();

            mPersonaList = Persona.GetCurrentPersonaList();
            _mPersona = new Persona(mPersonaList[0]);


            //long readSessionIdAndCalculated = 0002;
            //    Persona.SetPersona(readSessionIdAndCalculated);
        }
    }
    
    public partial class MainWindow : MetroWindow
    {
        public static SQLiteConnection dbConnection;
        public static NfswSession CurrentSession = new NfswSession();
        private DispatcherTimer tRandomPersonaInfo = new DispatcherTimer();
        public MainWindow()
        {
            #region Culture Independency
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
            XmlLanguage xMarkup = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.Name);
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(xMarkup));
            FrameworkContentElement.LanguageProperty.OverrideMetadata(typeof(System.Windows.Documents.TextElement), new FrameworkPropertyMetadata(xMarkup));
            #endregion

            CurrentSession.StartSession();
            InitializeComponent();
            SetupComponents();
        }

        private void SetupComponents()
        {
            goto skip;
            #region Create .db || Get rid of label if running for the first-time
            if (File.Exists("Server Data\\PersonaData.db")) { File.Delete("Server Data\\PersonaData.db"); } else { Directory.CreateDirectory("Server Data"); }

            SQLiteConnection.CreateFile("Server Data\\PersonaData.db");
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=\"Server Data\\PersonaData.db\";Version=3;");
            m_dbConnection.Open();
            string sql = "create table personas (Id bigint, IconIndex smallint, Name varchar(14), Motto varchar(30), Level smallint, IGC int, Boost int, ReputationPercentage smallint, LevelReputation int, TotalReputation int, Garage longtext, Inventory longtext)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into personas (Id, IconIndex, Name, Motto, Level, IGC, Boost, ReputationPercentage, LevelReputation, TotalReputation, Garage, Inventory) values (0, 27, 'Debug', 'Test Build', 69, 0, 0, 0, 0, 699, 'GaragePlaceholder', 'InventoryPlaceholder')";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into personas (Id, IconIndex, Name, Motto, Level, IGC, Boost, ReputationPercentage, LevelReputation, TotalReputation, Garage, Inventory) values (1, 26, 'Default Profile 1', 'Literally, the first.', 1, 25000, 1500, 0, 0, 0, 'GaragePlaceholder2', 'InventoryPlaceholder2')";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            #endregion
            skip:

            #region FlipViewPersona
            FlipViewPersonaImage.HideControlButtons();
            
            Image Image_FlipViewDummy;
            Grid Grid_FlipViewDummy;
            for (int i = 0; i < 28; i++)
            {
                Image_FlipViewDummy = new Image() { Margin = new Thickness(7d), HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Stretch = Stretch.Uniform, Source = (ImageSource)BitmapFrame.Create(new Uri("pack://application:,,,/OfflineServer;component/images/NFSW_Avatars/Avatar_" + i.ToString() + ".png", UriKind.Absolute)) };
                Grid_FlipViewDummy = new Grid() { Margin = new Thickness(-8d) };
                Grid_FlipViewDummy.Children.Add(Image_FlipViewDummy);
                Image t1 = new Image() { Source = Image_FlipViewDummy.Source };
                t1.Effect = new System.Windows.Media.Effects.BlurEffect() { Radius = 7.5d };
                Grid_FlipViewDummy.Background = new VisualBrush((Visual)t1);
                FlipViewPersonaImage.Items.Add(Grid_FlipViewDummy);
            }
            #endregion

            #region Flyouts &++ DataGrid;dbConnection
            FlipViewPersonaImage.DataContext = CurrentSession;
            stackpanelBasicPersonaInfo.DataContext = CurrentSession;
            datagridPersonaList.DataContext = CurrentSession;
            groupBox.DataContext = CurrentSession;
            #endregion

            #region MetroTile -> Random Persona Info
            tRandomPersonaInfo_Tick(null, null);
            tRandomPersonaInfo.Tick += new EventHandler(tRandomPersonaInfo_Tick);
            tRandomPersonaInfo.Interval = new TimeSpan(0, 0, 20);
            tRandomPersonaInfo.Start();
            #endregion

        }

        private void tRandomPersonaInfo_Tick(object sender, EventArgs e)
        {
            DockPanel dNewInfoContent = CurrentSession.mEngine.mAchievements.GenerateNewAchievement();
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
                    //if (metrotileRandomPersonaInfo.Content != (Visual)Resources["appbar_calculator"]) { metrotileRandomPersonaInfo.Content = (Visual)Resources["appbar_cupcake"]; return; }
                    //metrotileRandomPersonaInfo.Content = (Visual)Resources["appbar_calculator"];
                    
                    flyoutDetailedPersonaInfo.IsOpen = !flyoutDetailedPersonaInfo.IsOpen;
                    Console.WriteLine(CurrentSession.mPersona.ToString());
                    break;
                case "buttonOpenPersonaList":
                    flyoutPersonaList.IsOpen = !flyoutPersonaList.IsOpen;
                    break;
                case "buttonUpdatePersonaInfoTile":
                    tRandomPersonaInfo_Tick(null, null);
                    break;
                default:
                    break;
            }
        }

        private void datagridPersonaList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Persona mSelectedPersona = datagridPersonaList.SelectedItem as Persona;
            CurrentSession.mPersona = mSelectedPersona;
        }

        private void flyoutBasicPersonaInfo_IsOpenChanged(object sender, RoutedEventArgs e)
        {
            //currently only implemented for Debug purposes, will be tidied up later
            int iPersonaIndex = CurrentSession.mPersonaList.FindIndex(a => a.iId == CurrentSession.mPersona.iId);
            CurrentSession.mPersonaList[iPersonaIndex] = CurrentSession.mPersona;
            datagridPersonaList.Items.Refresh();
        }

        #region FlipViewPersonaImage Event Handlers
        private void FlipViewPersonaImage_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as FlipView).ShowControlButtons();
        }

        private void FlipViewPersonaImage_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as FlipView).HideControlButtons();
        }

        private void FlipViewPersonaImage_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as FlipView).SelectedIndex = CurrentSession.mPersona.shAvatarIndex;
            Binding indexBind = new Binding
            {
                Path = new PropertyPath("mPersona.shAvatarIndex"),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                Mode = BindingMode.TwoWay
            };
            (sender as FlipView).SetBinding(FlipView.SelectedIndexProperty, indexBind);
        }
        #endregion
        
    }
}
