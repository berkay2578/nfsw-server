using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OfflineServer
{
    public class Achievements
    {
        private Random rPseudo;
        private DockPanel dpAchievement;
        private ImageBrush bgAchievement;
        private TextBlock descAchievement;

        private static class tAchievement
        {
            public const Int32 treasureHunt = 1;
            public const Int32 farthestJumpDistance = 2;
        }

        public Achievements()
        {
            bgAchievement = new ImageBrush()
            {
                Stretch = Stretch.Fill
            };
            descAchievement = new TextBlock()
            {
                Text = "DEBUG PLACEHOLDER",
                Padding = new Thickness(6d),
                Background = new SolidColorBrush(Color.FromArgb(122, 0, 0, 0)),
                VerticalAlignment = VerticalAlignment.Bottom,
                TextTrimming = TextTrimming.CharacterEllipsis,
                Height = 30
            };
            DockPanel.SetDock(descAchievement, Dock.Bottom);

            dpAchievement = new DockPanel();
            dpAchievement.Background = bgAchievement;
            dpAchievement.Children.Add(descAchievement);

            rPseudo = new Random();
        }

        public DockPanel generateNewAchievement()
        {
            String sCurrentText = descAchievement.Text;
        reroll:

            rPseudo = new Random();
            switch (rPseudo.Next(1, 3))
            {
                case tAchievement.treasureHunt:
                    {
                        bgAchievement.ImageSource = (ImageSource)BitmapFrame.Create(new Uri("pack://application:,,,/OfflineServer;component/images/NFSW_Achievements/TreasureHuntStreak.png", UriKind.RelativeOrAbsolute));
                        descAchievement.Text = Access.dataAccess.appSettings.uiSettings.language.AchievementTreasureHunt; // PLACEHOLDER, mPersona->bIsTHBrokenForViewModel, mPersona->iTHStreak, TH class?
                        break;
                    }
                case tAchievement.farthestJumpDistance:
                    {
                        bgAchievement.ImageSource = (ImageSource)BitmapFrame.Create(new Uri("pack://application:,,,/OfflineServer;component/images/NFSW_Achievements/JumpDistance.png", UriKind.RelativeOrAbsolute));
                        descAchievement.Text = Access.dataAccess.appSettings.uiSettings.language.AchievementJumpDistance; // PLACEHOLDER, mEngine->API->JumpDistance, mmmph...
                        break;
                    }
            }
            if (descAchievement.Text.Equals(sCurrentText)) goto reroll;

            return dpAchievement;
        }
    }
}