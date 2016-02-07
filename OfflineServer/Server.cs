using NHttp;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml.Linq;

namespace OfflineServer
{
    public static class ServerAttributes
    { 
        public static readonly XNamespace srlNS = XNamespace.Get("http://schemas.datacontract.org/2004/07/Victory.DataLayer.Serialization");
        public static readonly XNamespace nilNS = XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance");
    }

    public class HTTPServer
    {
        public HttpServer nServer = new HttpServer();
        public HTTPServer()
        {
            nServer.RequestReceived += nServer_RequestReceived;
            nServer.Start();

            //System.Diagnostics.Process.Start(String.Format("http://{0}/carslots", nServer.EndPoint));
        }

        private String currentIOPath;
        private void nServer_RequestReceived(object sender, HttpRequestEventArgs e)
        {
            currentIOPath = e.Request.Path.Remove(0, 1);

            e.Response.Headers.Add("Connection", "close");
            e.Response.Headers.Add("Content-Encoding", "gzip");
            e.Response.Headers.Add("Content-Type", "application/xml;charset=utf-8");
            e.Response.Headers.Add("Status-Code", "200");

            Byte[] baResponseArray = null;

            if (e.Request.Path.EndsWith("/carslots"))
            {
                baResponseArray = GetResponseData(MainWindow.CurrentSession.ActivePersona.GetCompleteGarage());
            }
            else if (File.Exists(currentIOPath))
            {
                baResponseArray = GetResponseData(currentIOPath);
            }

            e.Response.OutputStream.Write(baResponseArray, 0, baResponseArray.Length);
            e.Response.OutputStream.Flush();

            // e.Request.RequestType gives the method used, GET - POST - PUSH etc.
            // e.Request.Url gives the full Uri including EVERYTHING
            // e.Request.RawUrl gives the Path following the IP. EX: if 127.0.0.1:4444/test/path.xml?test=true then /test/path.xml?test=true
            // e.Request.Path gives only the Path, not adding the params at the end. EX: if 127.0.0.1:4444/test/path.xml?test=true then /test/path.xml
            // e.Request.Params gives only the Params, not adding anything else.
        }

        private Byte[] GetResponseData(String StringOrFilePath)
        {
            Byte[] baAnswerData = File.Exists(StringOrFilePath) ? File.ReadAllBytes(StringOrFilePath) : UTF8Encoding.UTF8.GetBytes(StringOrFilePath);

            using (MemoryStream msResponse = new MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(msResponse, CompressionMode.Compress, true))
                {
                    gzip.Write(baAnswerData, 0, baAnswerData.Length);
                }
                return msResponse.ToArray();
            }
        }
    }

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
            public static XElement GetProductTransactionEntry(Currency CurrencyType, String Description, Int32 RentalDurationInMinutes, Int64 Hash, String IconString, Int16 LevelLimit, String TooltipDescription, Int32 Price, Int16 PriorityNumber, ServerItemType SType, Int32 Id, String Title, GameItemType GType, Special ExtraDetail)
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