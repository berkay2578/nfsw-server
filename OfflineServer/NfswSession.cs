using System.Collections.ObjectModel;
using System.Reflection;

namespace OfflineServer
{
    public class NfswSession : ObservableObject
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Engine Engine = new Engine();
        public ObservableCollection<Persona> PersonaList { get; set; } = new ObservableCollection<Persona>();
        public ObservableCollection<EventResult> EventResults { get; set; } = new ObservableCollection<EventResult>();

        private Persona activePersona;
        public Persona ActivePersona
        {
            get
            {
                return activePersona;
            }
            set
            {
                if (activePersona != value)
                {
                    Engine.setDefaultPersonaIdx(PersonaList.IndexOf(value));
                    activePersona = value;
                    RaisePropertyChangedEvent("ActivePersona");
                }
            }
        }

        public void startSession()
        {
            foreach (Persona persona in Engine.getCurrentPersonaList())
                PersonaList.Add(persona);
            ActivePersona = PersonaList[Engine.getDefaultPersonaIdx()];
            System.Windows.Data.BindingOperations.EnableCollectionSynchronization(PersonaList, new object());

            foreach (EventResult eventResult in Engine.getEventResults())
                EventResults.Add(eventResult);
            System.Windows.Data.BindingOperations.EnableCollectionSynchronization(EventResults, new object());

            log.Info("Session started.");
        }
    }
}