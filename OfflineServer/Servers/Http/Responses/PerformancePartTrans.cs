using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("PerformancePartTrans")]
    public class PerformancePartTrans
    {
        [XmlElement("PerformancePartAttribHash")]
        public Int32 performancePartAttribHash;
    }
}
