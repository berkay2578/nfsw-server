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
                .Column("pkCarId");
            Map(c => c.baseCarId);
            Map(c => c.raceClass);
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
            Map(c => c.carId);
            References(c => c.ownerPersona);
        }
    }
}
