using GardenDepositClient.GardenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenDepositClient
{
    class Program
    {
        static void Main(string[] args)
        {

            GardenServiceClient serviceClient = new GardenServiceClient();
            List<Plant> plants = serviceClient.GetPlants().ToList();

            List<string> actions = new List<string>() { "--Help", "--Create", "--Select --{Name}", "Update --{Name} --{WaterNumberr}", "Remove --{Name}" };
            
            if (!args.Any())
            {
                Console.WriteLine("No action requested!");
                Console.WriteLine("Use one of the following");
                foreach (string ac in actions)
                {
                    Console.WriteLine(ac);
                }
            }
            else
            {
                switch (args[0])
                {
                    case "--Help":
                        ListActions(actions);
                        break;
                    case "--Create":
                        AddPlant(serviceClient);
                        break;
                    case "--Select":
                        ViewPlant(serviceClient, plants, args[1]);
                        break;
                    case "--Update":
                        UpdatePlant(serviceClient, plants, args[1], args[2]);
                        break;
                    case "--Remove":
                        RemovePlant(serviceClient, plants, args[1]);
                        break;
                }
            }


            Console.ReadKey();
        }

        private static void RemovePlant(GardenServiceClient serviceClient, List<Plant> plants, string v)
        {
            v = v.Replace("--", "");

            Guid plantID = plants.Find(x => x.Name == v).ID;

            serviceClient.RemovePlant(plantID);

            Console.WriteLine("Plant is removed!");
        }

        private static void UpdatePlant(GardenServiceClient serviceClient, List<Plant> plants, string v, string v2)
        {
            v = v.Replace("--", "");
            v2 = v2.Replace("--", "");
            Guid plantID = plants.Find(x => x.Name == v).ID;

            serviceClient.WaterPlant(plantID, int.Parse(v2));

            Console.WriteLine("Plant has now water of {0}", v2);
        }

        private static void ViewPlant(GardenServiceClient serviceClient, List<Plant> plants, string v)
        {
            v = v.Replace("--", "");
            Plant plant = serviceClient.GetPlant(plants.Find(x => x.Name == v).ID);

            Console.WriteLine("Plant selected has age of {0}, and water of {1}", plant.Age, plant.Water);
        }

        private static void AddPlant(GardenServiceClient serviceClient)
        {
            Console.WriteLine("Give a name to your plant: ");
            string name = Console.ReadLine();

            Plant plant = new Plant()
            {
                ID = Guid.NewGuid(),
                Age = 0,
                Water = 100,
                Name = name
            };

            serviceClient.AddPlant(plant);
            Console.WriteLine("Plant added!");
        }

        private static void ListActions(List<string> actions)
        {
            foreach (string action in actions)
            {
                Console.WriteLine(action);
            }

        }
    }

    enum Action
    {
        None = 0,
        Help = 1,
        Create = 2,
        Select = 3,
        Update = 4,
        Remove = 5
    }
}
