using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace OfflineServerLauncher
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
    public class Persona
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
        public Int64 iId { get; set; }
        public Int16 shAvatarIndex { get; set; }
        public String sName { get; set; }
        public String sMotto { get; set; }
        public Int16 shLevel { get; set; }
        public Int32 iCash { get; set; }
        public Int32 iBoost { get; set; }
        public Int16 iPercentageOfLevelCompletion { get; set; }
        public Int32 iReputationInLevel { get; set; }
        public Int32 iReputationInTotal { get; set; }

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
        public Engine EngineBuild;
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
            get { return _mPersonaList; } set { if (_mPersonaList != value) { _mPersonaList = value; RaisePropertyChangedEvent("mPersonaList"); } }
        }
        public string PermanentSession;
        public string UserSettings;

        public void StartSession()
        {
            MainWindow.dbConnection = new SQLiteConnection("Data Source=\"Server Data\\PersonaData.db\";Version=3;");
            MainWindow.dbConnection.Open();

            mPersonaList = Persona.GetCurrentPersonaList();
            _mPersona = new Persona(mPersonaList[0]);
            Console.WriteLine(_mPersona.ToString());


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
            
            Rectangle Rectangle_FlipViewDummy;
            ImageBrush ImageBrush_FlipViewDummy;
            for (int i = 0; i < 28; i++)
            {
                ImageBrush_FlipViewDummy = new ImageBrush() { Stretch = Stretch.Uniform, ImageSource = (ImageSource)BitmapFrame.Create(new Uri("pack://application:,,,/OfflineServerLauncher;component/images/NFSW_Avatars/Avatar_" + i.ToString() + ".png", UriKind.Absolute)) };
                Rectangle_FlipViewDummy = new Rectangle() { Stretch = Stretch.Uniform, Width = 120, Height = 120, Fill = ImageBrush_FlipViewDummy };
                FlipViewPersonaImage.Items.Add(Rectangle_FlipViewDummy);
            }
            #endregion

            #region Flyouts &++ DataGrid;dbConnection
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
            //placeholder for now
            DockPanel t1 = new DockPanel() { Background = new ImageBrush() { Stretch = Stretch.Fill, ImageSource = (ImageSource)BitmapFrame.Create(new Uri("pack://application:,,,/OfflineServerLauncher;component/images/NFSW_Campaigns/Treasure_Hunt.png", UriKind.Absolute)) } };
            TextBlock t1_1 = new TextBlock() { Text = "Your longest TH Streak is 0 on persona 'Default Profile 1'.", Padding = new Thickness(5d), Background = new SolidColorBrush(Color.FromArgb(122, 0, 0, 0)), VerticalAlignment = VerticalAlignment.Bottom, TextTrimming = TextTrimming.CharacterEllipsis, Height = 30 };
            DockPanel.SetDock(t1_1, Dock.Bottom);
            t1.Children.Add(t1_1);
            metrotileRandomPersonaInfo.Content = t1;
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
                    //Console.WriteLine(CurrentSession.mPersona.ToString());
                    break;
                case "buttonOpenPersonaList":
                    flyoutPersonaList.IsOpen = !flyoutPersonaList.IsOpen;
                    break;
                default:
                    break;
            }
        }

        private void datagridPersonaList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Persona mSelectedPersona = datagridPersonaList.SelectedItem as Persona;
            //Int64 iSelectedPersonaId = mSelectedPersona.iId;
            CurrentSession.mPersona = new Persona(mSelectedPersona);
            //Console.WriteLine(mSelectedPersona.ToString());
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
            FlipViewPersonaImage.SelectedIndex = CurrentSession.mPersona.shAvatarIndex;
        }
        #endregion

    }
}
