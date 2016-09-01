using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
