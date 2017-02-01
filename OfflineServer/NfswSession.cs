using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace OfflineServer
{
    public class NfswSession : ObservableObject
    {
        private object threadSafeDummy = new object();
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Engine Engine = new Engine();
        private Persona activePersona;
        private ObservableCollection<Persona> personaList;
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
                    Engine.setDefaultPersonaIdx(personaList.IndexOf(value));
                    activePersona = value;
                    RaisePropertyChangedEvent("ActivePersona");
                }
            }
        }
        public ObservableCollection<Persona> PersonaList
        {
            get
            {
                return personaList;
            }
            set
            {
                if (personaList != value)
                {
                    personaList = value;
                    RaisePropertyChangedEvent("PersonaList");
                }
            }
        }

        public void startSession()
        {
            PersonaList = new ObservableCollection<Persona>(Persona.getCurrentPersonaList());
            System.Windows.Data.BindingOperations.EnableCollectionSynchronization(PersonaList, threadSafeDummy);

            ActivePersona = personaList[Engine.getDefaultPersonaIdx()];

            log.Info("Session started.");
        }
    }
}