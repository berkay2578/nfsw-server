using OfflineServer.Data;
using System;
using System.IO;
using System.Text;

namespace OfflineServer.Servers.Http.Classes
{
    // Normally, this is false and should not ever be done. However,
    // NFS:W sends requests for each product entry even though it knows
    // there should be a database waiting to run a query on the 'categoryName'.
    // Though, since NFS:W does the requests for us, I'm just abusing it for:
    // 1. Easy management in code, and, 2. Easy installation of mods.
    public static class Catalog
    {
        public static String categories()
        {
            String targetCategoryName = Access.sHttp.request.Params.Get("categoryName");
            if (String.IsNullOrWhiteSpace(targetCategoryName))
                return "<ArrayOfCategoryTrans/>";

            String targetLocalFile = Path.Combine(DataEx.dir_CurrentHttpServerCategories, targetCategoryName + ".xml");
            if (File.Exists(targetLocalFile))
                return File.ReadAllText(targetLocalFile, Encoding.UTF8);

            return "<ArrayOfCategoryTrans/>";
        }

        public static String productsInCategory()
        {
            String targetProductName = Access.sHttp.request.Params.Get("categoryName");
            if (String.IsNullOrWhiteSpace(targetProductName))
                return "<ArrayOfProductTrans/>";

            String targetLocalFile = Path.Combine(DataEx.dir_CurrentHttpServerProducts, targetProductName + ".xml");
            if (File.Exists(targetLocalFile))
                return File.ReadAllText(targetLocalFile, Encoding.UTF8);
            
            return "<ArrayOfProductTrans/>";
        }
    }
}