using NHibernate;
using OfflineServer.Servers.Database;
using OfflineServer.Servers.Database.Entities;
using System;

namespace OfflineServer
{
    public static class PersonaManagement
    {
        private static ISession session;
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
                return new PersonaEntity(); // to ensure no NullReferenceExceptions, it's just a dummy
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

        public static Int32 getDefaultPersonaIdx()
        {
            return session.Load<UserEntity>(1).defaultPersonaIdx;
        }
        public static void setDefaultPersonaIdx(Int32 defaultPersonaIdx)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                UserEntity userEntity = session.Load<UserEntity>(1);
                userEntity.defaultPersonaIdx = defaultPersonaIdx;
                session.Update(userEntity);
                transaction.Commit();
            }
        }
    }
}
