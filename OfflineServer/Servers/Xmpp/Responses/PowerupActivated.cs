using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Xmpp.Responses
{
    [Serializable()]
    public class PowerupActivated
    {
        [XmlElement("Count")]
        public Int32 count = 1;
        [XmlElement("Id")]
        public Int64 id;
        [XmlElement("PersonaId")]
        public Int32 personaId;
        [XmlElement("TargetPersonaId")]
        public Int32 targetPersonaId;
    }
}
