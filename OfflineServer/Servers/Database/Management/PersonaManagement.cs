using System;
using NHibernate;
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
                    using (ISession session = SessionManager.getSessionFactory().OpenSession())
                    {
                        return session.Get<PersonaEntity>(Access.CurrentSession.ActivePersona.Id);
                    }
                }
                return null;
            }
            set
            {
                if (Access.CurrentSession.ActivePersona != null && value != null)
                {
                    using (ISession session = SessionManager.getSessionFactory().OpenSession())
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        PersonaEntity personaEntity = session.Load<PersonaEntity>(Access.CurrentSession.ActivePersona.Id);
                        personaEntity = value;
                        session.Update(personaEntity);
                        transaction.Commit();
                    }
                }
            }
        }

        public static CarEntity addCar(CarEntity carEntity)
        {
            using (ISession session = SessionManager.getSessionFactory().OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                PersonaEntity personaEntity = session.Get<PersonaEntity>(Access.CurrentSession.ActivePersona.Id);
                personaEntity.addCar(carEntity);

                session.Save(carEntity);
                session.Update(personaEntity);
                transaction.Commit();

                Access.CurrentSession.ActivePersona.Cars.Add(new Car(carEntity));
                Access.CurrentSession.ActivePersona.CurrentCarIndex = Access.CurrentSession.ActivePersona.Cars.Count - 1;

                return carEntity;
            }
        }
        public static void removeCar(Car car)
        {
            using (ISession session = SessionManager.getSessionFactory().OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                PersonaEntity personaEntity = session.Get<PersonaEntity>(Access.CurrentSession.ActivePersona.Id);
                CarEntity carEntity = session.Get<CarEntity>(car.Id);
                personaEntity.removeCar(carEntity);

                Access.CurrentSession.ActivePersona.Cars.Remove(car);

                session.Delete(carEntity);
                transaction.Commit();
            }
        }

        public static void update(this PersonaEntity newPersona)
        {
            if (newPersona != null)
            {
                using (ISession session = SessionManager.getSessionFactory().OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
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