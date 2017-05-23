using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("InventoryTrans", Namespace = "http://schemas.datacontract.org/2004/07/Victory.DataLayer.Serialization")]
    public class InventoryTrans
    {
        [XmlArray("InventoryItems")]
        [XmlArrayItem("InventoryItemTrans")]
        public List<InventoryItemTrans> inventoryItems = new List<InventoryItemTrans>();
        [XmlElement("PerformancePartsCapacity")]
        public Int64 performancePartsCapacity = 100;
        [XmlElement("PerformancePartsUsedSlotCount")]
        public Int64 performancePartsUsedSlotCount = 0;
        [XmlElement("SkillModPartsCapacity")]
        public Int64 skillModPartsCapacity = 100;
        [XmlElement("SkillModPartsUsedSlotCount")]
        public Int64 skillModPartsUsedSlotCount = 0;
        [XmlElement("VisualPartsCapacity")]
        public Int64 visualPartsCapacity = 100;
        [XmlElement("VisualPartsUsedSlotCount")]
        public Int64 visualPartsUsedSlotCount = 0;
    }
}
