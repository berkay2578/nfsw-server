using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("CustomVinylTrans")]
    public class CustomVinylTrans
    {
        [XmlElement("Hash", Order = 1)]
        public Int32 hash;
        [XmlElement("Hue1", Order = 2)]
        public Int32 hue1;
        [XmlElement("Hue2", Order = 3)]
        public Int32 hue2;
        [XmlElement("Hue3", Order = 4)]
        public Int32 hue3;
        [XmlElement("Hue4", Order = 5)]
        public Int32 hue4;
        [XmlElement("Layer", Order = 6)]
        public Int32 layer;
        [XmlElement("Mir", Order = 7)]
        public Boolean mirrored;
        [XmlElement("Rot", Order = 8)]
        public Int32 rotation;
        [XmlElement("Sat1", Order = 9)]
        public Int32 saturation1;
        [XmlElement("Sat2", Order = 10)]
        public Int32 saturation2;
        [XmlElement("Sat3", Order = 11)]
        public Int32 saturation3;
        [XmlElement("Sat4", Order = 12)]
        public Int32 saturation4;
        [XmlElement("ScaleX", Order = 13)]
        public Int32 scaleX;
        [XmlElement("ScaleY", Order = 14)]
        public Int32 scaleY;
        [XmlElement("Shear", Order = 15)]
        public Int32 shear;
        [XmlElement("TranX", Order = 16)]
        public Int32 transformX;
        [XmlElement("TranY", Order = 17)]
        public Int32 transformY;
        [XmlElement("Var1", Order = 18)]
        public Int32 var1;
        [XmlElement("Var2", Order = 19)]
        public Int32 var2;
        [XmlElement("Var3", Order = 20)]
        public Int32 var3;
        [XmlElement("Var4", Order = 21)]
        public Int32 var4;
    }
}
