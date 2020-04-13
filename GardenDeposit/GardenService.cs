using GardenDeposit.Contract;
using System;
using System.Linq;

namespace GardenDeposit
{
    public class GardenService : IGardenService 
    {
        private readonly GardenResource gardenResource = new GardenResource(new MongoDBHelper(new Config()));

        public void AddPlant(Plant plant)
        {
            gardenResource.Insert(plant);
        }

        public Plant GetPlant(Guid plantID)
        {
            return gardenResource.Select(plantID);
        }

        public void WaterPlant(Guid plantID, int water)
        {
            Plant plant = GetPlant(plantID);
            plant.Water = water;

            gardenResource.Update(plant);
        }

        public void RemovePlant(Guid plantID)
        {
            gardenResource.Delete(plantID);
        }

        public Plant[] GetPlants()
        {
            return gardenResource.SelectMany();
        }
    }
}
