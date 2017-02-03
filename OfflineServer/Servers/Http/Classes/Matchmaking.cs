using OfflineServer.Servers.Http.Responses;
using System;

namespace OfflineServer.Servers.Http.Classes
{
    public static class Matchmaking
    {
        public static String launchevent()
        {
            Int32 eventId = Int32.Parse(Access.sHttp.request.Path.Split('/')[4]);
            Access.CurrentSession.ActivePersona.currentEventId = eventId;

            SessionInfo sessionInfo = new SessionInfo();
            sessionInfo.eventId = eventId;
            return sessionInfo.SerializeObject();
        }
    }
}
