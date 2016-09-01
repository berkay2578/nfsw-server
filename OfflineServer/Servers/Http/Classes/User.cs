using OfflineServer.Servers.Http.Responses;
using System;
using System.Linq;

namespace OfflineServer.Servers.Http.Classes
{
    public static class User
    {
        public static String secureLoginPersona()
        {
            Int32 newPersonaId = Int32.Parse(Access.sHttp.request.Params.Get("personaId"));
            Int32 newPersonaIndex = Access.CurrentSession.PersonaList.IndexOf(Access.CurrentSession.PersonaList.First<Persona>(p => p.Id == newPersonaId));
            Access.CurrentSession.ActivePersona = Access.CurrentSession.PersonaList[newPersonaIndex];

            Access.sXmpp.initialize();
            Access.sXmpp.doLogin(Access.CurrentSession.ActivePersona.Id);
            return "";
        }
        public static String secureLogout()
        {
            Access.sXmpp.shutdown();
            Access.sXmpp = new Xmpp.BasicXmppServer();
            return "";
        }

        public static String getPermanentSession()
        {
            UserInfo userInfo = new UserInfo();
            foreach(Persona persona in Access.CurrentSession.PersonaList)
            {
                ProfileData profileData = new ProfileData();
                profileData.boost = persona.Boost;
                profileData.cash = persona.Cash;
                profileData.iconIndex = persona.IconIndex;
                profileData.level = persona.Level;
                profileData.motto = persona.Motto;
                profileData.name = persona.Name;
                profileData.percentToLevel = persona.PercentageOfLevelCompletion;
                profileData.personaId = persona.Id;
                profileData.rating = persona.rating;
                profileData.rep = persona.ReputationInTotal;
                profileData.repAtCurrentLevel = persona.ReputationInLevel;
                profileData.score = persona.score;
                userInfo.personas.Add(profileData);
            }

            userInfo.defaultPersonaIdx = Access.CurrentSession.Engine.getDefaultPersonaIdx();
            return userInfo.SerializeObject();
        }
    }
}