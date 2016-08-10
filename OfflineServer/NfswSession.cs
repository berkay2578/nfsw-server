using System.Collections.ObjectModel;
using System.Data.SQLite;

namespace OfflineServer
{
    public class NfswSession : ObservableObject
    {
        public static SQLiteConnection dbConnection = new SQLiteConnection("Data Source=\"ServerData\\PersonaData.db\";Version=3;");

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
            ActivePersona = personaList[0];
        }
    }
}