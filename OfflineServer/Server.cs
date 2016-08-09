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

            Console.WriteLine("       + + ++ + : " + e.Request.Path);
            /*if (e.Request.Path.EndsWith("/carslots"))
            {
                baResponseArray = GetResponseData(Access.CurrentSession.ActivePersona.GetCompleteGarage());
            }
            else */
            if (File.Exists(currentIOPath))
            {
                baResponseArray = GetResponseData(currentIOPath);
            }
            if (e.Request.Path.Contains("SecureLogin"))
            {
                Access.sXmpp.initialize();
                Access.sXmpp.doLogin(Access.CurrentSession.ActivePersona.Id);
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
        protected Decoder decoder = Encoding.UTF8.GetDecoder();
        protected CancellationTokenSource cts;
        protected CancellationToken ct;
        protected Boolean isSsl;

        public async Task<String> read(Boolean forceNoSsl = false)
        {
            byte[] data = new byte[client.ReceiveBufferSize];
            int bytesRead;
            string request;
            if (isSsl & !forceNoSsl)
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
                request = Encoding.UTF8.GetString(data, 0, bytesRead);
            }
            File.AppendAllText("log.txt", DateTime.Now.ToLongTimeString() + " READ: " + request + "\r\n");
            return request;
        }

        public async Task write(String message, Boolean forceNoSsl = false)
        {
            byte[] msg = Encoding.UTF8.GetBytes(message);
            if (isSsl & !forceNoSsl)
            {
                await sslStream.WriteAsync(msg, 0, msg.Length, ct).ConfigureAwait(false);
                await sslStream.FlushAsync().ConfigureAwait(false);
            }
            else
            {
                await stream.WriteAsync(msg, 0, msg.Length, ct).ConfigureAwait(false);
                await stream.FlushAsync().ConfigureAwait(false);
            }
            File.AppendAllText("log.txt", DateTime.Now.ToLongTimeString() + " WRITE: " + message + "\r\n");
        }

        public abstract void initialize();
        public abstract void doHandshake();
        public abstract void doLogin(UInt32 newPersonaId);
        public abstract void doLogout(UInt32 personaId);
        public abstract void listenLoop();
        public abstract void shutdown();
    }

    public class BasicXMPPServer : XMPPServer
    {
        private Int32 amountRead = -1;
        private List<String> packets = new List<String>();

        public BasicXMPPServer(Int32 port, Boolean ssl = false)
        {
            this.port = port;
            personaId = 0;
            jidPrepender = "nfsw";
            isSsl = ssl;
            if (isSsl)
                packets.AddRange(new string[] {
                "<stream:stream xmlns='jabber:client' xmlns:stream='http://etherx.jabber.org/streams' from='127.0.0.1' id='5000000000000A' version='1.0' xml:lang='en'><stream:features><starttls xmlns='urn:ietf:params:xml:ns:xmpp-tls'/></stream:features>",
                "<proceed xmlns='urn:ietf:params:xml:ns:xmpp-tls'/>",
                });
            packets.AddRange(new string[] {
                "<stream:stream xmlns='jabber:client' xmlns:stream='http://etherx.jabber.org/streams' from='127.0.0.1' id='5000000000000A' version='1.0' xml:lang='en'><stream:features/>",
                String.Format("<iq id='EA-Chat-1' type='result' xml:lang='en'><query xmlns='jabber:iq:auth'><username>{0}.{1}</username><password/><digest/><resource/><clientlock xmlns='http://www.jabber.com/schemas/clientlocking.xsd'/></query></iq>", jidPrepender, personaId),
                "<iq id='EA-Chat-2' type='result' xml:lang='en'/>",
                String.Format("<presence from='channel.en__1@conference.127.0.0.1' to='{0}.{1}@127.0.0.1/EA-Chat' type='error'><error code='401' type='auth'><not-authorized xmlns='urn:ietf:params:xml:ns:xmpp-stanzas'/></error><x xmlns='http://jabber.org/protocol/muc'/></presence>", jidPrepender, personaId)
            });
            certificate = new X509Certificate2(Properties.Resources.certificate, "123456");
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
            listener.Start();
        }

        public override void initialize()
        {
            cts = new CancellationTokenSource();
            ct = cts.Token;
            client = listener.AcceptTcpClient();
            stream = client.GetStream();
            client.Client.NoDelay = true;
            client.NoDelay = true;
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
            Int32 final = 2 + (isSsl ? 2 : 0);
            String read = "";

            do
            {
                await _read().ConfigureAwait(false);
                await _write().ConfigureAwait(false);
            } while (amountRead < final);

            while (!read.StartsWith("<presence to"))
                read = await _read(false).ConfigureAwait(false);

            amountRead++;
            await _write().ConfigureAwait(false);
            listenLoop();
        }

        public override async void listenLoop()
        {
            while (!ct.IsCancellationRequested)
            {
                string packet = await read().ConfigureAwait(false);
                if (packet.Contains("</stream:stream>"))
                {
                    await write("</stream:stream>").ConfigureAwait(false);
                    cts.Cancel();
                    amountRead = -1;
                    if (isSsl) sslStream.Close();
                    client.Close();
                    break;
                }
            }
        }

        public override void shutdown()
        {
            if (cts != null) cts.Cancel();
            if (client != null) client.Close();
            if (listener != null) listener.Stop();
        }

        private async Task<String> _read(Boolean increaseAmountRead = true)
        {
            string result = await read((isSsl && amountRead < 1)).ConfigureAwait(false);
            if (increaseAmountRead) amountRead++;
            return result;
        }
        private async Task _write()
        {
            await write(packets[amountRead], (isSsl && amountRead < 2)).ConfigureAwait(false);
            if (isSsl && amountRead == 1) switchToTls();
        }
        private void switchToTls()
        {
            File.AppendAllText("log.txt", "Xmpp connection switching to tls.\r\n");
            sslStream = new SslStream(client.GetStream(), false);
            sslStream.AuthenticateAsServer(certificate, false, SslProtocols.Tls, true);
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