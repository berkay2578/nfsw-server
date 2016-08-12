using OfflineServer.Servers.Http.Responses;
using System;

namespace OfflineServer.Servers.Http.Classes
{
    public static class User
    {
        public static String secureLoginPersona()
        {
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
            String str = Serialization.SerializeObject<UserInfo>(userInfo);
            return str;
        }
    }
}
