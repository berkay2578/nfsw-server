using System;
using NHibernate;
using OfflineServer.Servers.Database.Entities;

namespace OfflineServer.Servers.Database.Management
{
    public static class PersonaManagement
    {
        internal static ISession session;
        static PersonaManagement()
        {
            session = SessionManager.getSessionFactory().OpenSession();
        }

        public static PersonaEntity persona
        {
            get
            {
                if (Access.CurrentSession.ActivePersona != null)
                    return session.Load<PersonaEntity>(Access.CurrentSession.ActivePersona.Id);
                return null;
            }
            set
            {
                if (Access.CurrentSession.ActivePersona != null && value != null)
                {
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
            using (ITransaction transaction = session.BeginTransaction())
            {
                PersonaEntity personaEntity = session.Load<PersonaEntity>(Access.CurrentSession.ActivePersona.Id);
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
            using (ITransaction transaction = session.BeginTransaction())
            {
                PersonaEntity personaEntity = session.Load<PersonaEntity>(Access.CurrentSession.ActivePersona.Id);
                CarEntity carEntity = session.Load<CarEntity>(car.Id);
                personaEntity.removeCar(carEntity);

                session.Delete(carEntity);
                transaction.Commit();

                Int32 newIndex = Math.Max(0, Access.CurrentSession.ActivePersona.Cars.IndexOf(car) - 1);
                Access.CurrentSession.ActivePersona.Cars.Remove(car);
                Access.CurrentSession.ActivePersona.CurrentCarIndex = newIndex;
            }
        }
    }
}