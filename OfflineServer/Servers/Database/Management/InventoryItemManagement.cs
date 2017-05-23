using NHibernate;
using OfflineServer.Servers.Database.Entities;
using OfflineServer.Servers.Http.Responses;
using System;
using System.Linq;

namespace OfflineServer.Servers.Database.Management
{
    public static class InventoryItemManagement
    {
        internal static ISession session;
        static InventoryItemManagement()
        {
            session = SessionManager.getSessionFactory().OpenSession();
        }

        public static InventoryItemEntity getInventoryItemEntity(Int64 inventoryId)
        {
            return session.Load<InventoryItemEntity>(inventoryId);
        }
        public static void setInventoryItemEntity(this InventoryItemEntity newEntity)
        {
            if (newEntity != null)
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    InventoryItemEntity inventoryItemEntity = session.Load<InventoryItemEntity>(newEntity.id);
                    inventoryItemEntity = newEntity;
                    session.Update(inventoryItemEntity);
                    transaction.Commit();
                }
                lock (Persona.inventoryLock)
                {
                    Int32 index = Access.CurrentSession.ActivePersona.Inventory.IndexOf(
                        Access.CurrentSession.ActivePersona.Inventory.First(ii => ii.Id == newEntity.id));
                    Access.CurrentSession.ActivePersona.Inventory[index] = new InventoryItem(newEntity);
                }
            }
        }

        public static InventoryItemTrans getInventoryItemTrans(this InventoryItemEntity inventoryItemEntity)
        {
            InventoryItemTrans inventoryItemTrans = new InventoryItemTrans();
            inventoryItemTrans.entitlementTag = inventoryItemEntity.entitlementTag;
            inventoryItemTrans.hash = inventoryItemEntity.hash;
            inventoryItemTrans.inventoryId = inventoryItemEntity.id;
            inventoryItemTrans.productId = inventoryItemEntity.productId;
            inventoryItemTrans.remainingUseCount = inventoryItemEntity.remainingUseCount;
            inventoryItemTrans.resellPrice = inventoryItemEntity.resellPrice;
            inventoryItemTrans.status = inventoryItemEntity.status;
            inventoryItemTrans.stringHash = inventoryItemEntity.stringHash;
            inventoryItemTrans.virtualItemType = inventoryItemEntity.virtualItemType;

            return inventoryItemTrans;
        }
    }
}