using NHibernate;
using OfflineServer.Servers.Database;
using OfflineServer.Servers.Database.Entities;
using System;
using System.Collections.Generic;
using NHibernate.Linq;
using System.Linq;

namespace OfflineServer
{
    /// <summary>
    /// Class containing all of the required variables and initializers to create and use a Server Engine.
    /// </summary>
    /// <remarks>This is NOT to be confused with the NFS:W Game Engines. Server Engines are custom prices and patches.</remarks>
    public class Engine
    {
        public Achievements Achievements = new Achievements();

        public static Int32 getDefaultPersonaIdx()
        {
            using (ISession session = SessionManager.getSessionFactory().OpenSession())
                return session.Load<UserEntity>(1).defaultPersonaIdx;
        }
        public static void setDefaultPersonaIdx(Int32 defaultPersonaIdx)
        {
            using (ISession session = SessionManager.getSessionFactory().OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                UserEntity userEntity = session.Load<UserEntity>(1);
                userEntity.defaultPersonaIdx = Math.Max(0, defaultPersonaIdx);
                session.Update(userEntity);
                transaction.Commit();
            }
        }

        /// <summary>
        /// Reads the registered personas inside the session-db.
        /// </summary>
        /// <remarks>This is NOT dynamic, this only reads from the database.</remarks>
        /// <returns>An initialized <see cref="List{Persona}"/> containing the database entries for the personas.</returns>
        public static List<Persona> getCurrentPersonaList()
        {
            List<Persona> listPersonas = new List<Persona>();
            using (var session = SessionManager.getSessionFactory().OpenSession())
            {
                List<PersonaEntity> personaEntities = session.Query<PersonaEntity>().OrderBy(p => p.id).ToList();
                foreach (PersonaEntity personaEntity in personaEntities)
                    listPersonas.Add(new Persona(personaEntity));
            }

            return listPersonas;
        }

        /// <summary>
        /// Reads the written event results inside the session-db.
        /// </summary>
        /// <remarks>This is NOT dynamic, this only reads from the database.</remarks>
        /// <returns>An initialized <see cref="List{EventResult}"/> containing the database entries for the event results.</returns>
        public static List<EventResult> getEventResults()
        {
            List<EventResult> listEventResults = new List<EventResult>();
            using (var session = SessionManager.getSessionFactory().OpenSession())
            {
                List<EventResultEntity> eventResultEntities = session.Query<EventResultEntity>()
                    .OrderBy(er => er.personaName).ThenBy(er => er.carName).ThenBy(er => er.eventId)
                    .ToList();
                foreach (EventResultEntity eventResultEntity in eventResultEntities)
                    listEventResults.Add(new EventResult(eventResultEntity));
            }

            return listEventResults;
        }
    }
}