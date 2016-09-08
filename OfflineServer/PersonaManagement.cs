using NHibernate;
using OfflineServer.Servers.Database;
using OfflineServer.Servers.Database.Entities;
using System;

namespace OfflineServer
{
    public static class PersonaManagement
    {
        private static ISession session;
        private static PersonaEntity dummyEntity = new PersonaEntity();
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
                return dummyEntity; // to ensure no NullReferenceExceptions, it's just a dummy
            }
            set
            {
                if (Access.CurrentSession.ActivePersona != null)
                {
                    if (persona != value && value != null)
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
        }

        public static void update(this PersonaEntity newPersona)
        {
            if (Access.CurrentSession.ActivePersona != null)
                if (newPersona != null)
                {
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
