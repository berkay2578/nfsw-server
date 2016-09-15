using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using OfflineServer.Data;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Windows;

namespace OfflineServer
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
            roller.File = DataEx.log_Events;
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

            hierarchy.Root.Level = Level.Debug;
            hierarchy.Configured = true;

            doFirstEntry();
        }

        public static void doFirstEntry()
        {
            ILog debugLogger = LogManager.GetLogger("Logger.doFirstEntry");
            debugLogger.Debug(String.Format("Loaded application version {0}.", FileVersionInfo.GetVersionInfo(Assembly.GetCallingAssembly().Location).ProductVersion));
            if((bool)App.Current.Properties["Troubleshooting"]) debugLogger.Debug(DataEx.getDataHierarchy());
        }
    }
}