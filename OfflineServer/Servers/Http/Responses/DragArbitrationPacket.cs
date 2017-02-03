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
