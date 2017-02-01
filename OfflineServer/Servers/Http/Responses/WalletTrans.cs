using System;
using System.Xml.Serialization;
using static OfflineServer.Basket;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    public class WalletTrans
    {
        [XmlElement("Balance")]
        public Int32 balance;
        [XmlElement("Currency")]
        public Currency currency;
    }
}
