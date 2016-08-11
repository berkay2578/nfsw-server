using System;
using System.Text.RegularExpressions;
using OfflineServer.Servers.Http.Responses;

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

            return Serialization.SerializeObject<ProfileData>(profileData);
        }

        public static String getPersonaBaseFromList()
        {
            String postData = Access.sHttp.readInputStream();
            Match match = Regex.Match(postData, "<array:long>\\d+</array:long>");
            Int32 personaId = Int32.Parse(match.Value);

            foreach (Persona persona in Access.CurrentSession.PersonaList)
            {
                if (persona.Id == personaId)
                {
                    PersonaBase personaBase = new PersonaBase();
                    personaBase.iconIndex = persona.IconIndex;
                    personaBase.level = persona.Level;
                    personaBase.motto = persona.Motto;
                    personaBase.name = persona.Name;
                    personaBase.personaId = personaId;
                    personaBase.score = persona.score;
                    return Serialization.SerializeObject<PersonaBase>(personaBase);
                }
            }
            return "";
        }
    }
}
