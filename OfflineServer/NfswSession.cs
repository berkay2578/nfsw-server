using System.Collections.ObjectModel;
using System.Data.SQLite;

namespace OfflineServer
{
    public class NfswSession : ObservableObject
    {
        public static SQLiteConnection dbConnection = new SQLiteConnection("Data Source=\"ServerData\\PersonaData.db\";Version=3;");

        public Engine mEngine = new Engine();
        private Persona _ActivePersona;
        private ObservableCollection<Persona> _PersonaList;
        public Persona ActivePersona
        {
            get { return _ActivePersona; }
            set
            {
                if (_ActivePersona != value)
                {
                    _ActivePersona = value;
                    RaisePropertyChangedEvent("ActivePersona");
                }
            }
        }
        public ObservableCollection<Persona> PersonaList
        {
            get { return _PersonaList; }
            set
            {
                if (_PersonaList != value)
                {
                    _PersonaList = value;
                    RaisePropertyChangedEvent("PersonaList");
                }
            }
        }
        public string PermanentSession;
        public string UserSettings;

        public void StartSession()
        {
            dbConnection.Open();

            PersonaList = Persona.GetCurrentPersonaList();
            ActivePersona = PersonaList[0];


            //long readSessionIdAndCalculated = 0002;
            //    Persona.SetPersona(readSessionIdAndCalculated);
        }
    }
}