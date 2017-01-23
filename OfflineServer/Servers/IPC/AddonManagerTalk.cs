using MahApps.Metro.Controls;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace OfflineServer.Servers.IPC
{
    public class AddonManagerTalk : IPCBase
    {
        public static Boolean isAddonManagerRunning { get; set; }
        public static Boolean isWaitingForClient { get; set; }

        public class IPCPacketType
        {
            public const String installedAddon = "addonManagerInstalledAddon";
            public const String addonManagerClosing = "addonManagerClosing";
            public const String offlineServerClosing = "offlineServerClosing";
        }

        public override async void initialize()
        {
            log.Info("Setting up for AddonManager.");
            isWaitingForClient = true;

            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 0);
                listener.Start();
                port = ((IPEndPoint)listener.LocalEndpoint).Port;

                log.Info(String.Format("Successfully setup AddonManager IPC Talk on port {0}.", port));

                client = await listener.AcceptTcpClientAsync();
                log.Info("Accepted AddonManager client.");

                isAddonManagerRunning = true;
                isWaitingForClient = false;

                cts = new CancellationTokenSource();
                ct = cts.Token;

                stream = client.GetStream();
                client.Client.NoDelay = true;
                client.NoDelay = true;

                listenLoop();
            }
            catch (ObjectDisposedException ex)
            {
                log.Warn("Shutdown of IPC Talk is requested while waiting a client connection from AddonManager.", ex);
            }
        }

        public async Task notify(String ipcPacketType)
        {
            if (!isWaitingForClient)
                await write(ipcPacketType);
        }

        public async Task notify(String ipcPacketType, String message)
        {
            if (!isWaitingForClient)
                await write(String.Format("{0}|{1}", ipcPacketType, message));
        }

        public override async void listenLoop()
        {
            while (!ct.IsCancellationRequested)
            {
                String packet = await read();
                if (packet.StartsWith(IPCPacketType.installedAddon))
                {
                    Access.mainWindow.Invoke(new Action(() =>
                    {
                        Access.dataAccess.appSettings.reloadAllLists();
                        Access.mainWindow.informUser("Addon Manager",
                            String.Format(Access.dataAccess.appSettings.uiSettings.language.AddonManagerAddonInstalled,
                            packet.Split('|')[1]));
                    }));
                }
                else if (packet.Contains(IPCPacketType.addonManagerClosing))
                {
                    isAddonManagerRunning = false;
                    shutdown();
                }
            }
        }

        public override void shutdown()
        {
            isAddonManagerRunning = false; // assuming it was closed manually by the user
            isWaitingForClient = true;

            try
            {
                if (cts != null) cts.Cancel();
                if (client != null) client.Close();
                if (listener != null) listener.Stop();
                stream = null;
            }
            catch (Exception) { } // i dont even know man, someone else handle this
            log.Info("Closed AddonManager IPC Talk.");
        }

        public AddonManagerTalk()
        {
            isAddonManagerRunning = false;
            isWaitingForClient = true;
        }
    }
}