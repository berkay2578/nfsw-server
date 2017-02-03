using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot(Namespace = "http://schemas.datacontract.org/2004/07/Victory.Service.Objects")]
    public abstract class ArbitrationPacket
    {
        [XmlElement("AlternateEventDurationInMilliseconds")]
        public UInt32 alternateEventDurationInMilliseconds;
        [XmlElement("CarId")]
        public Int64 carId;
        [XmlElement("EventDurationInMilliseconds")]
        public UInt32 eventDurationInMilliseconds;
        [XmlElement("FinishReason")]
        public FinishReason finishReason;
        [XmlElement("FraudDetectionInfo")]
        public FraudDetection fraudDetectionInfo;
        [XmlElement("HacksDetected")]
        public UInt32 hacksDetected = 0;
        [XmlElement("PhysicsMetrics")]
        public ClientPhysicsMetrics physicsMetrics;
        [XmlElement("Rank")]
        public Int32 rank;
        [XmlElement("Response")]
        public SecurityResponse response;

        public abstract Reward calculateBaseReward();
        public abstract List<RewardPart> calculateRewardParts(out Int32 finalExp, out Int32 finalCash);
        public abstract EntrantResult getEntrantResult();
    }

    [Serializable()]
    public enum FinishReason
    {
        [XmlEnum("0")]
        Unknown = 0,
        [XmlEnum("2")]
        Completed = 2,
        [XmlEnum("6")]
        Succeeded = 6,
        [XmlEnum("10")]
        DidNotFinish = 10,
        [XmlEnum("22")]
        CrossedFinish = 22,
        [XmlEnum("42")]
        KnockedOut = 42,
        [XmlEnum("74")]
        Totalled = 74,
        [XmlEnum("138")]
        EngineBlown = 138,
        [XmlEnum("266")]
        Busted = 266,
        [XmlEnum("518")]
        Evaded = 518,
        [XmlEnum("1030")]
        ChallengeCompleted = 1030,
        [XmlEnum("2058")]
        Disconnected = 2058,
        [XmlEnum("4106")]
        FalseStart = 4106,
        [XmlEnum("8202")]
        Aborted = 8202,
        [XmlEnum("16394")]
        TimedOut = 16394,
        [XmlEnum("32774")]
        TimeLimitExpired = 32774,
        [XmlEnum("65546")]
        PauseDetected = 65546,
        [XmlEnum("131082")]
        SpeedHacking = 131082,
        [XmlEnum("262154")]
        CodePatchDetected = 262154,
        [XmlEnum("524298")]
        BadVerifierResponse = 524298
    }
}
