using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AddonManager
{
    public static class Program
    {
        private static String getPath(this String sourceString, String prefix)
        {
            return Regex.Match(sourceString, prefix + " '(.*?)'").Groups[1].Value;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if !DEBUG
            string addonPath = null;
            bool setupIPCTalk = false;
            int port = -1;
            string paths = String.Join(" ", args);

            AddonEx.dir_HttpServerCatalogs = paths.getPath("/catalogs");
            AddonEx.dir_HttpServerBaskets = paths.getPath("/baskets");
            AddonEx.dir_Accents = paths.getPath("/accents");
            AddonEx.dir_Themes = paths.getPath("/themes");
            AddonEx.dir_Languages = paths.getPath("/languages");
            AddonEx.dir_MemoryPatches = paths.getPath("/memorypatches");
            AddonEx.dir_Logs = paths.getPath("/logs");

            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i];

                if (arg == "/offlineServer")
                {
                    setupIPCTalk = true;
                    port = Convert.ToInt32(args[i + 1]);
                    Console.WriteLine("Detected /offlineServer, will be setting up IPC Talk on port {0}.", port);
                }
                else if (arg == "/installAddon")
                {
                    Console.WriteLine("Detected /installaddon, checking if given addon path is valid.");
                    if (i + 1 < args.Length)
                    {
                        string addonDir = paths.getPath("/installAddon");
                        if (File.Exists(addonDir))
                        {
                            Console.WriteLine("installAddon: Given addon path is valid, will be installing " + Path.GetFileName(addonDir));
                            addonPath = addonDir;
                        }
                    }
                }
            }

            if (String.IsNullOrWhiteSpace(AddonEx.dir_HttpServerCatalogs)
                || String.IsNullOrWhiteSpace(AddonEx.dir_HttpServerBaskets)
                || String.IsNullOrWhiteSpace(AddonEx.dir_Accents)
                || String.IsNullOrWhiteSpace(AddonEx.dir_Themes)
                || String.IsNullOrWhiteSpace(AddonEx.dir_Languages)
                || String.IsNullOrWhiteSpace(AddonEx.dir_MemoryPatches)
                || String.IsNullOrWhiteSpace(AddonEx.dir_Logs))
            {
                Console.WriteLine("Correct usage example:\r\n{0}\r\nTo automatically install an addon:\r\n{1}\r\nArgument order isn't important.\r\n{2}",
                    @"AddonManager /catalogs 'path' /baskets 'path' /accents 'path' /themes 'path' /languages 'path' /memorypatches 'path' /logs 'path'",
                    @"AddonManager /catalogs 'path' /baskets 'path' /accents 'path' /themes 'path' /languages 'path' /memorypatches 'path' /logs 'path' /installAddon 'path'",
                    @"Each variable 'path' do not need to be escaped."
                    );
                Environment.Exit(0);
                return;
            }

            Application.Run(new MainForm(Properties.Settings.Default.hasRunManagerBefore, addonPath, setupIPCTalk, port));
#else
            AddonEx.dir_HttpServerCatalogs = @"Data\Server\Catalogs\";
            AddonEx.dir_HttpServerBaskets = @"Data\Server\Baskets\";
            AddonEx.dir_Accents = @"Data\UI\Accents\";
            AddonEx.dir_Themes = @"Data\UI\Themes\";
            AddonEx.dir_Languages = @"Data\UI\Languages\";
            AddonEx.dir_MemoryPatches = @"Data\Others\Memory Patches\";
            AddonEx.dir_Logs = @"Data\Logs\";

            Application.Run(new MainForm(true, null, false));
#endif
        }
    }
}