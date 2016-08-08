using NHttp;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml.Linq;
using System.Net.Sockets;
using System.Net;
using System.Collections.Generic;
using System.Windows;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Security.Authentication;
using System.Threading.Tasks;
using System.Threading;

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
            nServer.EndPoint.Port = 1337;
            nServer.Start();
            //System.Diagnostics.Process.Start(String.Format("http://{0}/carslots", nServer.EndPoint));
        }

        private String currentIOPath;
        private void nServer_RequestReceived(object sender, HttpRequestEventArgs e)
        {
            currentIOPath = e.Request.Path.Remove(0, 1) + ".xml";

            e.Response.Headers.Add("Connection", "close");
            e.Response.Headers.Add("Content-Encoding", "gzip");
            e.Response.Headers.Add("Content-Type", "application/xml;charset=utf-8");
            e.Response.Headers.Add("Status-Code", "200");

            Byte[] baResponseArray = null;

            /*if (e.Request.Path.EndsWith("/carslots"))
            {
                baResponseArray = GetResponseData(Access.CurrentSession.ActivePersona.GetCompleteGarage());
            }
            else */
            if (File.Exists(currentIOPath))
            {
                baResponseArray = GetResponseData(currentIOPath);
            }
            if (baResponseArray == null) baResponseArray = GetResponseData("<Trans/>");
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
                    gzip.Write(baAnswerData, 0, baAnswerData.Length);

                return msResponse.ToArray();
            }
        }
    }

    public abstract class XMPPServer
    {
        protected Int32 port;
        protected TcpListener listener;
        protected TcpClient client;
        protected NetworkStream stream;
        protected SslStream sslStream;
        protected UInt32 personaId;
        protected String jidPrepender;
        protected X509Certificate certificate;
        protected Decoder decoder = Encoding.ASCII.GetDecoder();
        protected CancellationTokenSource cts;
        protected CancellationToken ct;

        public async Task<String> read(Boolean isSSL = true)
        {
            byte[] data = new byte[client.ReceiveBufferSize];
            int bytesRead;
            string request;
            if (isSSL)
            {
                var readTask = await sslStream.ReadAsync(data, 0, Convert.ToInt32(client.ReceiveBufferSize), ct).ConfigureAwait(false);
                bytesRead = readTask;
                char[] chars = new char[decoder.GetCharCount(data, 0, bytesRead)];
                decoder.GetChars(data, 0, bytesRead, chars, 0);
                request = new string(chars);
            }
            else
            {
                var readTask = await stream.ReadAsync(data, 0, Convert.ToInt32(client.ReceiveBufferSize), ct).ConfigureAwait(false);
                bytesRead = readTask;
                request = Encoding.ASCII.GetString(data, 0, bytesRead);
            }
            File.AppendAllText("log.txt", DateTime.Now.ToLongTimeString() + " READ: " + request + "\r\n");
            return request;
        }

        public async void write(String message, Boolean isSSL = true)
        {
            File.AppendAllText("log.txt", DateTime.Now.ToLongTimeString() + " WRITE: " + message + "\r\n");
            byte[] msg = Encoding.ASCII.GetBytes(message);
            if (isSSL)
                await sslStream.WriteAsync(msg, 0, msg.Length, ct).ConfigureAwait(false);
            else
                await stream.WriteAsync(msg, 0, msg.Length, ct).ConfigureAwait(false);
        }

        public abstract void initialize(TcpClient client);
        public abstract void doHandshake();
        public abstract void doHandshakeWithSSL();
        public abstract void doLogin(UInt32 newPersonaId);
        public abstract void doLogout(UInt32 personaId);
        public abstract void listenLoop();
        public abstract void shutdown();
    }

    public class BasicXMPPServer : XMPPServer
    {
        public BasicXMPPServer(Int32 port)
        {
            this.port = port;
            personaId = 0;
            jidPrepender = "nfsw";
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
            listener.Start();
            initialize(null);
        }

        public override async void initialize(TcpClient client)
        {
            cts = new CancellationTokenSource();
            ct = cts.Token;
            this.client = client == null ? (await listener.AcceptTcpClientAsync().ConfigureAwait(false)) : client;
            stream = this.client.GetStream();
            this.client.Client.NoDelay = true;
            this.client.NoDelay = true;
            doLogin(Access.CurrentSession.ActivePersona.Id);
        }
        
        public override void doLogin(UInt32 newPersonaId)
        {
            this.personaId = newPersonaId;
            doHandshake();
        }
        public override void doLogout(UInt32 personaId)
        {
            throw new NotImplementedException();
        }
        public override async void doHandshake()
        {
            List<String> packets = new List<String>();
            packets.AddRange(new string[] {"<stream:stream xmlns='jabber:client' xml:lang='en' xmlns:stream='http://etherx.jabber.org/streams' from='127.0.0.1' id='174159513' version='1.0'><stream:features/>",
            String.Format("<iq id='EA-Chat-1' type='result' xml:lang='en'><query xmlns='jabber:iq:auth'><username>{0}.{1}</username><password/><digest/><resource/><clientlock xmlns='http://www.jabber.com/schemas/clientlocking.xsd'/></query></iq>", jidPrepender, personaId),
            "<iq id='EA-Chat-2' type='result' xml:lang='en'/>",
            String.Format("<presence from='channel.en__1@conference.127.0.0.1' to='{0}.{1}@127.0.0.1/EA-Chat' type='error'><error code='401' type='auth'><not-authorized xmlns='urn:ietf:params:xml:ns:xmpp-stanzas'/></error><x xmlns='http://jabber.org/protocol/muc'/></presence>", jidPrepender, personaId) });

            for (int packetCount = 0; packetCount < packets.Count; packetCount++)
            {
                File.AppendAllText("log.txt", "packetCount: " + packetCount + " \r\n");
                if (packetCount == 3)
                {
                    string received = "";
                    while (!ct.IsCancellationRequested)
                    {
                        received = read(false).Result;
                        if (received.StartsWith("<presence to")) break;
                    }
                }
                else
                {
                    await read(false);
                }
                write(packets[packetCount], false);
            }
            listenLoop();
        }
        public override void doHandshakeWithSSL()
        {
            throw new NotImplementedException();
        }
        public override async void listenLoop()
        {
            while (!ct.IsCancellationRequested)
            {
                while (true)
                {
                    String packet = await read(false);
                    if (packet.Contains("</stream:stream>"))
                        break;
                }
                cts.Cancel();
                client.Client.Close();
                client.Close();

                //wait for new login; 
                //if there isn't one for 30 seconds, drop the connection and retry
                var timeoutTask = TaskEx.Delay(TimeSpan.FromSeconds(30));
                var clientAcceptTask = listener.AcceptTcpClientAsync();
                var completedTask = await TaskEx.WhenAny(timeoutTask, clientAcceptTask).ConfigureAwait(false);

                TcpClient resultClient = null;
                if (completedTask != timeoutTask) resultClient = clientAcceptTask.Result;

                initialize(resultClient);
            }
        }

        public override void shutdown()
        {
            cts.Cancel();
            if (client != null) client.Close();
            listener.Stop();
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