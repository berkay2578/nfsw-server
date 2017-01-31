using OfflineServer.Servers.Database.Entities;
using OfflineServer.Servers.Database.Management;
using OfflineServer.Servers.Http.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace OfflineServer.Servers.Http.Classes
{
    public static class Personas
    {
        public static String baskets()
        {
            BasketTrans basketTrans = Access.sHttp.getPostData().DeserializeObject<BasketTrans>();
            CommerceResultTrans commerceResultTrans = new CommerceResultTrans();
            List<OwnedCarTrans> purchasedCars = new List<OwnedCarTrans>();

            foreach (BasketItemTrans item in basketTrans.basketItems)
            {
                for (int i = 0; i < item.quantity; i++)
                {
                    OwnedCarTrans purchasedCar = Catalog.getBasketDefinition<OwnedCarTrans>(item.productId);
                    if (purchasedCar == default(OwnedCarTrans))
                        continue;

                    CarEntity carEntity = new CarEntity();
                    carEntity.baseCarId = purchasedCar.customCar.baseCarId;
                    carEntity.durability = purchasedCar.durability;
                    carEntity.heatLevel = purchasedCar.heatLevel;
                    carEntity.paints = purchasedCar.customCar.paints.SerializeObject();
                    carEntity.performanceParts = purchasedCar.customCar.performanceParts.SerializeObject();
                    carEntity.physicsProfileHash = purchasedCar.customCar.physicsProfileHash;
                    carEntity.raceClass = purchasedCar.customCar.carClass;
                    carEntity.rating = purchasedCar.customCar.rating;
                    carEntity.resalePrice = purchasedCar.customCar.resalePrice;
                    carEntity.skillModParts = purchasedCar.customCar.skillModParts.SerializeObject();
                    carEntity.vinyls = purchasedCar.customCar.vinyls.SerializeObject();
                    carEntity.visualParts = purchasedCar.customCar.visualParts.SerializeObject();

                    carEntity = PersonaManagement.addCar(carEntity);
                    purchasedCar.id = carEntity.id;
                    purchasedCar.customCar.id = carEntity.id;

                    purchasedCars.Add(purchasedCar);
                }
            }

            commerceResultTrans.commerceItems = new List<CommerceItemTrans>();
            commerceResultTrans.inventoryItems = new List<InventoryItemTrans>() { new InventoryItemTrans() };
            commerceResultTrans.purchasedCars = purchasedCars;
            return commerceResultTrans.SerializeObject();
        }

        public static String carslots()
        {
            return Access.CurrentSession.ActivePersona.getCompleteGarage();
        }

        public static String commerce()
        {
            UpdatedCar newCar = Access.sHttp.getPostData().DeserializeObject<CommerceSessionTrans>().updatedCar;
            CommerceSessionResultTrans commerceSessionResultTrans = new CommerceSessionResultTrans();
            UpdatedCar responseCar = new UpdatedCar();

            Car curCar = Access.CurrentSession.ActivePersona.Cars[Access.CurrentSession.ActivePersona.CurrentCarIndex];
            curCar.Vinyls = XElement.Parse(newCar.customCar.vinyls.SerializeObject());
            curCar.Paints = XElement.Parse(newCar.customCar.paints.SerializeObject());
            curCar.PerformanceParts = XElement.Parse(newCar.customCar.performanceParts.SerializeObject());
            curCar.SkillModParts = XElement.Parse(newCar.customCar.skillModParts.SerializeObject());
            curCar.VisualParts = XElement.Parse(newCar.customCar.visualParts.SerializeObject());
            curCar.HeatLevel = 1;

            responseCar.customCar = newCar.customCar;
            responseCar.durability = curCar.Durability;
            responseCar.heatLevel = 1;
            responseCar.id = curCar.Id;
            responseCar.ownershipType = "CustomizedCar";

            commerceSessionResultTrans.inventoryItems = new List<InventoryItemTrans>();
            commerceSessionResultTrans.updatedCar = responseCar;
            return commerceSessionResultTrans.SerializeObject();
        }

        public static String defaultcar()
        {
            String[] splittedPath = Access.sHttp.request.Path.Split('/');
            if (splittedPath.Length == 6)
            {
                Int32 newCarId = Int32.Parse(splittedPath[5]);
                Access.CurrentSession.ActivePersona.CurrentCarIndex =
                    Access.CurrentSession.ActivePersona.Cars.IndexOf(
                        Access.CurrentSession.ActivePersona.Cars.First(c => c.Id == newCarId));

                return "";
            }

            Persona ownerPersona = Access.CurrentSession.PersonaList.First(p => p.Id == Int32.Parse(splittedPath[3]));
            if (ownerPersona.SelectedCar != null)
                return ownerPersona.SelectedCar.getCarEntry().ToString();

            return "";
        }
    }
}
