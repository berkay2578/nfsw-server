using NHibernate;
using OfflineServer.Servers.Database.Entities;
using OfflineServer.Servers.Http.Responses;
using System.Collections.Generic;

namespace OfflineServer.Servers.Database.Management
{
    public static class CarManagement
    {
        internal static ISession session;
        static CarManagement()
        {
            session = SessionManager.getSessionFactory().OpenSession();
        }

        public static CarEntity car
        {
            get
            {
                if (Access.CurrentSession.ActivePersona != null)
                    return session.Load<CarEntity>(Access.CurrentSession.ActivePersona.SelectedCar.Id);
                return null;
            }
            set
            {
                if (Access.CurrentSession.ActivePersona != null && value != null)
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        CarEntity CarEntity = session.Load<CarEntity>(Access.CurrentSession.ActivePersona.SelectedCar.Id);
                        CarEntity = value;
                        session.Update(CarEntity);
                        transaction.Commit();
                    }
                }
            }
        }

        public static void update(this CarEntity newCar)
        {
            if (newCar != null)
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    CarEntity personaEntity = session.Load<CarEntity>(newCar.id);
                    personaEntity = newCar;
                    session.Update(personaEntity);
                    transaction.Commit();
                }
            }
        }

        public static CustomCar getCustomCar(this CarEntity carEntity)
        {
            CustomCar customCar = new CustomCar();
            customCar.baseCarId = carEntity.baseCarId;
            customCar.carClassHash = carEntity.carClassHash;
            customCar.id = carEntity.id;
            customCar.name = carEntity.name;
            customCar.paints = carEntity.paints.DeserializeObject<List<CustomPaintTrans>>();
            customCar.performanceParts = carEntity.performanceParts.DeserializeObject<List<PerformancePartTrans>>();
            customCar.physicsProfileHash = carEntity.physicsProfileHash;
            customCar.rating = carEntity.rating;
            customCar.resalePrice = carEntity.resalePrice;
            customCar.skillModParts = carEntity.skillModParts.DeserializeObject<List<SkillModPartTrans>>();
            customCar.vinyls = carEntity.vinyls.DeserializeObject<List<CustomVinylTrans>>();
            customCar.visualParts = carEntity.visualParts.DeserializeObject<List<VisualPartTrans>>();

            return customCar;
        }
    }
}