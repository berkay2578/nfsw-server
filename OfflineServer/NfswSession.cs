using System.Collections.ObjectModel;
using System.Data.SQLite;

namespace OfflineServer
{
    public class NfswSession : ObservableObject
    {
        public static SQLiteConnection dbConnection = new SQLiteConnection("Data Source=\"ServerData\\PersonaData.db\";Version=3;");
        public Engine mEngine = new Engine();
        private Persona _mPersona;
        public Persona mPersona
        {
            get { return _mPersona; }
            set
            {
                if (_mPersona != value)
                {
                    _mPersona = value;
                    RaisePropertyChangedEvent("mPersona");
                }
            }
        }
        private ObservableCollection<Persona> _mPersonaList;
        public ObservableCollection<Persona> mPersonaList
        {
            get { return _mPersonaList; }
            set
            {
                if (_mPersonaList != value)
                {
                    _mPersonaList = value;
                    RaisePropertyChangedEvent("mPersonaList");
                }
            }
        }
        public string PermanentSession;
        public string UserSettings;

        public void StartSession()
        {
            dbConnection.Open();

            mPersonaList = Persona.GetCurrentPersonaList();
            _mPersona = new Persona(mPersonaList[0]);


            //long readSessionIdAndCalculated = 0002;
            //    Persona.SetPersona(readSessionIdAndCalculated);
        }
    }
}