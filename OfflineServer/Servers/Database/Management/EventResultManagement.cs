using System.Linq;
using NHibernate;
using OfflineServer.Servers.Database.Entities;

namespace OfflineServer.Servers.Database.Management
{
    public static class EventResultManagement
    {
        public static EventResultEntity eventResult
        {
            get
            {
                if (Access.CurrentSession.ActivePersona != null)
                {
                    using (ISession session = SessionManager.getSessionFactory().OpenSession())
                    {
                        return session.Get<EventResultEntity>(Access.CurrentSession.ActivePersona.currentEventSessionId);
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
                        EventResultEntity eventResultEntity = session.Get<EventResultEntity>(Access.CurrentSession.ActivePersona.currentEventSessionId);
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
            using (ISession session = SessionManager.getSessionFactory().OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(eventResultEntity);
                transaction.Commit();

                Access.CurrentSession.EventResults.Add(new EventResult(eventResultEntity));

                return eventResultEntity;
            }
        }
    }
}