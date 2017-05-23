using FluentNHibernate.Mapping;
using OfflineServer.Servers.Database.Entities;

namespace OfflineServer.Servers.Database.Mappings
{
    public class InventoryItemEntityMap : ClassMap<InventoryItemEntity>
    {
        public InventoryItemEntityMap()
        {
            Table("InventoryItems");
            Id(ii => ii.id)
                .GeneratedBy.Native();
            Map(ii => ii.entitlementTag);
            Map(ii => ii.hash);
            Map(ii => ii.productId);
            Map(ii => ii.remainingUseCount);
            Map(ii => ii.resellPrice);
            Map(ii => ii.status);
            Map(ii => ii.stringHash);
            Map(ii => ii.virtualItemType);
            References(ii => ii.ownerPersona)
                .Cascade.None();
            Not.LazyLoad();
        }
    }
}