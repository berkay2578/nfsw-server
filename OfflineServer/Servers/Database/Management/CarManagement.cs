using OfflineServer.Servers.Database.Entities;

namespace OfflineServer.Servers.Database.Management
{
    public static class CarManagement
    {
        public static CarEntity car
        {
            get
            {
                if (Access.CurrentSession.ActivePersona != null)
                {
                    using (var session = SessionManager.getSessionFactory().OpenSession())
                    {
                        return session.Load<CarEntity>(Access.CurrentSession.ActivePersona.SelectedCar.Id);
                    }
                }
                return null;
            }
            set
            {
                if (Access.CurrentSession.ActivePersona != null)
                {
                    if (car != value && value != null)
                    {
                        using (var session = SessionManager.getSessionFactory().OpenSession())
                        using (var transaction = session.BeginTransaction())
                        {
                            CarEntity carEntity = session.Load<CarEntity>(Access.CurrentSession.ActivePersona.SelectedCar.Id);
                            carEntity = value;
                            session.SaveOrUpdate(carEntity);
                            transaction.Commit();
                        }
                    }
                }
            }
        }

        public static void update(this CarEntity newCar)
        {
            if (Access.CurrentSession.ActivePersona != null)
            {
                if (newCar != null)
                {
                    using (var session = SessionManager.getSessionFactory().OpenSession())
                    using (var transaction = session.BeginTransaction())
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