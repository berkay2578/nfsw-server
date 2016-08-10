using System;

namespace OfflineServer.Servers.Http.Classes
{
    public static class Session
    {
        public static String getChatInfo()
        {
            String chatServer = String.Format("<chatServer xmlns=\"http://schemas.datacontract.org/2004/07/Victory.TransferObjects.Session\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\"><Rooms><chatRoom><channelCount>2</channelCount><longName>TXT_CHAT_LANG_GENERAL</longName><shortName>GN</shortName></chatRoom></Rooms><ip>127.0.0.1</ip><port>{0}</port><prefix>{1}</prefix></chatServer>", Access.sXmpp.port, Access.sXmpp.jidPrepender);
            return chatServer;
        }
    }
}
