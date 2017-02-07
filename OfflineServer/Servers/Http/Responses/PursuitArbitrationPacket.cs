using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("PursuitArbitrationPacket", Namespace = "http://schemas.datacontract.org/2004/07/Victory.Service.Objects")]
    public class PursuitArbitrationPacket : ArbitrationPacket
    {
        [XmlElement("CopsDeployed")]
        public Int32 copsDeployed;
        [XmlElement("CopsDisabled")]
        public Int32 copsDisabled;
        [XmlElement("CopsRammed")]
        public Int32 copsRammed;
        [XmlElement("CostToState")]
        public Int32 costToState;
        [XmlElement("Heat")]
        public float heat;
        [XmlElement("Infractions")]
        public Int32 infractions;
        [XmlElement("LongestJumpDurationInMilliseconds")]
        public UInt32 longestJumpDurationInMilliseconds;
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

            return new Reward()
            {
                rep = repLimited ? 0 : ((rankMultiplier * level) +
                (Access.CurrentSession.ActivePersona.ReputationRequiredToPassTheLevel / ((rank + 1) * 125))) * 8,
                tokens = rankMultiplier * level * 300
            };
        }
        public override List<RewardPart> calculateRewardParts(EventDefinition eventDefinition, out Int32 finalExp, out Int32 finalCash)
        {
            List<RewardPart> rewardParts = new List<RewardPart>();
            Int32 level = Access.CurrentSession.ActivePersona.Level;
            Boolean repLimited = level >= Data.DataEx.maxLevel;
            float carHeat = Access.CurrentSession.ActivePersona.SelectedCar.HeatLevel;
            Int32 rankMultiplier = 5;
            finalExp = 0;
            finalCash = 0;

            // Base reward
            Reward baseReward = calculateBaseReward(eventDefinition);
            rewardParts.Add(new RewardPart()
            {
                repPart = baseReward.rep,
                rewardCategory = RewardCategory.Pursuit,
                rewardType = RewardType.Evaded,
                tokenPart = baseReward.tokens
            });

            // Bonus for CopsDeployed
            rewardParts.Add(new RewardPart()
            {
                repPart = copsDeployed * level * 10,
                rewardCategory = RewardCategory.Pursuit,
                rewardType = RewardType.CopCarsDeployed,
                tokenPart = copsDeployed * level * 25
            });

            // Bonus for CopsDisabled
            rewardParts.Add(new RewardPart()
            {
                repPart = ((copsDeployed / copsDisabled) * 100) * level * 2,
                rewardCategory = RewardCategory.Pursuit,
                rewardType = RewardType.CopCarsDisabled,
                tokenPart = ((copsDeployed / copsDisabled) * 100) * level * 4
            });

            // Bonus for CopsRammed
            rewardParts.Add(new RewardPart()
            {
                repPart = (copsRammed * 100) + copsDisabled > 0 ? copsDisabled * 50 : 0,
                rewardCategory = RewardCategory.Pursuit,
                rewardType = RewardType.CopCarsRammed,
                tokenPart = (copsRammed * 250) + copsDisabled > 0 ? copsDisabled * 100 : 0
            });

            // Bonus for CostToState
            rewardParts.Add(new RewardPart()
            {
                repPart = (costToState / 100) * (level / 4),
                rewardCategory = RewardCategory.Pursuit,
                rewardType = RewardType.CostToState,
                tokenPart = (costToState / 100) * (level / 2)
            });

            // Bonus for heat increase
            if (heat > carHeat)
            {
                rewardParts.Add(new RewardPart()
                {
                    repPart = (Int32)Math.Round(((heat / carHeat) * 100) * rankMultiplier * level * 2),
                    rewardCategory = RewardCategory.Pursuit,
                    rewardType = RewardType.HeatLevel,
                    tokenPart = (Int32)Math.Round(((heat / carHeat) * 100) * rankMultiplier * level * 3)
                });
            }

            // Bonus for Infractions
            rewardParts.Add(new RewardPart()
            {
                repPart = infractions * (level / 2),
                rewardCategory = RewardCategory.Pursuit,
                rewardType = RewardType.Infractions,
                tokenPart = infractions * level
            });

            // Bonus for PursuitLength
            TimeSpan pursuitLength = TimeSpan.FromMilliseconds(eventDurationInMilliseconds);
            rewardParts.Add(new RewardPart()
            {
                repPart = (Int32)Math.Round(Math.Pow(1.5f, Math.Max(1, pursuitLength.Minutes))) * level * 100,
                rewardCategory = RewardCategory.Pursuit,
                rewardType = RewardType.PursuitLength,
                tokenPart = (Int32)Math.Round(Math.Pow(2f, Math.Max(1, pursuitLength.Minutes))) * level * 100
            });

            // Bonus for RoadBlocksDodged
            rewardParts.Add(new RewardPart()
            {
                repPart = roadBlocksDodged * 30,
                rewardCategory = RewardCategory.Pursuit,
                rewardType = RewardType.RoadblocksDodged,
                tokenPart = roadBlocksDodged * 10
            });

            // Bonus for SpikeStripsDodged
            rewardParts.Add(new RewardPart()
            {
                repPart = spikeStripsDodged * 25,
                rewardCategory = RewardCategory.Pursuit,
                rewardType = RewardType.SpikeStripsDodged,
                tokenPart = spikeStripsDodged * 10
            });

            foreach (RewardPart rewardPart in rewardParts)
            {
                finalExp += rewardPart.repPart;
                finalCash += rewardPart.tokenPart;
            }

            return rewardParts;
        }
        public override EntrantResult getEntrantResult()
        {
            throw new NotImplementedException();
        }
    }
}
