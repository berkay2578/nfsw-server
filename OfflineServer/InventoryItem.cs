using OfflineServer.Servers.Database.Entities;
using OfflineServer.Servers.Http.Responses;
using System;

namespace OfflineServer
{
    public class InventoryItem : ObservableObject
    {
        public Int64 Id { get; protected set; } // inventoryId
        public String EntitlementTag { get; set; }
        public Int64 Hash { get; set; }
        public String ProductId { get; set; }
        public Int32 RemainingUseCount { get; set; }
        public Int32 ResellPrice { get; set; }
        public String Status { get; set; }
        public String StringHash { get; set; }
        public String VirtualItemType { get; set; }

        public InventoryItem(InventoryItemEntity inventoryItemEntity)
        {
            Id = inventoryItemEntity.id;
            EntitlementTag = inventoryItemEntity.entitlementTag;
            Hash = inventoryItemEntity.hash;
            ProductId = inventoryItemEntity.productId;
            RemainingUseCount = inventoryItemEntity.remainingUseCount;
            ResellPrice = inventoryItemEntity.resellPrice;
            Status = inventoryItemEntity.status;
            StringHash = inventoryItemEntity.stringHash;
            VirtualItemType = inventoryItemEntity.virtualItemType;
        }

        public InventoryItemTrans getInventoryItemTrans()
        {
            InventoryItemTrans inventoryItemTrans = new InventoryItemTrans();
            inventoryItemTrans.entitlementTag = EntitlementTag;
            inventoryItemTrans.hash = Hash;
            inventoryItemTrans.inventoryId = Id;
            inventoryItemTrans.productId = ProductId;
            inventoryItemTrans.remainingUseCount = RemainingUseCount;
            inventoryItemTrans.resellPrice = ResellPrice;
            inventoryItemTrans.status = Status;
            inventoryItemTrans.stringHash = StringHash;
            inventoryItemTrans.virtualItemType = VirtualItemType;

            return inventoryItemTrans;
        }
    }
}