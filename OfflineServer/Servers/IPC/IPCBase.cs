using System;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OfflineServer.Servers.IPC
{
    public abstract class IPCBase
    {
        internal Int32 port;
        protected TcpListener listener;
        protected TcpClient client;
        protected NetworkStream stream;
        protected CancellationTokenSource cts;
        protected CancellationToken ct;
        protected readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<String> read()
        {
            if (stream != null)
            {
                Byte[] data = new Byte[1024];
                Int32 bytesRead = await stream.ReadAsync(data, 0, data.Length, ct);
                String request = Encoding.UTF8.GetString(data, 0, bytesRead);

                log.Info(String.Format("Acknowledged IPC packet '{0}' on port {1}.", request, port));
                return request;
            }
            return null;
        }

        public async Task write(String message)
        {
            if (stream != null)
            {
                Byte[] msg = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(msg, 0, msg.Length, ct);
                await stream.FlushAsync(ct);

                log.Info(String.Format("Sent IPC packet '{0}' on port {1}.", message, port));
            }
        }

        public abstract void initialize();
        public abstract void listenLoop();
        public abstract void shutdown();
    }
}