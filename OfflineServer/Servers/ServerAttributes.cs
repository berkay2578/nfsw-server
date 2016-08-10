using System.Xml.Linq;

namespace OfflineServer.Servers
{
    public class ServerAttributes
    {
        public static readonly XNamespace srlNS = XNamespace.Get("http://schemas.datacontract.org/2004/07/Victory.DataLayer.Serialization");
        public static readonly XNamespace nilNS = XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance");
    }
}