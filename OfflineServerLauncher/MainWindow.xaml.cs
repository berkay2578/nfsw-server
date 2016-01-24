using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.IO;
using System.Data.SQLite;
using System.Windows.Data;

namespace OfflineServerLauncher
{
    public partial class MainWindow : MetroWindow
    {
        public static SQLiteConnection dbConnection;

        public enum PersonaType
        {
            Basic = 0,
            Detailed = 1,
            Debug = 2
        }
        public struct Persona
        {
            public Int64 iId { get; set; }
            public String sName { get; set; }
            public String sMotto { get; set; }
            public Int16 shLevel { get; set; }
            public Int32 iIGC { get; set; }
            public Int32 iBoost { get; set; }
            
            public Persona(Int64 personaId, String personaName, String personaMotto, Int16 personaLevel, Int32 personaIGC, Int32 personaBoost)
            {
                iId = personaId;
                sName = personaName;
                sMotto = personaMotto;
                shLevel = personaLevel;
                iIGC = personaIGC;
                iBoost = personaBoost;
            }

            public override String ToString()
            {
                string sPersonaData = "Persona Information: {" + Environment.NewLine +
                    "   Id: " + iId.ToString() + Environment.NewLine +
                    "   Name: " + sName + Environment.NewLine +
                    "   Motto: " + sMotto + Environment.NewLine +
                    "   Level: " + shLevel.ToString() + Environment.NewLine +
                    "   IGC: " + iIGC.ToString() + Environment.NewLine +
                    "   Boost: " + iBoost.ToString() + Environment.NewLine +
                    "}";
                return sPersonaData;
            }

            public static List<Persona> GetCurrentPersonaList(PersonaType iPersonaType)
            {
                List<Persona> listPersona = new List<Persona>();

                string sql = "select * from personas order by Id asc";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Persona dummyPersona = new Persona((Int64)reader[0], (String)reader[1], (String)reader[2], (Int16)reader[3], (Int32)reader[4], (Int32)reader[5]);
                    listPersona.Add(dummyPersona);
                }

                return listPersona;
            }
        }
        private struct NfswSession
        {
            public string EngineBuild;
            public Persona Persona;
            public string PermanentSession;
            public string UserSettings;
            //public string Cars { get { return @"Server Data\Personas\" + Persona.GetStringInstance() + @"\Garage.xml"; } }
            //public string Inventory { get { return @"Server Data\Personas\" + Persona.GetStringInstance() + @"\Inventory.xml"; } }
            
            public void StartSession()
            {
                Persona = new Persona();

                long readSessionIdAndCalculated = 0002;
            //    Persona.SetPersona(readSessionIdAndCalculated);
            }
        }

        private NfswSession CurrentSession = new NfswSession();
        public MainWindow()
        {
            InitializeComponent();
            SetupComponents();
            CurrentSession.StartSession();
        }

        private void SetupComponents()
        {
            #region FlipViewPersona

            FlipViewPersonaImage.HideControlButtons();

            Grid Grid_FlipViewDummy;
            Rectangle Rectangle_FlipViewDummy;
            VisualBrush VisualBrush_FlipViewDummy;
            for (int i = 0; i < 30; i++)
            {
                Grid_FlipViewDummy = new Grid();
                Rectangle_FlipViewDummy = new Rectangle() { Margin = new Thickness(0d), Width = 100, Height = 100 };
                VisualBrush_FlipViewDummy = new VisualBrush((Visual)this.FindResource("EngineStart"));

                Rectangle_FlipViewDummy.Fill = VisualBrush_FlipViewDummy;

                Grid_FlipViewDummy.Children.Add(Rectangle_FlipViewDummy);
                
                FlipViewPersonaImage.Items.Add(Grid_FlipViewDummy);
            }

            #endregion

            #region Basic Persona Info &++ DataGrid;dbConnection
            /*File.Delete("Server Data\\PersonaData.db");
            SQLiteConnection.CreateFile("Server Data\\PersonaData.db");
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=\"Server Data\\PersonaData.db\";Version=3;");
            m_dbConnection.Open();
            string sql = "create table personas (Id bigint, Name varchar(14), Motto varchar(30), Level smallint, IGC int, Boost int, ReputationPercentage smallint, LevelReputation int, TotalReputation int)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into personas (Id, Name, Motto, Level, IGC, Boost, ReputationPercentage, LevelReputation, TotalReputation) values (0, 'Debug', 'Test Build', 69, 0, 0, 0, 0, 699)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into personas (Id, Name, Motto, Level, IGC, Boost, ReputationPercentage, LevelReputation, TotalReputation) values (1, 'Default Profile 1', 'Literally, the first.', 1, 25000, 1500, 0, 0, 0)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();*/

            dbConnection = new SQLiteConnection("Data Source=\"Server Data\\PersonaData.db\";Version=3;");
            dbConnection.Open();

            datagridPersonaList.ItemsSource = Persona.GetCurrentPersonaList(PersonaType.Basic);
            #endregion
        }

        private async void buttonStartServer_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
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

        private void FlipView_GotFocus(object sender, RoutedEventArgs e)
        {
            ((FlipView)sender).ShowControlButtons();
        }

        private void FlipView_LostFocus(object sender, RoutedEventArgs e)
        {
            ((FlipView)sender).HideControlButtons();
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            if (metrotileRandomPersonaInfo.Content == (Visual)Resources["appbar_calculator"]) { metrotileRandomPersonaInfo.Content = (Visual)Resources["appbar_cupcake"]; return; }
            metrotileRandomPersonaInfo.Content = (Visual)Resources["appbar_calculator"];
        }

        private void Button_ClickHandler(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "buttonOpenBasicPersonaInfo":
                    flyoutBasicPersonaInfo.IsOpen = !flyoutBasicPersonaInfo.IsOpen;
                    break;
                case "buttonOpenDetailedPersonaInfo":
                    button_Copy1_Click(new object(), new RoutedEventArgs());
                    break;
                case "buttonOpenPersonaList":
                    flyoutPersonaList.IsOpen = !flyoutPersonaList.IsOpen;
                    break;
                default:
                    break;
            }
        }
        
    }
}
