using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    public class DragEventResult : EventResult
    {
        [XmlArray("Entrants")]
        [XmlArrayItem("DragEntrantResult")]
        public List<DragEntrantResult> entrants = new List<DragEntrantResult>();
    }
}
