using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using OfflineServer.Data;

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
                    .UsingFile(DataEx.db_Server)
                  )
                  .Mappings(m =>
                        m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                  .ExposeConfiguration(config =>
                  {
                      new SchemaUpdate(config).Execute(false, true);
                  })
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

            sessionFactory = Fluently.Configure()
                   .Database(
                     SQLiteConfiguration.Standard
                    .UsingFile(DataEx.db_Server)
                   )
                   .Mappings(m =>
                         m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                   .ExposeConfiguration(config =>
                   {
                       new SchemaExport(config).Create(false, true);
                   })
                   .BuildSessionFactory();
            return sessionFactory;
        }
    }
}