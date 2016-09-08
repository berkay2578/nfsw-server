using OfflineServer.Servers;
using OfflineServer.Servers.Http;
using OfflineServer.Servers.Xmpp;
using System.IO;
using System.Text;

namespace OfflineServer
{
    public class Access : ObservableObject
    {
        public static NfswSession CurrentSession { get; set; } = new NfswSession();
        public static HttpServer sHttp;
        public static XmppServer sXmpp;
        public static Settings Settings { get; set; }

        public Access()
        {
            if (File.Exists("Settings.xml"))
            {
                Settings = File.ReadAllText("Settings.xml", Encoding.UTF8).DeserializeObject<Settings>();
            } else
            {
                Settings = new Settings();
                Settings.uiSettings.doDefault();
                Settings.saveInstance();
            }
        }
    }
}