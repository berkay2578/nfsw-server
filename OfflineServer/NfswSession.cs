using System.Collections.Generic;
using System.Data.SQLite;

namespace OfflineServer
{
    public class NfswSession : ObservableObject
    {
        public static SQLiteConnection dbConnection = new SQLiteConnection("Data Source=\"Server Data\\PersonaData.db\";Version=3;");
        public Engine mEngine = new Engine();
        private Persona _mPersona;
        public Persona mPersona
        {
            get { return _mPersona; }
            set
            {
                if (this._mPersona != value)
                {
                    this._mPersona = value;
                    RaisePropertyChangedEvent("mPersona");
                }
            }
        }
        private List<Persona> _mPersonaList;
        public List<Persona> mPersonaList
        {
            get { return _mPersonaList; }
            set { if (_mPersonaList != value) { _mPersonaList = value; RaisePropertyChangedEvent("mPersonaList"); } }
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