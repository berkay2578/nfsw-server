using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
