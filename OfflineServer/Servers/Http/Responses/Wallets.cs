using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    public class Wallets
    {
        [XmlElement("WalletTrans")]
        public WalletTrans walletTrans = new WalletTrans();
    }
}
