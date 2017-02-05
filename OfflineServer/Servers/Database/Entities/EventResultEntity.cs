using System;

namespace OfflineServer.Servers.Database.Entities
{
    public class EventResultEntity
    {
        public virtual Int32 id { get; protected set; }
        public virtual Int32 eventId { get; set; }
        public virtual UInt32 eventDurationInMilliseconds { get; set; }
        public virtual String finishReason { get; set; }
        public virtual Int32 rank { get; set; }
        public virtual Int32 gainedExp { get; set; }
        public virtual Int32 gainedCash { get; set; }
        public virtual UInt32? bestLapDurationInMilliseconds { get; set; }
        public virtual Boolean? perfectStart { get; set; }
        public virtual float? topSpeed { get; set; }
        public virtual String personaName { get; set; }
        public virtual String carName { get; set; }
    }
}