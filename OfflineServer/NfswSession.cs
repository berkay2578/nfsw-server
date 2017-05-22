using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Data;

namespace OfflineServer
{
    public class NfswSession : ObservableObject
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static object personaListLock = new object();
        public static object eventResultsLock = new object();

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
            App.Current.Dispatcher.Invoke(() =>
                BindingOperations.EnableCollectionSynchronization(PersonaList, personaListLock));
            App.Current.Dispatcher.Invoke(() =>
                BindingOperations.EnableCollectionSynchronization(EventResults, eventResultsLock));

            foreach (Persona persona in Engine.getCurrentPersonaList())
                PersonaList.Add(persona);
            ActivePersona = PersonaList[Engine.getDefaultPersonaIdx()];

            foreach (EventResult eventResult in Engine.getEventResults())
                EventResults.Add(eventResult);

            log.Info("Session started.");
        }
    }
}