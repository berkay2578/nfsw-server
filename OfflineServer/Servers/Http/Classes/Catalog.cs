using System;

namespace OfflineServer.Servers.Http.Classes
{
    public static class Catalog
    {
        public static String categories()
        {
            return "<ArrayOfCategoryTrans/>";
        }
        public static String productsInCategory()
        {
            return "<ArrayOfProductTrans/>";
        }
    }
}
