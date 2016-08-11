using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace OfflineServer.Servers.Database
{
    public class SessionManager
    {
        private static ISessionFactory sessionFactory;
        public ISessionFactory getSessionFactory()
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
        public ISessionFactory createDatabase()
        {
            return Fluently.Configure()
                   .Database(
                     SQLiteConfiguration.Standard
                     .UsingFile("ServerData\\Personas.db")
                   )
                   .Mappings(m =>
                         m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                    .ExposeConfiguration(BuildSchema)
                    .BuildSessionFactory();
        }
        private void BuildSchema(Configuration config)
        {
            new SchemaExport(config).Create(false, true);
        }
    }
}
