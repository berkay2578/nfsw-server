using NHibernate;
using NHibernate.Linq;
using OfflineServer.Servers.Database;
using OfflineServer.Servers.Database.Entities;
using OfflineServer.Servers.Http.Classes;
using System;
using System.Collections.Generic;
using System.Data.HashFunction;
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
                {
                    if (personaEntity.inventory.Count == 0)
                        Powerups.addPowerupsToPersona(personaEntity.id);

                    listPersonas.Add(new Persona(personaEntity));
                }
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

        public static String getHexHash(String text)
        {
            Byte[] byteHash = new JenkinsLookup2(0xABCDEF00u).ComputeHash(text);
            Array.Reverse(byteHash);
            return BitConverter.ToString(byteHash).Replace("-", String.Empty);
        }
        public static Int32 getOverflowHash(String text)
        {
            String hexHash = getHexHash(text);
            return Convert.ToInt32(hexHash, 16);
        }
    }
}