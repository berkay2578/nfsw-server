using NHibernate;
using OfflineServer.Servers.Database;
using OfflineServer.Servers.Database.Entities;
using System;

namespace OfflineServer
{
    /// <summary>
    /// Class containing all of the required variables and initializers to create and use a Server Engine.
    /// </summary>
    /// <remarks>This is NOT to be confused with the NFS:W Game Engines. Server Engines are custom prices and patches.</remarks>
    public class Engine
    {
        public Achievements Achievements = new Achievements();

        public static Int32 getDefaultPersonaIdx()
        {
            using (ISession session = SessionManager.getSessionFactory().OpenSession())
                return session.Load<UserEntity>(1).defaultPersonaIdx;
        }
        public static void setDefaultPersonaIdx(Int32 defaultPersonaIdx)
        {
            using (ISession session = SessionManager.getSessionFactory().OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                UserEntity userEntity = session.Load<UserEntity>(1);
                userEntity.defaultPersonaIdx = defaultPersonaIdx;
                session.Update(userEntity);
                transaction.Commit();
            }
        }
    }
}