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
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit;

namespace OfflineServer
{   
    public partial class MainWindow : MetroWindow
    {
        private DispatcherTimer RandomPersonaInfo = new DispatcherTimer();
        public Access Access { get; set; }

        public MainWindow()
        {
            #region Culture Independency
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
            XmlLanguage xMarkup = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.Name);
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(xMarkup));
            FrameworkContentElement.LanguageProperty.OverrideMetadata(typeof(System.Windows.Documents.TextElement), new FrameworkPropertyMetadata(xMarkup));
            #endregion

            vCreateDB(); // until beta

            Access = new Access();

            Access.CurrentSession.StartSession();
            InitializeComponent();
            SetupComponents();
        }

        private void vCreateDB()
        {
            if (Directory.Exists("ServerData")) Directory.Delete("ServerData", true);
            Directory.CreateDirectory("ServerData");

            File.WriteAllText("ServerData\\test.xml", "<Test><localtest/></Test>");

            SQLiteConnection.CreateFile("ServerData\\PersonaData.db");
            SQLiteConnection.CreateFile("ServerData\\GarageData.db");

            SQLiteConnection m_dbConnection;

            m_dbConnection = new SQLiteConnection("Data Source=\"ServerData\\PersonaData.db\";Version=3;");
            m_dbConnection.Open();
            string sql = "create table personas (Id bigint, IconIndex smallint, Name varchar(14), Motto varchar(30), Level smallint, IGC int, Boost int, ReputationPercentage smallint, LevelReputation int, TotalReputation int, CurrentCarIndex int)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into personas (Id, IconIndex, Name, Motto, Level, IGC, Boost, ReputationPercentage, LevelReputation, TotalReputation, CurrentCarIndex) values (0, 27, 'Debug', 'Test Build', 69, 0, 0, 0, 0, 699, 1)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into personas (Id, IconIndex, Name, Motto, Level, IGC, Boost, ReputationPercentage, LevelReputation, TotalReputation, CurrentCarIndex) values (1, 26, 'DefaultProfile', 'Literally, the first.', 1, 25000, 1500, 0, 0, 0, 0)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
            m_dbConnection = new SQLiteConnection("Data Source=\"ServerData\\GarageData.db\";Version=3;");
            m_dbConnection.Open();
            sql = "create table Id0 (BaseCarId bigint, RaceClass int, ApId bigint, Paints longtext, PerformanceParts longtext, PhysicsProfileHash bigint, Rating int, ResalePrice int, SkillModParts longtext, Vinyls longtext, VisualParts longtext, Durability smallint, ExpirationDate text, HeatLevel smallint, Id int)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into Id0 (BaseCarId, RaceClass, ApId, Paints, PerformanceParts, PhysicsProfileHash, Rating, ResalePrice, SkillModParts, Vinyls, VisualParts, Durability, ExpirationDate, HeatLevel, Id) values (1816139026, -405837480, 1, "+
                "'<Paints><CustomPaintTrans><Group>-1480403439</Group><Hue>496032624</Hue><Sat>0</Sat><Slot>1</Slot><Var>76</Var></CustomPaintTrans><CustomPaintTrans><Group>-1480403439</Group><Hue>496032624</Hue><Sat>0</Sat><Slot>2</Slot><Var>76</Var></CustomPaintTrans><CustomPaintTrans><Group>595033610</Group><Hue>496032624</Hue><Sat>0</Sat><Slot>6</Slot><Var>254</Var></CustomPaintTrans><CustomPaintTrans><Group>595033610</Group><Hue>496032624</Hue><Sat>0</Sat><Slot>0</Slot><Var>254</Var></CustomPaintTrans><CustomPaintTrans><Group>595033610</Group><Hue>496032624</Hue><Sat>0</Sat><Slot>3</Slot><Var>254</Var></CustomPaintTrans><CustomPaintTrans><Group>595033610</Group><Hue>496032624</Hue><Sat>0</Sat><Slot>4</Slot><Var>254</Var></CustomPaintTrans><CustomPaintTrans><Group>595033610</Group><Hue>496032624</Hue><Sat>0</Sat><Slot>5</Slot><Var>254</Var></CustomPaintTrans></Paints>', "+
                "'<PerformanceParts><PerformancePartTrans><PerformancePartAttribHash>-1962598619</PerformancePartAttribHash></PerformancePartTrans><PerformancePartTrans><PerformancePartAttribHash>-183076819</PerformancePartAttribHash></PerformancePartTrans><PerformancePartTrans><PerformancePartAttribHash>7155944</PerformancePartAttribHash></PerformancePartTrans><PerformancePartTrans><PerformancePartAttribHash>754340312</PerformancePartAttribHash></PerformancePartTrans><PerformancePartTrans><PerformancePartAttribHash>1621862030</PerformancePartAttribHash></PerformancePartTrans><PerformancePartTrans><PerformancePartAttribHash>1727386028</PerformancePartAttribHash></PerformancePartTrans></PerformanceParts>', "+
                "-846723009, 708, 350000, "+
                "'<SkillModParts><SkillModPartTrans><IsFixed>false</IsFixed><SkillModPartAttribHash>-1196331958</SkillModPartAttribHash></SkillModPartTrans><SkillModPartTrans><IsFixed>false</IsFixed><SkillModPartAttribHash>-1012293684</SkillModPartAttribHash></SkillModPartTrans><SkillModPartTrans><IsFixed>false</IsFixed><SkillModPartAttribHash>-577002039</SkillModPartAttribHash></SkillModPartTrans><SkillModPartTrans><IsFixed>false</IsFixed><SkillModPartAttribHash>861531645</SkillModPartAttribHash></SkillModPartTrans><SkillModPartTrans><IsFixed>false</IsFixed><SkillModPartAttribHash>917249206</SkillModPartAttribHash></SkillModPartTrans></SkillModParts>', "+
                "'<Vinyls><CustomVinylTrans><Hash>-883491363</Hash><Hue1>-799662319</Hue1><Hue2>-799662186</Hue2><Hue3>-799662452</Hue3><Hue4>-799662452</Hue4><Layer>0</Layer><Mir>true</Mir><Rot>128</Rot><Sat1>0</Sat1><Sat2>0</Sat2><Sat3>0</Sat3><Sat4>0</Sat4><ScaleX>7162</ScaleX><ScaleY>11595</ScaleY><Shear>0</Shear><TranX>2</TranX><TranY>327</TranY><Var1>204</Var1><Var2>0</Var2><Var3>0</Var3><Var4>0</Var4></CustomVinylTrans><CustomVinylTrans><Hash>-1282944374</Hash><Hue1>-799662156</Hue1><Hue2>-799662354</Hue2><Hue3>-799662385</Hue3><Hue4>-799662385</Hue4><Layer>1</Layer><Mir>true</Mir><Rot>60</Rot><Sat1>0</Sat1><Sat2>0</Sat2><Sat3>0</Sat3><Sat4>0</Sat4><ScaleX>735</ScaleX><ScaleY>1063</ScaleY><Shear>0</Shear><TranX>-52</TranX><TranY>268</TranY><Var1>255</Var1><Var2>0</Var2><Var3>0</Var3><Var4>0</Var4></CustomVinylTrans></Vinyls>', "+
                "'<VisualParts><VisualPartTrans><PartHash>-541305606</PartHash><SlotHash>1694991</SlotHash></VisualPartTrans><VisualPartTrans><PartHash>-273819714</PartHash><SlotHash>-2126743923</SlotHash></VisualPartTrans><VisualPartTrans><PartHash>-48607787</PartHash><SlotHash>453545749</SlotHash></VisualPartTrans><VisualPartTrans><PartHash>948331475</PartHash><SlotHash>2106784967</SlotHash></VisualPartTrans></VisualParts>', "+
                "100, '2016-01-30T17:30:00.0000000+00:00', 1, 1)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            command.ExecuteNonQuery();
            command.ExecuteNonQuery(); // 3 cars
            sql = "create table Id1 (BaseCarId bigint, RaceClass int, ApId bigint, Paints longtext, PerformanceParts longtext, PhysicsProfileHash bigint, Rating int, ResalePrice int, SkillModParts longtext, Vinyls longtext, VisualParts longtext, Durability smallint, ExpirationDate text, HeatLevel smallint, Id int)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            sql = "insert into Id1 (BaseCarId, RaceClass, ApId, Paints, PerformanceParts, PhysicsProfileHash, Rating, ResalePrice, SkillModParts, Vinyls, VisualParts, Durability, ExpirationDate, HeatLevel, Id) values (1816139026, -405837480, 2, " +
                "'<Paints><CustomPaintTrans><Group>-1480403439</Group><Hue>496032624</Hue><Sat>0</Sat><Slot>1</Slot><Var>76</Var></CustomPaintTrans><CustomPaintTrans><Group>-1480403439</Group><Hue>496032624</Hue><Sat>0</Sat><Slot>2</Slot><Var>76</Var></CustomPaintTrans><CustomPaintTrans><Group>595033610</Group><Hue>496032624</Hue><Sat>0</Sat><Slot>6</Slot><Var>254</Var></CustomPaintTrans><CustomPaintTrans><Group>595033610</Group><Hue>496032624</Hue><Sat>0</Sat><Slot>0</Slot><Var>254</Var></CustomPaintTrans><CustomPaintTrans><Group>595033610</Group><Hue>496032624</Hue><Sat>0</Sat><Slot>3</Slot><Var>254</Var></CustomPaintTrans><CustomPaintTrans><Group>595033610</Group><Hue>496032624</Hue><Sat>0</Sat><Slot>4</Slot><Var>254</Var></CustomPaintTrans><CustomPaintTrans><Group>595033610</Group><Hue>496032624</Hue><Sat>0</Sat><Slot>5</Slot><Var>254</Var></CustomPaintTrans></Paints>', " +
                "'<PerformanceParts><PerformancePartTrans><PerformancePartAttribHash>-1962598619</PerformancePartAttribHash></PerformancePartTrans><PerformancePartTrans><PerformancePartAttribHash>-183076819</PerformancePartAttribHash></PerformancePartTrans><PerformancePartTrans><PerformancePartAttribHash>7155944</PerformancePartAttribHash></PerformancePartTrans><PerformancePartTrans><PerformancePartAttribHash>754340312</PerformancePartAttribHash></PerformancePartTrans><PerformancePartTrans><PerformancePartAttribHash>1621862030</PerformancePartAttribHash></PerformancePartTrans><PerformancePartTrans><PerformancePartAttribHash>1727386028</PerformancePartAttribHash></PerformancePartTrans></PerformanceParts>', " +
                "-846723009, 708, 350000, " +
                "'<SkillModParts><SkillModPartTrans><IsFixed>false</IsFixed><SkillModPartAttribHash>-1196331958</SkillModPartAttribHash></SkillModPartTrans><SkillModPartTrans><IsFixed>false</IsFixed><SkillModPartAttribHash>-1012293684</SkillModPartAttribHash></SkillModPartTrans><SkillModPartTrans><IsFixed>false</IsFixed><SkillModPartAttribHash>-577002039</SkillModPartAttribHash></SkillModPartTrans><SkillModPartTrans><IsFixed>false</IsFixed><SkillModPartAttribHash>861531645</SkillModPartAttribHash></SkillModPartTrans><SkillModPartTrans><IsFixed>false</IsFixed><SkillModPartAttribHash>917249206</SkillModPartAttribHash></SkillModPartTrans></SkillModParts>', " +
                "'<Vinyls><CustomVinylTrans><Hash>-883491363</Hash><Hue1>-799662319</Hue1><Hue2>-799662186</Hue2><Hue3>-799662452</Hue3><Hue4>-799662452</Hue4><Layer>0</Layer><Mir>true</Mir><Rot>128</Rot><Sat1>0</Sat1><Sat2>0</Sat2><Sat3>0</Sat3><Sat4>0</Sat4><ScaleX>7162</ScaleX><ScaleY>11595</ScaleY><Shear>0</Shear><TranX>2</TranX><TranY>327</TranY><Var1>204</Var1><Var2>0</Var2><Var3>0</Var3><Var4>0</Var4></CustomVinylTrans><CustomVinylTrans><Hash>-1282944374</Hash><Hue1>-799662156</Hue1><Hue2>-799662354</Hue2><Hue3>-799662385</Hue3><Hue4>-799662385</Hue4><Layer>1</Layer><Mir>true</Mir><Rot>60</Rot><Sat1>0</Sat1><Sat2>0</Sat2><Sat3>0</Sat3><Sat4>0</Sat4><ScaleX>735</ScaleX><ScaleY>1063</ScaleY><Shear>0</Shear><TranX>-52</TranX><TranY>268</TranY><Var1>255</Var1><Var2>0</Var2><Var3>0</Var3><Var4>0</Var4></CustomVinylTrans></Vinyls>', " +
                "'<VisualParts><VisualPartTrans><PartHash>-541305606</PartHash><SlotHash>1694991</SlotHash></VisualPartTrans><VisualPartTrans><PartHash>-273819714</PartHash><SlotHash>-2126743923</SlotHash></VisualPartTrans><VisualPartTrans><PartHash>-48607787</PartHash><SlotHash>453545749</SlotHash></VisualPartTrans><VisualPartTrans><PartHash>948331475</PartHash><SlotHash>2106784967</SlotHash></VisualPartTrans></VisualParts>', " +
                "100, 'null', 1, 2)";
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
                Path = new PropertyPath("ActivePersona.AvatarIndex"),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                Mode = BindingMode.TwoWay,
                Source = Access.CurrentSession
            };
            FlipViewPersonaImage.SelectedIndex = Access.CurrentSession.ActivePersona.AvatarIndex;
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
            DockPanel dNewInfoContent = Access.CurrentSession.mEngine.mAchievements.GenerateNewAchievement();
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
                    /* Cheeky little trick to restart timer */ RandomPersonaInfo.Stop(); /* -> */ RandomPersonaInfo.Start();
                    tRandomPersonaInfo_Tick(null, null);
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
            Access.sHttp.nServer.Stop();
            Access.sHttp.nServer.Dispose();
            // https://github.com/foxglovesec/Potato/blob/master/source/NHttp/NHttp/HttpServer.cs#L261

            NfswSession.dbCarsConnection.Close();
            NfswSession.dbCarsConnection.Dispose();

            NfswSession.dbConnection.Close();
            NfswSession.dbConnection.Dispose();
        }
    }
}