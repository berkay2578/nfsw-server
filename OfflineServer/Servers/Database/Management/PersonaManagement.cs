using OfflineServer.Servers.Database.Entities;

namespace OfflineServer.Servers.Database.Management
{
    public static class PersonaManagement
    {
        public static PersonaEntity persona
        {
            get
            {
                if (Access.CurrentSession.ActivePersona != null)
                {
                    using (var session = SessionManager.getSessionFactory().OpenSession())
                    {
                        return session.Load<PersonaEntity>(Access.CurrentSession.ActivePersona.Id);
                    }
                }
                return null;
            }
            set
            {
                if (Access.CurrentSession.ActivePersona != null)
                {
                    if (persona != value && value != null)
                    {
                        using (var session = SessionManager.getSessionFactory().OpenSession())
                        using (var transaction = session.BeginTransaction())
                        {
                            PersonaEntity personaEntity = session.Load<PersonaEntity>(Access.CurrentSession.ActivePersona.Id);
                            personaEntity = value;
                            session.SaveOrUpdate(personaEntity);
                            transaction.Commit();
                        }
                    }
                }
            }
        }

        public static void addCar(CarEntity carEntity)
        {
            using (var session = SessionManager.getSessionFactory().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                PersonaEntity personaEntity = session.Load<PersonaEntity>(Access.CurrentSession.ActivePersona.Id);
                personaEntity.addCar(carEntity);
                session.Save(personaEntity);
                transaction.Commit();

                Access.CurrentSession.ActivePersona.Cars.Add(new Car(carEntity));
            }                
        }

        public static void removeCar(Car car)
        {
            using (var session = SessionManager.getSessionFactory().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                CarEntity carEntity = session.Load<CarEntity>(car.Id);
                session.Delete(carEntity);
                transaction.Commit();

                Access.CurrentSession.ActivePersona.Cars.Remove(car);
            }
        }

        public static void update(this PersonaEntity newPersona)
        {
            if (Access.CurrentSession.ActivePersona != null)
            {
                if (newPersona != null)
                {
                    using (var session = SessionManager.getSessionFactory().OpenSession())
                    using (var transaction = session.BeginTransaction())
                    {
                        PersonaEntity personaEntity = session.Load<PersonaEntity>(newPersona.id);
                        personaEntity = newPersona;
                        session.Update(personaEntity);
                        transaction.Commit();
                    }
                }
            }
        }
    }
}