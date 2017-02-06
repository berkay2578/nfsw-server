using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("RouteArbitrationPacket", Namespace = "http://schemas.datacontract.org/2004/07/Victory.Service.Objects")]
    public class RouteArbitrationPacket : ArbitrationPacket
    {
        [XmlElement("BestLapDurationInMilliseconds")]
        public UInt32 bestLapDurationInMilliseconds;
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
                    tokens = 1000
                };
            }
            else
            {
                Int32 level = Access.CurrentSession.ActivePersona.Level;
                Boolean repLimited = level >= Data.DataEx.maxLevel;
                Int32 rankMultiplier = Math.Max(1, (eventDefinition.maxEntrants / (2 * rank)) * 2);
                Int32 laps = Math.Max(1, eventDefinition.laps);

                return new Reward()
                {
                    rep = repLimited ? 0 : ((rankMultiplier * level * (2 + laps)) +
                    (Access.CurrentSession.ActivePersona.ReputationRequiredToPassTheLevel / ((rank + 1) * 100))) * 10,
                    tokens = rankMultiplier * level * (250 + laps)
                };
            }
        }
        public override List<RewardPart> calculateRewardParts(EventDefinition eventDefinition, out Int32 finalExp, out Int32 finalCash)
        {
            List<RewardPart> rewardParts = new List<RewardPart>();
            Int32 level = Access.CurrentSession.ActivePersona.Level;
            Boolean repLimited = level >= Data.DataEx.maxLevel;
            Int32 laps = Math.Max(1, eventDefinition.laps);
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
                    repPart = repLimited ? 0 : 300 * level,
                    rewardCategory = RewardCategory.Bonus,
                    rewardType = RewardType.PowerupBonus,
                    tokenPart = 400 * level
                });
            }

            if (numberOfCollisions > 0)
            {
                // Collision penalty
                rewardParts.Add(new RewardPart()
                {
                    repPart = repLimited ? 0 : numberOfCollisions * ((-10 + laps) * 3) * level,
                    rewardCategory = RewardCategory.Base,
                    rewardType = RewardType.Infractions,
                    tokenPart = numberOfCollisions * ((-25 + laps) * 6) * level
                });
            }
            else
            {
                // No collision bonus
                rewardParts.Add(new RewardPart()
                {
                    repPart = repLimited ? 0 : 500 * level * laps,
                    rewardCategory = RewardCategory.Base,
                    rewardType = RewardType.Infractions,
                    tokenPart = 600 * level * laps
                });
            }

            if (laps > 1)
            {
                // Best lap time better than third of the circuit race time
                // Second check is to block any abuse; e.g. Doing a lap in a minute and roaming for 2 minutes
                if (bestLapDurationInMilliseconds < eventDurationInMilliseconds / 3 &&
                    bestLapDurationInMilliseconds * laps > eventDurationInMilliseconds - bestLapDurationInMilliseconds)
                {
                    rewardParts.Add(new RewardPart()
                    {
                        repPart = 2 * Access.CurrentSession.ActivePersona.ReputationRequiredToPassTheLevel / 100,
                        rewardCategory = RewardCategory.Bonus,
                        rewardType = RewardType.TimeBonus,
                        tokenPart = 2000 * Access.CurrentSession.ActivePersona.Level
                    });
                }
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
            RouteEntrantResult entrantResult = new RouteEntrantResult();
            entrantResult.bestLapDurationInMilliseconds = bestLapDurationInMilliseconds;
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
