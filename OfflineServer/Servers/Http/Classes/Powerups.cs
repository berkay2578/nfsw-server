using OfflineServer.Servers.Xmpp.Responses;
using System;
using System.Collections.Generic;

namespace OfflineServer.Servers.Http.Classes
{
    public static class Powerups
    {
        public static readonly Dictionary<String, Int32> powerupHashes = new Dictionary<String, Int32>()
        {
            {"nos", -1681514783},
            {"juggernaut", 1805681994},
            {"ready", 957701799}
        };

        public static String activated()
        {
            Int64 powerupHash = Int64.Parse(Access.sHttp.request.Path.Split('/')[4]);
            PowerupActivated powerupActivated = new PowerupActivated();
            powerupActivated.id = powerupHash;
            powerupActivated.targetPersonaId = Int32.Parse(Access.sHttp.request.Params.Get("targetId"));
            powerupActivated.personaId = Access.CurrentSession.ActivePersona.Id;

            PowerupActivatedResponse powerupActivatedResponse = new PowerupActivatedResponse();
            powerupActivatedResponse.powerupActivated = powerupActivated;

            Message message = new Message();
            message.setBody(powerupActivatedResponse);

#pragma warning disable CS4014
            object threadSafeDummy = new object();
            lock (threadSafeDummy)
            {
                // Send powerup activation data to game
                Access.sXmpp.write(message.SerializeObject(true));
            }
#if DEBUG
            lock (threadSafeDummy)
            {
                if ((Int32)powerupHash == powerupHashes["nos"])
                {
                    message = new Message();

                    // Debug, only for showing achievement display
                    // Will cause the game to crash if achievements/loadall was empty.
                    AchievementAwarded achievementAwarded = new AchievementAwarded();
                    var acDef = AchievementDefinitions.achievements["ACH_USE_NOS"];
                    achievementAwarded.achievementDefinitionId = acDef.achievementDefinition.achievementDefinitionId;
                    achievementAwarded.achievementRankId = acDef.achievementDefinition.achievementRanks[0].achievementRankId;
                    achievementAwarded.description = acDef.badgeDefinition.description;
                    achievementAwarded.icon = acDef.badgeDefinition.icon;
                    achievementAwarded.isRare = acDef.achievementDefinition.achievementRanks[0].isRare;
                    achievementAwarded.name = acDef.badgeDefinition.name;
                    achievementAwarded.points = acDef.achievementDefinition.achievementRanks[0].points;
                    achievementAwarded.rarity = acDef.achievementDefinition.achievementRanks[0].rarity;

                    AchievementProgress achievementProgress = new AchievementProgress();
                    achievementProgress.achievementDefinitionId = acDef.achievementDefinition.achievementDefinitionId;
                    achievementProgress.currentValue = 1;

                    AchievementsAwarded achievementsAwarded = new AchievementsAwarded();
                    achievementsAwarded.achievements.Add(achievementAwarded);
                    achievementsAwarded.score = Access.CurrentSession.ActivePersona.score;

                    message.setBody(achievementsAwarded);
                    Access.sXmpp.write(message.SerializeObject(true));
                }
            }
#endif
#pragma warning restore CS4014

            return "";
        }
    }
}