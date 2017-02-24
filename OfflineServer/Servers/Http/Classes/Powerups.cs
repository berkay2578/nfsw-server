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
            lock (threadSafeDummy)
            {
                if ((Int32)powerupHash == powerupHashes["nos"])
                {
                    message = new Message();

                    // Debug, only for showing achievement display
                    // Will cause the game to crash if achievements/loadall was empty.
                    AchievementAwarded achievementAwarded = new AchievementAwarded();
                    achievementAwarded.achievementDefinitionId = 96;
                    achievementAwarded.achievementRankId = 309;
                    achievementAwarded.description = "GM_ACHIEVEMENT_0000026E";
                    achievementAwarded.icon = "ACH_USE_NOS";
                    achievementAwarded.isRare = true;
                    achievementAwarded.name = "GM_ACHIEVEMENT_0000010C";
                    achievementAwarded.points = 10;
                    achievementAwarded.rarity = 1f;

                    AchievementsAwarded achievementsAwarded = new AchievementsAwarded();
                    achievementsAwarded.achievements.Add(achievementAwarded);
                    achievementsAwarded.score = 0;

                    message.setBody(achievementsAwarded);
                    Access.sXmpp.write(message.SerializeObject(true));
                }
            }

#pragma warning restore CS4014

            return "";
        }
    }
}