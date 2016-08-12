using OfflineServer.Servers.Http;
using OfflineServer.Servers.Xmpp;
using System.IO;

namespace OfflineServer
{
    public class Access : ObservableObject
    {
        public static NfswSession CurrentSession { get; set; } = new NfswSession();
        public static HttpServer sHttp = new HttpServer();
        public static XmppServer sXmpp = new BasicXmppServer();
    }
}