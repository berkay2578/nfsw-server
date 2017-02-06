using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("DragArbitrationPacket", Namespace = "http://schemas.datacontract.org/2004/07/Victory.Service.Objects")]
    public class DragArbitrationPacket : ArbitrationPacket
    {
        [XmlElement("FractionCompleted")]
        public float fractionCompleted;
        [XmlElement("LongestJumpDurationInMilliseconds")]
        public UInt32 longestJumpDurationInMilliseconds;
        [XmlElement("NumberOfCollisions")]
        public Int32 numberOfCollisions;
        [XmlElement("PerfectStart")]
        public Int32 perfectStart;
        [XmlElement("SumOfJumpsDurationInMilliseconds")]
        public UInt32 sumOfJumpsDurationInMilliseconds;
        [XmlElement("TopSpeed")]
        public float topSpeed;

        public override Reward calculateBaseReward(EventDefinition eventDefinition)
        {
            if (rank > 3)
            {
                return new Reward()
                {
                    rep = 0,
                    tokens = 100
                };
            }
            else
            {
                Int32 level = Access.CurrentSession.ActivePersona.Level;
                Boolean repLimited = level >= Data.DataEx.maxLevel;
                Int32 rankMultiplier = Math.Max(1, (eventDefinition.maxEntrants / (2 * rank)) * 2);

                return new Reward()
                {
                    rep = repLimited ? 0 : ((rankMultiplier * level * 2) +
                    (Access.CurrentSession.ActivePersona.ReputationRequiredToPassTheLevel / ((rank + 1) * 200))) * 5,
                    tokens = rankMultiplier * 100 * level
                };
            }
        }

        public override List<RewardPart> calculateRewardParts(EventDefinition eventDefinition, out int finalExp, out int finalCash)
        {
            List<RewardPart> rewardParts = new List<RewardPart>();
            Int32 level = Access.CurrentSession.ActivePersona.Level;
            Boolean repLimited = level >= Data.DataEx.maxLevel;
            finalExp = 0;
            finalCash = 0;

            // Base reward
            Reward baseReward = calculateBaseReward(eventDefinition);
            rewardParts.Add(new RewardPart()
            {
                repPart = baseReward.rep,
                rewardCategory = rank > 3 ? RewardCategory.Objective : RewardCategory.Rank,
                rewardType = rank > 3 ? RewardType.Finished : RewardType.None,
                tokenPart = baseReward.tokens
            });

            // Perfect start bonus
            if (perfectStart == 1)
            {
                rewardParts.Add(new RewardPart()
                {
                    repPart = repLimited ? 0 : 500 * level,
                    rewardCategory = RewardCategory.Bonus,
                    rewardType = RewardType.PowerupBonus,
                    tokenPart = 600 * level
                });
            }

            if (numberOfCollisions > 0)
            {
                // Collision penalty
                rewardParts.Add(new RewardPart()
                {
                    repPart = repLimited ? 0 : numberOfCollisions * level * -75,
                    rewardCategory = RewardCategory.Base,
                    rewardType = RewardType.Infractions,
                    tokenPart = numberOfCollisions * level * -300
                });
            }
            else
            {
                // No collision bonus
                rewardParts.Add(new RewardPart()
                {
                    repPart = repLimited ? 0 : 500 * level,
                    rewardCategory = RewardCategory.Base,
                    rewardType = RewardType.Infractions,
                    tokenPart = 600 * level
                });
            }

            foreach (RewardPart rewardPart in rewardParts)
            {
                finalExp += rewardPart.repPart;
                finalCash += rewardPart.tokenPart;
            }

            return rewardParts;
        }

        public override EntrantResult getEntrantResult()
        {
            DragEntrantResult entrantResult = new DragEntrantResult();
            entrantResult.eventDurationInMilliseconds = eventDurationInMilliseconds;
            entrantResult.eventSessionId = Access.CurrentSession.ActivePersona.currentEventSessionId;
            entrantResult.finishReason = finishReason;
            entrantResult.personaId = Access.CurrentSession.ActivePersona.Id;
            entrantResult.ranking = rank;
            entrantResult.topSpeed = topSpeed;

            return entrantResult;
        }
    }
}
