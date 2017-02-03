using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    public class TeamEscapeEventResult : EventResult
    {
        [XmlArray("Entrants")]
        [XmlArrayItem("TeamEscapeEntrantResult")]
        public List<TeamEscapeEntrantResult> entrants = new List<TeamEscapeEntrantResult>();
    }
}
