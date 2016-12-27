using OfflineServer.Servers.Http.Responses;
using System;
using System.Text.RegularExpressions;
using OfflineServer.Servers.Database.Management;

namespace OfflineServer.Servers.Http.Classes
{
    public static class DriverPersona
    {
        public static String getPersonaInfo()
        {
            ProfileData profileData = new ProfileData();
            Persona activePersona = Access.CurrentSession.ActivePersona;
            profileData.boost = activePersona.Boost;
            profileData.cash = activePersona.Cash;
            profileData.iconIndex = activePersona.IconIndex;
            profileData.level = activePersona.Level;
            profileData.motto = activePersona.Motto;
            profileData.name = activePersona.Name;
            profileData.percentToLevel = activePersona.PercentageOfLevelCompletion;
            profileData.personaId = activePersona.Id;
            profileData.rating = activePersona.rating;
            profileData.rep = activePersona.ReputationInTotal;
            profileData.repAtCurrentLevel = activePersona.ReputationInLevel;
            profileData.score = activePersona.score;

            return profileData.SerializeObject();
        }

        public static String getPersonaBaseFromList()
        {
            Match match = Regex.Match(Access.sHttp.getPostData(), "<array:long>(\\d+)</array:long>");
            Int32 personaId = Int32.Parse(match.Groups[1].Value);

            foreach (Persona persona in Access.CurrentSession.PersonaList)
            {
                if (persona.Id == personaId)
                {
                    ArrayOfPersonaBase arrayOfPersonaBase = new ArrayOfPersonaBase();
                    PersonaBase personaBase = new PersonaBase();
                    personaBase.iconIndex = persona.IconIndex;
                    personaBase.level = persona.Level;
                    personaBase.motto = persona.Motto;
                    personaBase.name = persona.Name;
                    personaBase.personaId = personaId;
                    personaBase.score = persona.score;
                    arrayOfPersonaBase.personaBase = personaBase;
                    return arrayOfPersonaBase.SerializeObject();
                }
            }
            return "";
        }

        public static String updateStatusMessage()
        {
            String mottoXml = Access.sHttp.getPostData();
            PersonaMotto personaMotto = mottoXml.DeserializeObject<PersonaMotto>();
            Access.CurrentSession.ActivePersona.Motto = personaMotto.message;
            return mottoXml;
        }
    }
}