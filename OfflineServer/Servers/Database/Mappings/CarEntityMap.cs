using FluentNHibernate.Mapping;
using OfflineServer.Servers.Database.Entities;

namespace OfflineServer.Servers.Database.Mappings
{
    public class CarEntityMap : ClassMap<CarEntity>
    {
        public CarEntityMap()
        {
            Table("Garages");
            Id(c => c.id)
                .GeneratedBy.Native();
            Map(c => c.baseCarId);
            Map(c => c.carClassHash);
            Map(c => c.name);
            Map(c => c.paints);
            Map(c => c.performanceParts);
            Map(c => c.physicsProfileHash);
            Map(c => c.rating);
            Map(c => c.resalePrice);
            Map(c => c.skillModParts);
            Map(c => c.vinyls);
            Map(c => c.visualParts);
            Map(c => c.durability);
            Map(c => c.expirationDate)
                .Nullable();
            Map(c => c.heatLevel);
            References(c => c.ownerPersona)
                .Cascade.None();
        }
    }
}