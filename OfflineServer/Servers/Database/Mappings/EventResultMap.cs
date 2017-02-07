using FluentNHibernate.Mapping;
using OfflineServer.Servers.Database.Entities;

namespace OfflineServer.Servers.Database.Mappings
{
    public class EventResultEntityMap : ClassMap<EventResultEntity>
    {
        public EventResultEntityMap()
        {
            Table("EventResult");
            Id(er => er.id)
                .GeneratedBy.Native();
            Map(er => er.eventId);
            Map(er => er.eventDurationInMilliseconds);
            Map(er => er.finishReason);
            Map(er => er.rank);
            Map(er => er.gainedExp);
            Map(er => er.gainedCash);
            Map(er => er.bestLapDurationInMilliseconds)
                .Nullable();
            Map(er => er.perfectStart)
                .Nullable();
            Map(er => er.topSpeed)
                .Nullable();
            Map(er => er.copsDeployed)
                .Nullable();
            Map(er => er.copsDisabled)
                .Nullable();
            Map(er => er.copsRammed)
                .Nullable();
            Map(er => er.costToState)
                .Nullable();
            Map(er => er.heat)
                .Nullable();
            Map(er => er.infractions)
                .Nullable();
            Map(er => er.roadBlocksDodged)
                .Nullable();
            Map(er => er.spikeStripsDodged)
                .Nullable();
            Map(er => er.personaName);
            Map(er => er.carName);
        }
    }
}