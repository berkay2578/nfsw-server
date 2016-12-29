using NHibernate;
using OfflineServer.Servers.Database.Entities;

namespace OfflineServer.Servers.Database.Management
{
    public static class CarManagement
    {
        private static ISession session;
        static CarManagement()
        {
            session = SessionManager.getSessionFactory().OpenSession();
        }

        public static CarEntity car
        {
            get
            {
                if (Access.CurrentSession.ActivePersona != null)
                    return session.Load<CarEntity>(Access.CurrentSession.ActivePersona.SelectedCar.Id);
                return null;
            }
            set
            {
                if (Access.CurrentSession.ActivePersona != null)
                {
                    if (car != value && value != null)
                    {
                        using (ITransaction transaction = session.BeginTransaction())
                        {
                            CarEntity CarEntity = session.Load<CarEntity>(Access.CurrentSession.ActivePersona.SelectedCar.Id);
                            CarEntity = value;
                            session.Update(CarEntity);
                            transaction.Commit();
                        }
                    }
                }
            }
        }

        public static void update(this CarEntity newCar)
        {
            if (newCar != null)
            {
                if (Access.CurrentSession.ActivePersona != null)
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        CarEntity CarEntity = session.Load<CarEntity>(newCar.id);
                        CarEntity = newCar;
                        session.Update(CarEntity);
                        transaction.Commit();
                    }
                }
            }
        }
    }
}