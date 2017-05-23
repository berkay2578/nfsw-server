using OfflineServer.Servers.Http.Responses;
using System;
using static OfflineServer.AchievementDefinitions;

namespace OfflineServer.Servers.Http.Classes
{
    public static class Achievements
    {
        public static String loadall()
        {
            AchievementsPacket achievementsPacket = new AchievementsPacket();
            foreach (AchievementDefinition achievementDefinition in AchievementDefinitions.achievements.Values)
            {
                achievementsPacket.badges.Add(achievementDefinition.badgeDefinition);
                achievementsPacket.definitions.Add(achievementDefinition.achievementDefinition);
            }

            return achievementsPacket.SerializeObject();
        }
    }
}
