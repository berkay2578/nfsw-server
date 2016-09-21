using System;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AddonManager.IPCTalk
{
    public abstract class IPCBase
    {
        protected Boolean isInitialized = false;
        protected Int32 port;
        protected TcpClient client;
        protected NetworkStream stream;
        protected CancellationTokenSource cts;
        protected CancellationToken ct;
        protected readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<String> read()
        {
            if (isInitialized && stream != null)
            {
                try
                {
                    byte[] data = new byte[1024];
                    int bytesRead = await stream.ReadAsync(data, 0, data.Length, ct);
                    string request = Encoding.UTF8.GetString(data, 0, bytesRead);

                    return request;
                }
                catch (Exception)
                {
                    shutdown();
                }
            }
            return null;
        }

        public async Task write(String message)
        {
            if (isInitialized && stream != null)
            {
                try
                {
                    byte[] msg = Encoding.UTF8.GetBytes(message);
                    await stream.WriteAsync(msg, 0, msg.Length, ct);
                    await stream.FlushAsync(ct);
                }
                catch (Exception)
                {
                    shutdown();
                }
            }
        }

        public abstract void initialize(Int32 port);
        public abstract void listenLoop();
        public abstract void shutdown();
    }
}