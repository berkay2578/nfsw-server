using OfflineServer.Servers.Database.Entities;
using OfflineServer.Servers.Database.Management;
using OfflineServer.Servers.Http.Responses;
using System;

namespace OfflineServer.Servers.Http.Classes
{
    public static class Matchmaking
    {
        public static String launchevent()
        {
            Int32 eventId = Int32.Parse(Access.sHttp.request.Path.Split('/')[4]);

            EventResultEntity eventResultEntity = new EventResultEntity();
            eventResultEntity.carName = Access.CurrentSession.ActivePersona.SelectedCar.MakeModel;
            eventResultEntity.eventId = eventId;
            eventResultEntity.personaName = Access.CurrentSession.ActivePersona.Name;
            eventResultEntity = EventResultManagement.addEventResult(eventResultEntity);
            Access.CurrentSession.ActivePersona.currentEventId = eventId;
            Access.CurrentSession.ActivePersona.currentEventSessionId = eventResultEntity.id;

            SessionInfo sessionInfo = new SessionInfo();
            sessionInfo.eventId = eventId;
            sessionInfo.sessionId = eventResultEntity.id;
            return sessionInfo.SerializeObject();
        }
    }
}
