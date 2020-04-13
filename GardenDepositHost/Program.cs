using System;
using System.ServiceModel;
using GardenDeposit;
using GardenDeposit.Contract;
using System.ServiceModel.Description;

namespace GardenDepositHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8000/GardenDeposit");
            ServiceHost host = new ServiceHost(typeof(GardenService), baseAddress);

            try
            {
                host.AddServiceEndpoint(typeof(IGardenService), new WSHttpBinding(), "GardenService");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;

                host.Description.Behaviors.Add(smb);

                host.Open();
                Console.WriteLine("Service is ready!");

                Console.WriteLine("To terminate service press any key!");
                Console.ReadKey();
                host.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("Communication exception occured: {0}", ce.Message);
                host.Abort();
            }
        }
    }
}
