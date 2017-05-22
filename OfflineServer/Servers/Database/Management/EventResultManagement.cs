using NHibernate;
using OfflineServer.Servers.Database.Entities;
using System.Linq;

namespace OfflineServer.Servers.Database.Management
{
    public static class EventResultManagement
    {
        internal static ISession session;
        static EventResultManagement()
        {
            session = SessionManager.getSessionFactory().OpenSession();
        }

        public static EventResultEntity eventResult
        {
            get
            {
                if (Access.CurrentSession.ActivePersona != null)
                    return session.Load<EventResultEntity>(Access.CurrentSession.ActivePersona.currentEventSessionId);
                return null;
            }
            set
            {
                if (Access.CurrentSession.ActivePersona != null && value != null)
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        EventResultEntity eventResultEntity = session.Load<EventResultEntity>(Access.CurrentSession.ActivePersona.currentEventSessionId);
                        eventResultEntity = value;
                        session.Update(eventResultEntity);
                        transaction.Commit();

                        Access.CurrentSession.EventResults[Access.CurrentSession.EventResults.IndexOf(
                            Access.CurrentSession.EventResults.First(er => er.Id == eventResultEntity.id))] = new EventResult(eventResultEntity);
                    }
                }
            }
        }

        public static EventResultEntity addEventResult(EventResultEntity eventResultEntity)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(eventResultEntity);
                transaction.Commit();
            }
            lock (NfswSession.eventResultsLock)
            {
                Access.CurrentSession.EventResults.Add(new EventResult(eventResultEntity));
            }
            return eventResultEntity;
        }
    }
}