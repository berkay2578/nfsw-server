using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("TeamEscapeArbitrationPacket", Namespace = "http://schemas.datacontract.org/2004/07/Victory.Service.Objects")]
    public class TeamEscapeArbitrationPacket : ArbitrationPacket
    {
        [XmlElement("BustedCount")]
        public Int32 bustedCount;
        [XmlElement("CopsDeployed")]
        public Int32 copsDeployed;
        [XmlElement("CopsDisabled")]
        public Int32 copsDisabled;
        [XmlElement("CopsRammed")]
        public Int32 copsRammed;
        [XmlElement("CostToState")]
        public Int32 costToState;
        [XmlElement("DistanceToFinish")]
        public float distanceToFinish;
        [XmlElement("FractionCompleted")]
        public float fractionCompleted;
        [XmlElement("Infractions")]
        public Int32 infractions;
        [XmlElement("LongestJumpDurationInMilliseconds")]
        public UInt32 longestJumpDurationInMilliseconds;
        [XmlElement("NumberOfCollisions")]
        public Int32 numberOfCollisions;
        [XmlElement("PerfectStart")]
        public Int32 perfectStart;
        [XmlElement("RoadBlocksDodged")]
        public Int32 roadBlocksDodged;
        [XmlElement("SpikeStripsDodged")]
        public Int32 spikeStripsDodged;
        [XmlElement("SumOfJumpsDurationInMilliseconds")]
        public UInt32 sumOfJumpsDurationInMilliseconds;
        [XmlElement("TopSpeed")]
        public float topSpeed;

        public override Reward calculateBaseReward(EventDefinition eventDefinition)
        {
            Int32 level = Access.CurrentSession.ActivePersona.Level;
            Boolean repLimited = level >= Data.DataEx.maxLevel;
            Int32 rankMultiplier = 5;

            if (finishReason == FinishReason.Busted)
            {
                return new Reward()
                {
                    rep = (rankMultiplier * level +
                    (Access.CurrentSession.ActivePersona.ReputationRequiredToPassTheLevel / 200)) * -1,
                    tokens = rankMultiplier * level * -500
                };
            }
            else
            {
                return new Reward()
                {
                    rep = repLimited ? 0 : ((rankMultiplier * level) +
                    (Access.CurrentSession.ActivePersona.ReputationRequiredToPassTheLevel / ((rank + 1) * 125))) * 12,
                    tokens = rankMultiplier * level * 600
                };
            }
        }
        public override List<RewardPart> calculateRewardParts(EventDefinition eventDefinition, out Int32 finalExp, out Int32 finalCash)
        {
            List<RewardPart> rewardParts = new List<RewardPart>();
            Int32 level = Access.CurrentSession.ActivePersona.Level;
            Boolean repLimited = level >= Data.DataEx.maxLevel;
            float carHeat = Access.CurrentSession.ActivePersona.SelectedCar.HeatLevel;
            finalExp = 0;
            finalCash = 0;

            // Base reward
            Reward baseReward = calculateBaseReward(eventDefinition);
            rewardParts.Add(new RewardPart()
            {
                repPart = baseReward.rep,
                rewardCategory = RewardCategory.Pursuit,
                rewardType = finishReason == FinishReason.Busted ? RewardType.Busted : RewardType.Evaded,
                tokenPart = baseReward.tokens
            });

            if (bustedCount > 0)
            {
                // Busted penalty
                rewardParts.Add(new RewardPart()
                {
                    repPart = bustedCount * level * -100,
                    rewardCategory = RewardCategory.Pursuit,
                    rewardType = RewardType.Busted,
                    tokenPart = bustedCount * level * -1000
                });
            }
            else
            {
                // No busted bonus
                rewardParts.Add(new RewardPart()
                {
                    repPart = repLimited ? 0 : 1000 * level,
                    rewardCategory = RewardCategory.Pursuit,
                    rewardType = RewardType.StrikeFree,
                    tokenPart = 1200 * level
                });
            }

            if (finishReason == FinishReason.Busted)
                goto final;

            // Bonus for CopsDeployed
            rewardParts.Add(new RewardPart()
            {
                repPart = copsDeployed * level * 5,
                rewardCategory = RewardCategory.Pursuit,
                rewardType = RewardType.CopCarsDeployed,
                tokenPart = copsDeployed * level * 10
            });

            // Bonus for CopsDisabled
            rewardParts.Add(new RewardPart()
            {
                repPart = ((copsDeployed / copsDisabled) * 100) * level * 4,
                rewardCategory = RewardCategory.Pursuit,
                rewardType = RewardType.CopCarsDisabled,
                tokenPart = ((copsDeployed / copsDisabled) * 100) * level * 8
            });

            // Bonus for CopsRammed
            rewardParts.Add(new RewardPart()
            {
                repPart = (copsRammed * 125) + copsDisabled > 0 ? copsDisabled * 100 : 0,
                rewardCategory = RewardCategory.Pursuit,
                rewardType = RewardType.CopCarsRammed,
                tokenPart = (copsRammed * 300) + copsDisabled > 0 ? copsDisabled * 200 : 0
            });

            // Bonus for CostToState
            rewardParts.Add(new RewardPart()
            {
                repPart = (costToState / 100) * (level / 4),
                rewardCategory = RewardCategory.Pursuit,
                rewardType = RewardType.CostToState,
                tokenPart = (costToState / 100) * (level / 2)
            });

            // Bonus for Infractions
            rewardParts.Add(new RewardPart()
            {
                repPart = infractions * level,
                rewardCategory = RewardCategory.Pursuit,
                rewardType = RewardType.Infractions,
                tokenPart = infractions * level * 2
            });

            // Bonus for RoadBlocksDodged
            rewardParts.Add(new RewardPart()
            {
                repPart = roadBlocksDodged * 35,
                rewardCategory = RewardCategory.Pursuit,
                rewardType = RewardType.RoadblocksDodged,
                tokenPart = roadBlocksDodged * 15
            });

            // Bonus for SpikeStripsDodged
            rewardParts.Add(new RewardPart()
            {
                repPart = spikeStripsDodged * 25,
                rewardCategory = RewardCategory.Pursuit,
                rewardType = RewardType.SpikeStripsDodged,
                tokenPart = spikeStripsDodged * 10
            });

        final:
            foreach (RewardPart rewardPart in rewardParts)
            {
                finalExp += rewardPart.repPart;
                finalCash += rewardPart.tokenPart;
            }

            return rewardParts;
        }
        public override EntrantResult getEntrantResult()
        {
            TeamEscapeEntrantResult entrantResult = new TeamEscapeEntrantResult();
            entrantResult.distanceToFinish = distanceToFinish;
            entrantResult.eventDurationInMilliseconds = eventDurationInMilliseconds;
            entrantResult.eventSessionId = Access.CurrentSession.ActivePersona.currentEventSessionId;
            entrantResult.finishReason = finishReason;
            entrantResult.fractionCompleted = fractionCompleted;
            entrantResult.personaId = Access.CurrentSession.ActivePersona.Id;
            entrantResult.ranking = rank;

            return entrantResult;
        }
    }
}
