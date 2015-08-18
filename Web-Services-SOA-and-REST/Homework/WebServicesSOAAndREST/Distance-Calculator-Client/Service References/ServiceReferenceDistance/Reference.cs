﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Distance_Calculator_Client.ServiceReferenceDistance {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Point", Namespace="http://schemas.datacontract.org/2004/07/System.Drawing")]
    [System.SerializableAttribute()]
    public partial struct Point : System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int xField;
        
        private int yField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int x {
            get {
                return this.xField;
            }
            set {
                if ((this.xField.Equals(value) != true)) {
                    this.xField = value;
                    this.RaisePropertyChanged("x");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int y {
            get {
                return this.yField;
            }
            set {
                if ((this.yField.Equals(value) != true)) {
                    this.yField = value;
                    this.RaisePropertyChanged("y");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceDistance.IDistanceService")]
    public interface IDistanceService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistanceService/CalculateDistance", ReplyAction="http://tempuri.org/IDistanceService/CalculateDistanceResponse")]
        double CalculateDistance(Distance_Calculator_Client.ServiceReferenceDistance.Point startPoint, Distance_Calculator_Client.ServiceReferenceDistance.Point endPoint);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistanceService/CalculateDistance", ReplyAction="http://tempuri.org/IDistanceService/CalculateDistanceResponse")]
        System.Threading.Tasks.Task<double> CalculateDistanceAsync(Distance_Calculator_Client.ServiceReferenceDistance.Point startPoint, Distance_Calculator_Client.ServiceReferenceDistance.Point endPoint);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDistanceServiceChannel : Distance_Calculator_Client.ServiceReferenceDistance.IDistanceService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DistanceServiceClient : System.ServiceModel.ClientBase<Distance_Calculator_Client.ServiceReferenceDistance.IDistanceService>, Distance_Calculator_Client.ServiceReferenceDistance.IDistanceService {
        
        public DistanceServiceClient() {
        }
        
        public DistanceServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DistanceServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DistanceServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DistanceServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double CalculateDistance(Distance_Calculator_Client.ServiceReferenceDistance.Point startPoint, Distance_Calculator_Client.ServiceReferenceDistance.Point endPoint) {
            return base.Channel.CalculateDistance(startPoint, endPoint);
        }
        
        public System.Threading.Tasks.Task<double> CalculateDistanceAsync(Distance_Calculator_Client.ServiceReferenceDistance.Point startPoint, Distance_Calculator_Client.ServiceReferenceDistance.Point endPoint) {
            return base.Channel.CalculateDistanceAsync(startPoint, endPoint);
        }
    }
}
