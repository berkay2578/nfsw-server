using System;

namespace OfflineServer.Servers.Database.Entities
{
    public class InventoryItemEntity
    {
        public virtual Int64 id { get; protected set; } // inventoryId
        public virtual String entitlementTag { get; set; }
        public virtual Int64 hash { get; set; }
        public virtual String productId { get; set; }
        public virtual Int32 remainingUseCount { get; set; }
        public virtual Int32 resellPrice { get; set; }
        public virtual String status { get; set; }
        public virtual String stringHash { get; set; }
        public virtual String virtualItemType { get; set; }
        public virtual PersonaEntity ownerPersona { get; set; }
    }
}
