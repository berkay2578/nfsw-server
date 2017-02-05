using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using OfflineServer.Data;
using System;
using System.Reflection;

namespace OfflineServer.Servers.Database
{
    public class SessionManager
    {
        private static ISessionFactory sessionFactory;
        public static ISessionFactory getSessionFactory()
        {
            if (sessionFactory == null)
            {
                Action<Configuration> query = delegate (Configuration config) { new SchemaUpdate(config).Execute(false, true); };
                sessionFactory = Fluently.Configure()
                  .Database(
                    SQLiteConfiguration.Standard
                    .UsingFile(DataEx.db_Server)
                  )
                  .Mappings(m =>
                        m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                  .ExposeConfiguration(query)
                  .BuildSessionFactory();
                
                return sessionFactory;
            }
            else { return sessionFactory; }
        }

        public static ISessionFactory createDatabase()
        {
            if (sessionFactory != null)
            {
                sessionFactory.Close();
                sessionFactory.Dispose();
            }

            Action<Configuration> query = delegate (Configuration config) { new SchemaExport(config).Create(false, true); };
            sessionFactory = Fluently.Configure()
                   .Database(
                     SQLiteConfiguration.Standard
                    .UsingFile(DataEx.db_Server)
                   )
                   .Mappings(m =>
                         m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                    .ExposeConfiguration(query)
                    .BuildSessionFactory();
            return sessionFactory;
        }
    }
}