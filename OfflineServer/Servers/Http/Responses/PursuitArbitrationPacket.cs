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

            if (finishReason == FinishReason.Busted)
            {
                rankMultiplier = 3;
                return new Reward()
                {
                    rep = (rankMultiplier * level +
                    (Access.CurrentSession.ActivePersona.ReputationRequiredToPassTheLevel / 350)) * -1,
                    tokens = rankMultiplier * level * -250
                };
            }
            else
            {
                return new Reward()
                {
                    rep = repLimited ? 0 : ((rankMultiplier * level) +
                    (Access.CurrentSession.ActivePersona.ReputationRequiredToPassTheLevel / 250)) * 8,
                    tokens = rankMultiplier * level * 300
                };
            }

        }
        public override List<RewardPart> calculateRewardParts(EventDefinition eventDefinition, out Int32 finalExp, out Int32 finalCash)
        {
            List<RewardPart> rewardParts = new List<RewardPart>();
            Int32 level = Access.CurrentSession.ActivePersona.Level;
            Boolean repLimited = level >= Data.DataEx.maxLevel;
            float carHeat = Access.CurrentSession.ActivePersona.SelectedCar.HeatLevel;
            Int32 rankMultiplier = 5 - finishReason == FinishReason.Busted ? 3 : 0;
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

            // Bonus for CopsDeployed
            if (copsDeployed > 0)
            {
                rewardParts.Add(new RewardPart()
                {
                    repPart = copsDeployed * level * rankMultiplier * 2,
                    rewardCategory = RewardCategory.Pursuit,
                    rewardType = RewardType.CopCarsDeployed,
                    tokenPart = copsDeployed * level * rankMultiplier * 5
                });

                // Bonus for CopsDisabled
                if (copsDisabled > 0)
                {
                    rewardParts.Add(new RewardPart()
                    {
                        repPart = ((copsDeployed / copsDisabled) * 100) * level * rankMultiplier,
                        rewardCategory = RewardCategory.Pursuit,
                        rewardType = RewardType.CopCarsDisabled,
                        tokenPart = ((copsDeployed / copsDisabled) * 100) * level * rankMultiplier * 2
                    });
                }

                // Bonus for CopsRammed
                if (copsRammed > 0)
                {
                    rewardParts.Add(new RewardPart()
                    {
                        repPart = (copsRammed * rankMultiplier * 10) + copsDisabled,
                        rewardCategory = RewardCategory.Pursuit,
                        rewardType = RewardType.CopCarsRammed,
                        tokenPart = (copsRammed * rankMultiplier * 50) + copsDisabled
                    });
                }
            }

            // Bonus for CostToState
            if (costToState > 0)
            {
                rewardParts.Add(new RewardPart()
                {
                    repPart = (costToState / 100) * (level / (9 - rankMultiplier)),
                    rewardCategory = RewardCategory.Pursuit,
                    rewardType = RewardType.CostToState,
                    tokenPart = (costToState / 100) * (level / (7 - rankMultiplier))
                });
            }

            // Bonus for heat increase
            if (heat > carHeat && carHeat > 0f)
            {
                rewardParts.Add(new RewardPart()
                {
                    repPart = (Int32)Math.Round(((heat / carHeat) * 100f) * rankMultiplier * level * 2),
                    rewardCategory = RewardCategory.Pursuit,
                    rewardType = RewardType.HeatLevel,
                    tokenPart = (Int32)Math.Round(((heat / carHeat) * 100f) * rankMultiplier * level * 3)
                });
            }

            // Bonus for Infractions
            if (infractions > 0)
            {
                rewardParts.Add(new RewardPart()
                {
                    repPart = infractions * (level / 2),
                    rewardCategory = RewardCategory.Pursuit,
                    rewardType = RewardType.Infractions,
                    tokenPart = infractions * level
                });
            }

            // Bonus for PursuitLength
            TimeSpan pursuitLength = TimeSpan.FromMilliseconds(eventDurationInMilliseconds);
            rewardParts.Add(new RewardPart()
            {
                repPart = (Int32)Math.Round(Math.Pow(1.5f, Math.Max(1, pursuitLength.Minutes))) * level * rankMultiplier * 20,
                rewardCategory = RewardCategory.Pursuit,
                rewardType = RewardType.PursuitLength,
                tokenPart = (Int32)Math.Round(Math.Pow(2f, Math.Max(1, pursuitLength.Minutes))) * level * rankMultiplier * 35
            });

            // Bonus for RoadBlocksDodged
            if (roadBlocksDodged > 0)
            {
                rewardParts.Add(new RewardPart()
                {
                    repPart = roadBlocksDodged * rankMultiplier * 6,
                    rewardCategory = RewardCategory.Pursuit,
                    rewardType = RewardType.RoadblocksDodged,
                    tokenPart = roadBlocksDodged * rankMultiplier * 2
                });
            }

            // Bonus for SpikeStripsDodged
            if (spikeStripsDodged > 0)
            {
                rewardParts.Add(new RewardPart()
                {
                    repPart = spikeStripsDodged * rankMultiplier * 5,
                    rewardCategory = RewardCategory.Pursuit,
                    rewardType = RewardType.SpikeStripsDodged,
                    tokenPart = spikeStripsDodged * rankMultiplier * 2
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
            throw new NotImplementedException();
        }
    }
}
