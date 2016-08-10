using System;

namespace OfflineServer.Servers.Http.Classes
{
    public static class User
    {
        public static String secureLoginPersona()
        {
            Access.sXmpp.initialize();
            Access.sXmpp.doLogin(Access.CurrentSession.ActivePersona.Id);
            return "";
        }
        public static String secureLogout()
        {
            Access.sXmpp.shutdown();
            Access.sXmpp = new Xmpp.BasicXmppServer();
            return "";
        }
    }
}
