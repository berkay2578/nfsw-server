using OfflineServer.Servers.Database;
using OfflineServer.Servers.Database.Entities;
using OfflineServer.Servers.Database.Management;
using OfflineServer.Servers.Http.Responses;
using OfflineServer.Servers.Xmpp.Responses;
using System;
using System.Linq;

namespace OfflineServer.Servers.Http.Classes
{
    public static class Powerups
    {
        public static readonly String[] powerups = new String[]
        {
            "runflattires",
            "trafficmagnet",
            "instantcooldown",
            "shield",
            "slingshot",
            "ready",
            "juggernaut",
            "emergencyevade",
            "team_emergencyevade",
            "nosshot",
            "onemorelap",
            "team_slingshot"
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
                InventoryItemEntity entity = PersonaManagement.persona.inventory.FirstOrDefault(ii => ii.hash == (Int32)powerupHash);
                if (entity != null)
                {
                    entity = InventoryItemManagement.getInventoryItemEntity(entity.id);
                    entity.remainingUseCount -= 1;
                    entity.setInventoryItemEntity();
                }

                // Send powerup activation data to game
                Access.sXmpp.write(message.SerializeObject(true));
            }
#if DEBUG
            lock (threadSafeDummy)
            {
                if ((Int32)powerupHash == Engine.getOverflowHash("nosshot"))
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

        public static void addPowerupsToPersona(Int32 personaId)
        {
            using (var session = SessionManager.getSessionFactory().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                PersonaEntity personaEntity = session.Load<PersonaEntity>(personaId);
                foreach (String powerup in powerups)
                {
                    InventoryItemEntity itemEntity = new InventoryItemEntity();
                    itemEntity.entitlementTag = powerup;
                    itemEntity.hash = Engine.getOverflowHash(powerup);
                    itemEntity.productId = "DO NOT USE ME";
                    itemEntity.status = "ACTIVE";
                    itemEntity.stringHash = "0x" + Engine.getHexHash(powerup);
                    itemEntity.remainingUseCount = 50;
                    itemEntity.resellPrice = 0;
                    itemEntity.virtualItemType = VirtualItemType.powerup;

                    personaEntity.addInventoryItem(itemEntity);
                    session.Save(itemEntity);
                    session.Update(personaEntity);
                }
                transaction.Commit();
            }
        }
    }
}