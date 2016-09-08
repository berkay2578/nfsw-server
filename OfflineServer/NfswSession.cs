using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;

namespace OfflineServer
{
    public class NfswSession : ObservableObject
    {
        public static SQLiteConnection dbConnection = new SQLiteConnection("Data Source=\"ServerData\\Personas.db\";Version=3;");
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Engine Engine = new Engine();
        private Persona activePersona;
        private ObservableCollection<Persona> personaList;
        public Persona ActivePersona
        {
            get { return activePersona; }
            set
            {
                if (activePersona != value)
                {
                    Engine.setDefaultPersonaIdx(personaList.IndexOf(personaList.First<Persona>(p => p.Id == value.Id)));
                    activePersona = value;
                    RaisePropertyChangedEvent("ActivePersona");
                }
            }
        }
        public ObservableCollection<Persona> PersonaList
        {
            get { return personaList; }
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
            dbConnection.Open();

            PersonaList = Persona.getCurrentPersonaList();
            ActivePersona = personaList[Engine.getDefaultPersonaIdx()];

            log.Info("Session started.");
        }
    }
}