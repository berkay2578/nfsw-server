using OfflineServer.Data;
using OfflineServer.Servers.Http;
using OfflineServer.Servers.IPC;
using OfflineServer.Servers.Xmpp;

namespace OfflineServer
{
    public class Access : ObservableObject
    {
        public static DataAccess dataAccess { get; set; } = new DataAccess();
        public static NfswSession CurrentSession { get; set; } = new NfswSession();
        public static HttpServer sHttp;
        public static XmppServer sXmpp;
        public static MainWindow mainWindow;
        public static AddonManagerTalk addonManagerTalk;
    }
}