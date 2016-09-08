using NHibernate;
using OfflineServer.Servers.Database.Entities;

namespace OfflineServer.Servers.Database.Management
{
    public static class CarManagement
    {
        private static ISession session;
        private static CarEntity dummyEntity = new CarEntity();
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
                return dummyEntity; // to ensure no NullReferenceExceptions, it's just a dummy
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
            if (Access.CurrentSession.ActivePersona != null)
                if (newCar != null)
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