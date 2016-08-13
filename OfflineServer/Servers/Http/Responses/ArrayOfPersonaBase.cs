using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("ArrayOfPersonaBase", Namespace = "http://schemas.datacontract.org/2004/07/Victory.Service.Objects", IsNullable = true)]
    public class ArrayOfPersonaBase
    {
        public PersonaBase personaBase;
    }
}
