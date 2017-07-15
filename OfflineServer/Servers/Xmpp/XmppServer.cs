using System;
using System.Net.Security;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OfflineServer.Servers.Xmpp
{
    public abstract class XmppServer
    {
        public Int32 port;
        public String jidPrepender;
        protected Int32 personaId;
        protected TcpListener listener;
        protected TcpClient client;
        protected NetworkStream stream;
        protected SslStream sslStream;
        protected X509Certificate certificate;
        protected Decoder decoder = Encoding.UTF8.GetDecoder();
        protected CancellationTokenSource cts;
        protected CancellationToken ct;
        protected Boolean isSsl;
        protected Encoding utf8Encoding = Encoding.UTF8;
        protected readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<String> read(Boolean forceNoSsl = false)
        {
            try
            {
                byte[] data = new byte[4096];
                int bytesRead;
                string request;
                if (isSsl & !forceNoSsl)
                {
                    bytesRead = await sslStream.ReadAsync(data, 0, data.Length, ct);
                    Char[] chars = new Char[decoder.GetCharCount(data, 0, bytesRead)];
                    decoder.GetChars(data, 0, bytesRead, chars, 0);
                    request = new String(chars);
                }
                else
                {
                    bytesRead = await stream.ReadAsync(data, 0, data.Length, ct);
                    request = utf8Encoding.GetString(data, 0, bytesRead);
                }
                log.Info(String.Format("Acknowledged xmpp packet {0}.", request));
                return request;
            }
            catch (Exception ex)
            {
                log.Error("Exception occured while reading.", ex);
                return "ExceptionOccured";
            }
        }

        public async Task write(String message, Boolean forceNoSsl = false)
        {
            try
            {
                if (isSsl & !forceNoSsl)
                {
                    // SSLStream crops char[0] into the first 4bytes -> packet length. This is a workaround it.
                    byte[] msg = utf8Encoding.GetBytes(" " + message);
                    await sslStream.WriteAsync(msg, 0, msg.Length, ct);
                    await sslStream.FlushAsync(ct);
                }
                else
                {
                    byte[] msg = utf8Encoding.GetBytes(message);
                    await stream.WriteAsync(msg, 0, msg.Length, ct);
                    await stream.FlushAsync(ct);
                }
                log.Info(String.Format("Sent xmpp packet {0}.", message));
            }
            catch (Exception ex)
            {
                log.Error("Exception occured while writing.", ex);
            }
        }

        public abstract void initialize();
        public abstract void doHandshake();
        public abstract void doLogin(Int32 newPersonaId);
        public abstract void doLogout();
        public abstract void listenLoop();
        public abstract Int64 calculateHash(String messageResponse);
        public abstract void shutdown();
    }
}