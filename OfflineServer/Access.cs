using OfflineServer.Servers.Http;
using OfflineServer.Servers.Xmpp;

namespace OfflineServer
{
    public class Access : ObservableObject
    {
        public static NfswSession CurrentSession { get; set; } = new NfswSession();
        public static HttpServer sHttp;
        public static XmppServer sXmpp;
    }
}