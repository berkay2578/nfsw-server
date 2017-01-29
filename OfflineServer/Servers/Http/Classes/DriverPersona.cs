using OfflineServer.Data;
using OfflineServer.Servers.Database;
using OfflineServer.Servers.Database.Entities;
using OfflineServer.Servers.Http.Responses;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace OfflineServer.Servers.Http.Classes
{
    public static class DriverPersona
    {
        public static String createPersona()
        {
            String name = Access.sHttp.request.Params.Get("name");
            Int16 iconIndex = Convert.ToInt16(Access.sHttp.request.Params.Get("iconIndex"));
            ProfileData respondProfileData = new ProfileData();

            using (var session = SessionManager.getSessionFactory().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                PersonaEntity personaEntity = new PersonaEntity();
                personaEntity.boost = 0;
                personaEntity.cash = 250000;
                personaEntity.currentCarIndex = -1;
                personaEntity.iconIndex = iconIndex;
                personaEntity.level = 1;
                personaEntity.motto = "";
                personaEntity.name = name;
                personaEntity.percentageOfLevelCompletion = 0;
                personaEntity.rating = 0;
                personaEntity.reputationInLevel = 0;
                personaEntity.reputationInTotal = 0;
                personaEntity.score = 0;
                session.Save(personaEntity);

                respondProfileData.cash = 250000;
                respondProfileData.iconIndex = iconIndex;
                respondProfileData.level = 1;
                respondProfileData.name = name;
                respondProfileData.personaId = personaEntity.id;

                Access.CurrentSession.PersonaList.Add(new Persona(personaEntity));
                Int32 newDefaultPersonaIdx = Access.CurrentSession.PersonaList.Count - 1;

                UserEntity userEntity = session.CreateCriteria(typeof(UserEntity)).List<UserEntity>().First();
                userEntity.defaultPersonaIdx = newDefaultPersonaIdx;
                session.Update(userEntity);

                transaction.Commit();
            }
            return respondProfileData.SerializeObject();
        }

        public static String deletePersona()
        {
            Int32 personaId = Convert.ToInt32(Access.sHttp.request.Params.Get("personaId"));

            using (var session = SessionManager.getSessionFactory().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                PersonaEntity personaEntity = session.Load<PersonaEntity>(personaId);
                session.Delete(personaEntity);

                Access.CurrentSession.PersonaList.RemoveAt(Access.CurrentSession.PersonaList.IndexOf(
                    Access.CurrentSession.PersonaList.First<Persona>(sPersona => sPersona.Id == personaId)));

                transaction.Commit();
            }

            return "<long>0</long>";
        }

        public static String getExpLevelPointsMap()
        {
            String targetLocalFile = Path.Combine(DataEx.dir_CurrentGameplayMod, "GetExpLevelPointsMap.xml");
            if (File.Exists(targetLocalFile))
                return File.ReadAllText(targetLocalFile, Encoding.UTF8);

            return "<ArrayOfint/>";
        }

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

            try
            {
                Persona persona = Access.CurrentSession.PersonaList.First<Persona>(sPersona => sPersona.Id == personaId);

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
            catch (Exception)
            {
                return "";
            }
        }

        public static String reserveName()
        {
            return "<ArrayOfstring></ArrayOfstring>";
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