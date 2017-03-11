using System;
using OfflineServer.Servers.Database.Entities;

namespace OfflineServer
{
    public class EventResult : ObservableObject
    {
        public Int32 Id { get; protected set; }
        public Int32 EventId { get; set; }
        public String EventDuration { get; set; }
        public String FinishReason { get; set; }
        public Int32 Rank { get; set; }
        public Int32 GainedExp { get; set; }
        public Int32 GainedCash { get; set; }
        public String BestLapDuration { get; set; }
        public String PerfectStart { get; set; }
        public String TopSpeed { get; set; }
        public String PersonaName { get; set; }
        public String CarName { get; set; }
        public String EventName
        {
            get
            {
                return EventDefinitions.defineFromEventId(EventId);
            }
        }

        public EventResult(EventResultEntity eventResult)
        {
            Id = eventResult.id;
            EventId = eventResult.eventId;
            EventDuration = TimeSpan.FromMilliseconds(eventResult.eventDurationInMilliseconds).ToString(@"mm\:ss\:fff");
            FinishReason = eventResult.finishReason;
            Rank = eventResult.rank;
            GainedExp = eventResult.gainedExp;
            GainedCash = eventResult.gainedCash;
            BestLapDuration = eventResult.bestLapDurationInMilliseconds == null ? "-" :
                TimeSpan.FromMilliseconds((UInt32)eventResult.bestLapDurationInMilliseconds).ToString(@"mm\:ss\:fff");
            PerfectStart = eventResult.perfectStart == null ? "-" :
                (Boolean)eventResult.perfectStart ? "Yes" : "No";
            TopSpeed = eventResult.topSpeed == null ? "-" :
                (float)eventResult.topSpeed * 3.6f + " km/h";
            PersonaName = eventResult.personaName;
            CarName = eventResult.carName;
        }
    }
}