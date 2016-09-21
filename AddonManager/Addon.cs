namespace AddonManager
{
    /// <summary>
    /// A hardcoded class for easy addon file management
    /// </summary>
    public class Addon
    {
        #region enums, properties, and fields
        public struct AddonType
        {
            public const string catalogWithBaskets = "Catalog and Basket Pack";
            public const string accent = "Accent";
            public const string theme = "Theme";
            public const string language = "Language";
            public const string memoryPatch = "Memory Patch"; 
        }
        public enum AddonProperty
        {
            Name = 0,
            Type = 1,
            CreatedBy = 2,
            CreatedOn = 3,
            Version = 4,
            MadeForVersion = 5,
            ReservedForLater = 6,
            Description = 7,
            AddonFile = 8
        }
        
        public static readonly dynamic[] addonNameDef = new dynamic[3] { AddonProperty.Name, 0, 101 };
        public static readonly dynamic[] addonTypeDef = new dynamic[3] { AddonProperty.Type, 404, 51 };
        public static readonly dynamic[] addonCreatorDef = new dynamic[3] { AddonProperty.CreatedBy, 608, 51 };
        public static readonly dynamic[] addonDateDef = new dynamic[3] { AddonProperty.CreatedOn, 812, 11 };
        public static readonly dynamic[] addonVersionDef = new dynamic[3] { AddonProperty.Version, 856, 15 };
        public static readonly dynamic[] addonForVersionDef = new dynamic[3] { AddonProperty.MadeForVersion, 916, 100 };
        public static readonly dynamic[] addonResDef = new dynamic[3] { AddonProperty.ReservedForLater, 1316, 5001 };
        public static readonly dynamic[] addonDescriptionDef = new dynamic[3] { AddonProperty.Description, 21320, 5001 };
        public static readonly dynamic[] addonFileDef = new dynamic[3] { AddonProperty.AddonFile, 41324, null };
        #endregion
    }
}