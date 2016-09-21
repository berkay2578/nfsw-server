using System;
using System.Net.Sockets;
using System.Threading;

namespace AddonManager.IPCTalk
{
    public class OfflineServerTalk : IPCBase
    {
        public class IPCPacketType
        {
            public const string installedAddon = "addonManagerInstalledAddon";
            public const string addonManagerClosing = "addonManagerClosing";
            public const string offlineServerClosing = "offlineServerClosing";
        }

        public override void initialize(Int32 port)
        {
            log.InfoFormat("Initializing a new OfflineServerTalk with the target port {0}.", port);
            this.port = port;

            cts = new CancellationTokenSource();
            ct = cts.Token;

            client = new TcpClient("127.0.0.1", port);
            stream = client.GetStream();
            client.Client.NoDelay = true;
            client.NoDelay = true;

            isInitialized = true;

            log.Info("Initialized with an S<->C connection.");
            listenLoop();
        }

        public async void notify(String ipcPacketType)
        {
            log.InfoFormat("isInitialized: {0}. -> Requested packet '{1}' be written to the server.", isInitialized, ipcPacketType);
            if (isInitialized)
                await write(ipcPacketType);
        }

        public async void notify(String ipcPacketType, String message)
        {
            log.InfoFormat("isInitialized: {0}. -> Requested packet '{1}|{2}' be written to the server.", isInitialized, ipcPacketType, message);
            if (isInitialized)
                await write(String.Format("{0}|{1}", ipcPacketType, message));
        }

        public override async void listenLoop()
        {
            while (!ct.IsCancellationRequested)
            {
                string packet = await read();
                log.InfoFormat("isInitialized: {0}. -> Received packet '{1}' from the server.", isInitialized, packet);
                switch (packet)
                {
                    case IPCPacketType.offlineServerClosing:
                        shutdown();
                        break;
                    case null:
                        shutdown();
                        break;
                }
            }
        }

        public override void shutdown()
        {
            log.InfoFormat("isInitialized: {0}. -> Requested shutdown of the IPC Talk.", isInitialized);
            if (isInitialized)
            {
                if (cts != null) cts.Cancel();
                if (client != null) client.Close();
                stream = null;
                isInitialized = false;
                log.Info("Shutdown completed.");
            }
        }
    }
}