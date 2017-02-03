using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    public class RewardPart
    {
        [XmlElement("RepPart")]
        public Int32 repPart;
        [XmlElement("RewardCategory")]
        public RewardCategory rewardCategory;
        [XmlElement("RewardType")]
        public RewardType rewardType;
        [XmlElement("TokenPart")]
        public Int32 tokenPart;
    }

    [Serializable()]
    public enum RewardCategory
    {
        [XmlEnum("Base")]
        Base,
        [XmlEnum("Rank")]
        Rank,
        [XmlEnum("Bonus")]
        Bonus,
        [XmlEnum("TeamBonus")]
        TeamBonus,
        [XmlEnum("Amplifier")]
        Amplifier,
        [XmlEnum("Skill")]
        Skill,
        [XmlEnum("Pursuit")]
        Pursuit,
        [XmlEnum("Objective")]
        Objective,
        [XmlEnum("SkillMod")]
        SkillMod,
    }
    [Serializable()]
    public enum RewardType
    {
        [XmlEnum("None")]
        None,
        [XmlEnum("Busted")]
        Busted,
        [XmlEnum("Evaded")]
        Evaded,
        [XmlEnum("RepAmplifier")]
        RepAmplifier,
        [XmlEnum("TokenAmplifier")]
        TokenAmplifier,
        [XmlEnum("SkillMostWanted")]
        SkillMostWanted,
        [XmlEnum("SkillSocialite")]
        SkillSocialite,
        [XmlEnum("SkillTycoon")]
        SkillTycoon,
        [XmlEnum("SkillTerminator")]
        SkillTerminator,
        [XmlEnum("HeatLevel")]
        HeatLevel,
        [XmlEnum("PursuitLength")]
        PursuitLength,
        [XmlEnum("Bounty")]
        Bounty,
        [XmlEnum("CopCarsDeployed")]
        CopCarsDeployed,
        [XmlEnum("CopCarsRammed")]
        CopCarsRammed,
        [XmlEnum("CopCarsDisabled")]
        CopCarsDisabled,
        [XmlEnum("RhinosDisabled")]
        RhinosDisabled,
        [XmlEnum("CostToState")]
        CostToState,
        [XmlEnum("RoadblocksDodged")]
        RoadblocksDodged,
        [XmlEnum("SpikeStripsDodged")]
        SpikeStripsDodged,
        [XmlEnum("Infractions")]
        Infractions,
        [XmlEnum("LevelCap")]
        LevelCap,
        [XmlEnum("EntitlementLevelCap")]
        EntitlementLevelCap,
        [XmlEnum("TopenCap")]
        TopenCap,
        [XmlEnum("SafehouseReached")]
        SafehouseReached,
        [XmlEnum("Finished")]
        Finished,
        [XmlEnum("TimeBonus")]
        TimeBonus,
        [XmlEnum("Player1")]
        Player1,
        [XmlEnum("Player2")]
        Player2,
        [XmlEnum("Player3")]
        Player3,
        [XmlEnum("Player4")]
        Player4,
        [XmlEnum("StrikeFree")]
        StrikeFree,
        [XmlEnum("TeamStrikeBonus")]
        TeamStrikeBonus,
        [XmlEnum("PowerupBonus")]
        PowerupBonus,
        [XmlEnum("SkillMod")]
        SkillMod,
    }
}
