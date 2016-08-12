using System;
using System.Xml.Linq;

namespace OfflineServer
{
    public class Economy
    {
        public enum Currency
        {
            [StringData("Cash")]
            Cash = 0,
            [StringData("_NS")]
            Boost = 1
        }
        public enum ServerItemType
        {
            [StringData("CarSlot")]
            CarSlot = 0
        }
        public enum GameItemType
        {
            [StringData("CARSLOT")]
            CarSlot = 0
        }
        public enum Special
        {
            [StringData(null)]
            None = 0
        }

        public static class Basket
        {
            public static class ShoppingCartPurchaseResult
            {
                public static readonly String fail_MaxAllowedPuchaseLimitPassed = "Fail_MaxAllowedPurchasesForThisProduct";
                public static readonly String fail_InsufficientPerformanceInventory = "Fail_InsufficientPerformancePartInventory";
                public static readonly String fail_DisabledBoostTransactions = "Fail_BoostTransactionsAreDisabled";
                public static readonly String fail_ProductNotAvailableToUser = "Fail_LockedProductNotAccessibleToThisUser";
                public static readonly String fail_PersonaNotRightLevel = "Fail_PersonaNotRightLevel";
                public static readonly String fail_ItemNotAvailable = "Fail_ItemNotAvailableStandalone";
                public static readonly String fail_InvalidPerformanceUpgrade = "Fail_InvalidPerformanceUpgrade";
                public static readonly String fail_MaxStackOrRentalLimit = "Fail_MaxStackOrRentalLimit";
                public static readonly String fail_InsufficientCarSlots = "Fail_InsufficientCarSlots";
                public static readonly String fail_InsufficientFunds = "Fail_InsufficientFunds";
                public static readonly String fail_InvalidBasket = "Fail_InvalidBasket";
                public static readonly String success = "Success";
            }

            /// <summary>
            /// Initializes a product data entry for use in XML.
            /// </summary>
            /// <param name="CurrencyType">Type of currency the item is sold for</param>
            /// <param name="Description">NFS: World Beta feature, still gonna keep it for MAYBE future-use</param>
            /// <param name="RentalDurationInMinutes">0 if not a rental, rental duration in minutes if else</param>
            /// <param name="Hash">Item hash value that is recognized by NFS: World</param>
            /// <param name="IconString">Item icon that is displayed somewhere around it's title</param>
            /// <param name="LevelLimit">0 if not level limited, minimum level value if else</param>
            /// <param name="TooltipDescription">NFS: World Beta feature, still gonna keep it for MAYBE future-use</param>
            /// <param name="Price">How much the item is sold for</param>
            /// <param name="PriorityNumber">Priority in the shopping list in-game, commonly used for new items or discounts</param>
            /// <param name="SType">Item type that the server can recognize, not the game</param>
            /// <param name="Id">Item index for the server</param>
            /// <param name="Title">Item title that is displayed in-game</param>
            /// <param name="GType">Item type that NFS: World can recognize, not the server</param>
            /// <param name="ExtraDetail">If there is one, a special condition for the item that is displayed in-game</param>
            /// <returns>An XElement wrapped around in ProductTrans tags.</returns>
            public static XElement GetProductTransactionEntry(Currency CurrencyType, String Description, Int32 RentalDurationInMinutes, Int64 Hash, String IconString, Int16 LevelLimit, String TooltipDescription, Int32 Price, Int16 PriorityNumber, ServerItemType SType, Int32 Id, String Title, GameItemType GType, Special ExtraDetail = Special.None)
            {
                XElement ProductNode =
                    new XElement("ProductTrans",
                        new XElement("Currency", CurrencyType.GetString()),
                        new XElement("Description", Description),
                        new XElement("DurationMinute", RentalDurationInMinutes.ToString()),
                        new XElement("Hash", Hash.ToString()),
                        new XElement("Icon", IconString),
                        new XElement("Level", LevelLimit.ToString()),
                        new XElement("LongDescription", TooltipDescription),
                        new XElement("Price", Price.ToString()),
                        new XElement("Priority", PriorityNumber.ToString()),
                        new XElement("ProductId", String.Format("ItemEntry{0}-{1}", SType.GetString(), Id.ToString())),
                        new XElement("ProductTitle", Title),
                        new XElement("ProductType", GType.GetString()),
                        new XElement("SecondaryIcon", ExtraDetail.GetString()),
                        new XElement("UseCount", "1")
                    );
                return ProductNode;
            }
        }
    }
}