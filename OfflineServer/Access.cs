using OfflineServer.Data;
using OfflineServer.Data.Settings;
using OfflineServer.Servers;
using OfflineServer.Servers.Http;
using OfflineServer.Servers.Xmpp;
using System.IO;
using System.Text;

namespace OfflineServer
{
    public class Access : ObservableObject
    {
        public static DataAccess dataAccess { get; set; } = new DataAccess();
        public static NfswSession CurrentSession { get; set; } = new NfswSession();
        public static HttpServer sHttp;
        public static XmppServer sXmpp;
    }
}