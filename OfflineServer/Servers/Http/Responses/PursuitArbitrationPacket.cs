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

        public override Reward calculateBaseReward()
        {
            throw new NotImplementedException();
        }

        public override List<RewardPart> calculateRewardParts(out int finalExp, out int finalCash)
        {
            throw new NotImplementedException();
        }

        public override EntrantResult getEntrantResult()
        {
            throw new NotImplementedException();
        }
    }
}
