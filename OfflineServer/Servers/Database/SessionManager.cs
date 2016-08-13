using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
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
                sessionFactory = Fluently.Configure()
                  .Database(
                    SQLiteConfiguration.Standard
                    .UsingFile("ServerData\\Personas.db")
                  )
                  .Mappings(m =>
                        m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                  .BuildSessionFactory();
                return sessionFactory;
            }
            else { return sessionFactory; }
        }
        public static ISessionFactory createDatabase()
        {
            Action<Configuration> query = delegate(Configuration config) { new SchemaExport(config).Create(false, true); };
            sessionFactory = Fluently.Configure()
                   .Database(
                     SQLiteConfiguration.Standard
                     .UsingFile("ServerData\\Personas.db")
                   )
                   .Mappings(m =>
                         m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                    .ExposeConfiguration(query)
                    .BuildSessionFactory();
            return sessionFactory;
        }
    }
}
