using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AddonManager
{
    public static class Logger
    {
        public static void Setup()
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

            PatternLayout patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%date{dd/MM/yyyy hh:mm:ss.fff tt} | %logger[%method:%line] %level - %message%newline%exception";
            patternLayout.ActivateOptions();

            RollingFileAppender roller = new RollingFileAppender();
            roller.AppendToFile = false;
            roller.Encoding = Encoding.UTF8;
            roller.File = Path.Combine(AddonEx.dir_Logs, "AddonManager.log");
            roller.Layout = patternLayout;
            roller.MaxSizeRollBackups = 5;
            roller.MaximumFileSize = "5MB";
            roller.RollingStyle = RollingFileAppender.RollingMode.Size;
            roller.StaticLogFileName = true;
            roller.ActivateOptions();
            hierarchy.Root.AddAppender(roller);

            MemoryAppender memory = new MemoryAppender();
            memory.ActivateOptions();
            hierarchy.Root.AddAppender(memory);

            hierarchy.Root.Level = Level.Info;
            hierarchy.Configured = true;

            doFirstEntry();
        }

        public static void doFirstEntry()
        {
            ILog debugLogger = LogManager.GetLogger("Logger.doFirstEntry");
            debugLogger.InfoFormat("Loaded application version {0}.", Application.ProductVersion);
        }
    }
}