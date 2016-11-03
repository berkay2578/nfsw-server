using System;
using System.Xml.Linq;

namespace OfflineServer
{
    public class Economy
    {
        #region enums
        public enum Currency
        {
            [StringData("Cash")]
            Cash = 0,
            [StringData("_NS")]
            Boost = 1
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
        #endregion
        #region fields
        protected Int32 activePersonaBoost
        {
            get
            {
                if (Access.CurrentSession.ActivePersona != null)
                    return Access.CurrentSession.ActivePersona.Boost;
                return -1;
            }
            set
            {
                if (Access.CurrentSession.ActivePersona != null)
                    Access.CurrentSession.ActivePersona.Boost = value;
            }
        }
        protected Int32 activePersonaCash
        {
            get
            {
                if (Access.CurrentSession.ActivePersona != null)
                    return Access.CurrentSession.ActivePersona.Cash;
                return -1;
            }
            set
            {
                if (Access.CurrentSession.ActivePersona != null)
                    Access.CurrentSession.ActivePersona.Cash = value;
            }
        }
        #endregion

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
            /// <param name="currencyType">Type of currency the item is sold for</param>
            /// <param name="description">NFS: World Beta feature, still gonna keep it for MAYBE future-use</param>
            /// <param name="rentalDurationInMinutes">0 if not a rental, rental duration in minutes if else</param>
            /// <param name="hash">Item hash value that is recognized by NFS: World</param>
            /// <param name="iconString">Item icon that is displayed somewhere around its title</param>
            /// <param name="levelLimit">0 if not level limited, minimum level value if else</param>
            /// <param name="tooltipDescription">NFS: World Beta feature, still gonna keep it for MAYBE future-use</param>
            /// <param name="price">How much the item is sold for</param>
            /// <param name="priorityNumber">Priority in the shopping list in-game, commonly used for new items or discounts</param>
            /// <param name="id">Server product id</param>
            /// <param name="title">Item title that is displayed in-game</param>
            /// <param name="itemType">Item type that NFS: World can recognize</param>
            /// <param name="extraDetail">If there is one, a special condition for the item that is displayed in-game</param>
            /// <returns>An XElement wrapped around in ProductTrans tags.</returns>
            public static XElement getProductTransactionEntry(Currency currencyType, String description, Int32 rentalDurationInMinutes, Int64 hash, String iconString, Int16 levelLimit, String tooltipDescription, Int32 price, Int16 priorityNumber, String id, String title, GameItemType itemType, Special extraDetail = Special.None)
            {
                XElement ProductNode =
                    new XElement("ProductTrans",
                        new XElement("Currency", currencyType.GetString()),
                        new XElement("Description", description),
                        new XElement("DurationMinute", rentalDurationInMinutes.ToString()),
                        new XElement("Hash", hash.ToString()),
                        new XElement("Icon", iconString),
                        new XElement("Level", levelLimit.ToString()),
                        new XElement("LongDescription", tooltipDescription),
                        new XElement("Price", price.ToString()),
                        new XElement("Priority", priorityNumber.ToString()),
                        new XElement("ProductId", id),
                        new XElement("ProductTitle", title),
                        new XElement("ProductType", itemType.GetString()),
                        new XElement("SecondaryIcon", extraDetail.GetString()),
                        new XElement("UseCount", "1")
                    );
                return ProductNode;
            }
        }
    }
}