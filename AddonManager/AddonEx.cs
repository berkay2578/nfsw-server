﻿using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using static AddonManager.Addon;

namespace AddonManager
{
    internal static class AddonEx
    {
        internal static dynamic readAddonProperty(this String filePath, dynamic[] typeDef)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                try
                {
                    int bytesToRead = typeDef[0] != AddonProperty.AddonFile ? typeDef[2] * 4 : (int)fileStream.Length - typeDef[1];
                    int bytesRead = 0;
                    int count = 0;
                    byte[] buffer = new byte[bytesToRead];
                    fileStream.Position = typeDef[1];

                    do
                    {
                        bytesRead += count;
                        bytesToRead -= count;
                        count = fileStream.Read(buffer, bytesRead, bytesToRead);
                    } while (count > 0);
                    if (typeDef[0] != AddonProperty.AddonFile)
                        return new UTF8Encoding(false, false).GetString(buffer).TrimEnd('\0');
                    return buffer;
                }
                catch (Exception ex)
                {
                    Debug.Print("Something isn't quite right...");
                    Debug.Print(ex.ToString());
                    return null;
                }
            }
        }

        internal static void saveAddonProperty(this String filePath, dynamic[] typeDef, String strValue, Boolean resetFile = false)
        {
            using (FileStream fileStream = new FileStream(filePath, resetFile? FileMode.Create : FileMode.Open, FileAccess.Write, FileShare.None))
            {
                byte[] value = new UTF8Encoding(false, false).GetBytes(strValue.Substring(0, Math.Min(strValue.Length, typeDef[2] - 1)) + '\0');
                fileStream.Position = typeDef[1];
                fileStream.Write(value, 0, value.Length);
            }
        }
        internal static void saveAddonFile(this String filePath, String addonType, params String[][] lists)
        {
            string tempDir = Path.Combine(Path.GetTempPath(), "addonmanager");
            string zipFile = Path.Combine(Path.GetTempPath(), "addon.zip");
            if (Directory.Exists(tempDir)) Directory.Delete(tempDir, true);
            if (File.Exists(zipFile)) File.Delete(zipFile);
            Directory.CreateDirectory(tempDir);

            switch (addonType)
            {
                case AddonType.catalogWithBaskets:
                    string[] products = lists[0];
                    string[] categories = lists[1];
                    string[] baskets = lists[2];

                    var productsTemp = Directory.CreateDirectory(Path.Combine(tempDir, OfflineServer.Data.DataEx.dir_HttpServerCatalogs, 
                        Path.GetFileNameWithoutExtension(filePath), "Products"));
                    var categoriesTemp = Directory.CreateDirectory(Path.Combine(tempDir, OfflineServer.Data.DataEx.dir_HttpServerCatalogs, 
                        Path.GetFileNameWithoutExtension(filePath), "Categories"));
                    var basketsTemp = Directory.CreateDirectory(Path.Combine(tempDir, OfflineServer.Data.DataEx.dir_HttpServerBaskets));

                    foreach (string product in products)
                        File.Copy(AddonProject.Catalog.getFileLocation(product), Path.Combine(productsTemp.FullName,
                            AddonProject.Catalog.getListBoxEntryText(product)), true);
                    foreach (string category in categories)
                        File.Copy(AddonProject.Catalog.getFileLocation(category), Path.Combine(categoriesTemp.FullName,
                            AddonProject.Catalog.getListBoxEntryText(category)), true);
                    foreach (string basket in baskets)
                        File.Copy(AddonProject.Catalog.getFileLocation(basket), Path.Combine(basketsTemp.FullName,
                            AddonProject.Catalog.getListBoxEntryText(basket)), true);

                    FastZip fz = new FastZip();
                    fz.CreateEmptyDirectories = true;
                    fz.CreateZip(zipFile, tempDir, true, null);
                    break;
                case AddonType.accent:
                    break;
                case AddonType.theme:
                    break;
                case AddonType.language:
                    break;
                case AddonType.memoryPatch:
                    break;
            }

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Write, FileShare.None))
            {
                byte[] addonFileBytes = File.ReadAllBytes(zipFile);
                fileStream.Position = Addon.addonFileDef[1];
                fileStream.Write(addonFileBytes, 0, addonFileBytes.Length);
            }

            if (Directory.Exists(tempDir)) Directory.Delete(tempDir, true);
            if (File.Exists(zipFile)) File.Delete(zipFile);
        }
    }
}