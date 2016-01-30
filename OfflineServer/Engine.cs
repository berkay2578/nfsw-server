using System;

namespace OfflineServer
{
    /// <summary>
    /// Class containing all of the required variables and initializers to create and use a Server Engine.
    /// </summary>
    /// <remarks>This is NOT to be confused with the NFS:W Game Engines. Server Engines are custom prices and patches.</remarks>
    public class Engine
    {
        /// <summary>
        /// For future use.
        /// </summary>
        public enum EngineType
        {
            Default = 0,
            Custom = 1,
            Debug = 2
        }

        public Int32 iEngineIndex = 0;
        public Achievements mAchievements = new Achievements();
        public ServerAPI mServerDataAPI;

        public void LoadEngine(EngineType mEngine, Int32 EngineIndex = 0)
        {
            switch (mEngine)
            {
                case EngineType.Default:
                    break;
                case EngineType.Custom:
                    break;
                case EngineType.Debug:
                    break;
            }
        }
    }
}