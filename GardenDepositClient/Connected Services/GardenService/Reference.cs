﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GardenDepositClient.GardenService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Plant", Namespace="http://schemas.datacontract.org/2004/07/GardenDeposit.Contract")]
    [System.SerializableAttribute()]
    public partial class Plant : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AgeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int WaterField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Age {
            get {
                return this.AgeField;
            }
            set {
                if ((this.AgeField.Equals(value) != true)) {
                    this.AgeField = value;
                    this.RaisePropertyChanged("Age");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Water {
            get {
                return this.WaterField;
            }
            set {
                if ((this.WaterField.Equals(value) != true)) {
                    this.WaterField = value;
                    this.RaisePropertyChanged("Water");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GardenService.IGardenService")]
    public interface IGardenService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGardenService/AddPlant", ReplyAction="http://tempuri.org/IGardenService/AddPlantResponse")]
        void AddPlant(GardenDepositClient.GardenService.Plant plant);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGardenService/AddPlant", ReplyAction="http://tempuri.org/IGardenService/AddPlantResponse")]
        System.Threading.Tasks.Task AddPlantAsync(GardenDepositClient.GardenService.Plant plant);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGardenService/GetPlant", ReplyAction="http://tempuri.org/IGardenService/GetPlantResponse")]
        GardenDepositClient.GardenService.Plant GetPlant(System.Guid plantID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGardenService/GetPlant", ReplyAction="http://tempuri.org/IGardenService/GetPlantResponse")]
        System.Threading.Tasks.Task<GardenDepositClient.GardenService.Plant> GetPlantAsync(System.Guid plantID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGardenService/WaterPlant", ReplyAction="http://tempuri.org/IGardenService/WaterPlantResponse")]
        void WaterPlant(System.Guid plantID, int water);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGardenService/WaterPlant", ReplyAction="http://tempuri.org/IGardenService/WaterPlantResponse")]
        System.Threading.Tasks.Task WaterPlantAsync(System.Guid plantID, int water);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGardenService/RemovePlant", ReplyAction="http://tempuri.org/IGardenService/RemovePlantResponse")]
        void RemovePlant(System.Guid plantID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGardenService/RemovePlant", ReplyAction="http://tempuri.org/IGardenService/RemovePlantResponse")]
        System.Threading.Tasks.Task RemovePlantAsync(System.Guid plantID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGardenService/GetPlants", ReplyAction="http://tempuri.org/IGardenService/GetPlantsResponse")]
        GardenDepositClient.GardenService.Plant[] GetPlants();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGardenService/GetPlants", ReplyAction="http://tempuri.org/IGardenService/GetPlantsResponse")]
        System.Threading.Tasks.Task<GardenDepositClient.GardenService.Plant[]> GetPlantsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGardenServiceChannel : GardenDepositClient.GardenService.IGardenService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GardenServiceClient : System.ServiceModel.ClientBase<GardenDepositClient.GardenService.IGardenService>, GardenDepositClient.GardenService.IGardenService {
        
        public GardenServiceClient() {
        }
        
        public GardenServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GardenServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GardenServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GardenServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AddPlant(GardenDepositClient.GardenService.Plant plant) {
            base.Channel.AddPlant(plant);
        }
        
        public System.Threading.Tasks.Task AddPlantAsync(GardenDepositClient.GardenService.Plant plant) {
            return base.Channel.AddPlantAsync(plant);
        }
        
        public GardenDepositClient.GardenService.Plant GetPlant(System.Guid plantID) {
            return base.Channel.GetPlant(plantID);
        }
        
        public System.Threading.Tasks.Task<GardenDepositClient.GardenService.Plant> GetPlantAsync(System.Guid plantID) {
            return base.Channel.GetPlantAsync(plantID);
        }
        
        public void WaterPlant(System.Guid plantID, int water) {
            base.Channel.WaterPlant(plantID, water);
        }
        
        public System.Threading.Tasks.Task WaterPlantAsync(System.Guid plantID, int water) {
            return base.Channel.WaterPlantAsync(plantID, water);
        }
        
        public void RemovePlant(System.Guid plantID) {
            base.Channel.RemovePlant(plantID);
        }
        
        public System.Threading.Tasks.Task RemovePlantAsync(System.Guid plantID) {
            return base.Channel.RemovePlantAsync(plantID);
        }
        
        public GardenDepositClient.GardenService.Plant[] GetPlants() {
            return base.Channel.GetPlants();
        }
        
        public System.Threading.Tasks.Task<GardenDepositClient.GardenService.Plant[]> GetPlantsAsync() {
            return base.Channel.GetPlantsAsync();
        }
    }
}