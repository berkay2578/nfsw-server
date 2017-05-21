using FluentNHibernate.Mapping;
using OfflineServer.Servers.Database.Entities;

namespace OfflineServer.Servers.Database.Mappings
{
    public class PersonaEntityMap : ClassMap<PersonaEntity>
    {
        public PersonaEntityMap()
        {
            Table("Personas");
            Id(p => p.id);
            Map(p => p.timePlayed);
            Map(p => p.iconIndex);
            Map(p => p.name);
            Map(p => p.motto);
            Map(p => p.level);
            Map(p => p.cash);
            Map(p => p.boost);
            Map(p => p.percentageOfLevelCompletion);
            Map(p => p.reputationInLevel);
            Map(p => p.reputationInTotal);
            Map(p => p.currentCarIndex);
            Map(p => p.score);
            Map(p => p.rating);
            HasMany(p => p.garage)
                .AsBag()
                .Inverse()
                .Cascade.AllDeleteOrphan()
                .Fetch.Join()
                .OrderBy("id asc");
            Not.LazyLoad();
        }
    }
}