﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarRentedApplication.CarRentService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CarRentService.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/findNearestAirportList", ReplyAction="http://tempuri.org/IService1/findNearestAirportListResponse")]
        string[] findNearestAirportList(string zipcode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/findNearestAirportList", ReplyAction="http://tempuri.org/IService1/findNearestAirportListResponse")]
        System.Threading.Tasks.Task<string[]> findNearestAirportListAsync(string zipcode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/findRentedCarlList", ReplyAction="http://tempuri.org/IService1/findRentedCarlListResponse")]
        string[] findRentedCarlList(string airport, string startDate, string endDate, string pickUpTime, string dropoffTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/findRentedCarlList", ReplyAction="http://tempuri.org/IService1/findRentedCarlListResponse")]
        System.Threading.Tasks.Task<string[]> findRentedCarlListAsync(string airport, string startDate, string endDate, string pickUpTime, string dropoffTime);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : CarRentedApplication.CarRentService.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<CarRentedApplication.CarRentService.IService1>, CarRentedApplication.CarRentService.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] findNearestAirportList(string zipcode) {
            return base.Channel.findNearestAirportList(zipcode);
        }
        
        public System.Threading.Tasks.Task<string[]> findNearestAirportListAsync(string zipcode) {
            return base.Channel.findNearestAirportListAsync(zipcode);
        }
        
        public string[] findRentedCarlList(string airport, string startDate, string endDate, string pickUpTime, string dropoffTime) {
            return base.Channel.findRentedCarlList(airport, startDate, endDate, pickUpTime, dropoffTime);
        }
        
        public System.Threading.Tasks.Task<string[]> findRentedCarlListAsync(string airport, string startDate, string endDate, string pickUpTime, string dropoffTime) {
            return base.Channel.findRentedCarlListAsync(airport, startDate, endDate, pickUpTime, dropoffTime);
        }
    }
}
