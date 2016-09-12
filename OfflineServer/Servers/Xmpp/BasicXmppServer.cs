using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace OfflineServer.Servers.Xmpp
{
    public class BasicXmppServer : XmppServer
    {
        private Int32 amountRead = -1;
        private List<String> packets = new List<String>();

        public BasicXmppServer(Boolean ssl = false, Int32 port = 0)
        {
            personaId = 0;
            jidPrepender = "nfsw";
            isSsl = ssl;
            certificate = new X509Certificate2(Properties.Resources.certificate, "123456");
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
            listener.Start();
            this.port = ((IPEndPoint)listener.LocalEndpoint).Port;
            log.Info(String.Format("Successfully setup XmppServer on port {0}.", port));
        }

        public override void initialize()
        {
            log.Info("Setting up for a client.");
            cts = new CancellationTokenSource();
            ct = cts.Token;
            client = listener.AcceptTcpClient();
            log.Info(String.Format("Accepted client {0}.", client.GetHashCode()));
            stream = client.GetStream();
            client.Client.NoDelay = true;
            client.NoDelay = true;
        }

        private void definePackets()
        {
            packets = new List<String>();
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
            log.Warn(String.Format("Securing port {0} for Tls connection.", port));
            sslStream = new SslStream(client.GetStream());
            sslStream.AuthenticateAsServer(certificate, false, SslProtocols.Tls, false);
        }

        public override void doLogin(Int32 newPersonaId)
        {
            personaId = newPersonaId;
            log.Info(String.Format("Starting handshake for persona id {0}.", personaId));
            definePackets();
            doHandshake();
        }
        public override void doLogout(Int32 personaId)
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

            log.Info("Handshake successful.");
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
                    log.Info(String.Format("Stream ended for persona id {0} on client {1}.", personaId, client.GetHashCode()));
                    shutdown();
                    break;
                }
            }
        }

        public override void shutdown()
        {
            if (cts != null) cts.Cancel();
            if (isSsl && sslStream != null) sslStream.Close();
            if (client != null) client.Close();
            if (listener != null) listener.Stop();
            log.Info("Shutdown completed.");
        }

        public override Int64 calculateHash(String messageResponse)
        {
            String sourceText = String.Format("{0}.{1}@127.0.0.1{2}", jidPrepender, personaId, messageResponse);
            Int64 multiplier = 4294967295L & 0xffffffffL;
            Int64 oldMultiplier = 0L;
            Boolean cFlag = true;

            foreach (char c in sourceText)
            {
                Int64 hash = multiplier * 33L;
                Int64 hiHash = (hash >> 32) & 0xffffffffL;
                Int64 loHash = ((hash << 32) >> 32) & 0xffffffffL;

                long newHiMultiplier = ((hiHash) + (cFlag ? 1 : 0)) & 0xffffffffL;
                long newLoMultiplier = (((loHash << 32) >> 32) + c) & 0xffffffffL;

                cFlag = hiHash > newHiMultiplier;
                oldMultiplier = multiplier;

                multiplier = newHiMultiplier << 32 | newLoMultiplier;
            }

            return multiplier;
        }
    }
}