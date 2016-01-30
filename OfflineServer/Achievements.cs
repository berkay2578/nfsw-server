using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OfflineServer
{
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
}