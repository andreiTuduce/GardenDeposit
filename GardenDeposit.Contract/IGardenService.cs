using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace GardenDeposit.Contract
{
    [ServiceContract]
    public interface IGardenService
    {
        [OperationContract]
        void AddPlant(Plant plant);

        [OperationContract]
        Plant GetPlant(Guid plantID);

        [OperationContract]
        void WaterPlant(Guid plantID, int water);

        [OperationContract]
        void RemovePlant(Guid plantID);

        [OperationContract]
        Plant[] GetPlants();
        
    }

    [DataContract]
    public class Plant
    {
        [DataMember]
        public Guid ID { get; set; }

        [DataMember]
        public int Water { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }
    }
}
