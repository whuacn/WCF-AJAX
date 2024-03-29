﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.17929
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wcf.Streaming.Client.ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.cnblogs.com/startcaft/", ConfigurationName="ServiceReference.IWCFService")]
    public interface IWCFService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.cnblogs.com/startcaft/IWCFService/DownLoadStreamData", ReplyAction="http://www.cnblogs.com/startcaft/IWCFService/DownLoadStreamDataResponse")]
        System.IO.MemoryStream DownLoadStreamData(string fileName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.cnblogs.com/startcaft/IWCFService/DownLoadStreamData", ReplyAction="http://www.cnblogs.com/startcaft/IWCFService/DownLoadStreamDataResponse")]
        System.Threading.Tasks.Task<System.IO.MemoryStream> DownLoadStreamDataAsync(string fileName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.cnblogs.com/startcaft/IWCFService/DownLoadStreamDataOut", ReplyAction="http://www.cnblogs.com/startcaft/IWCFService/DownLoadStreamDataOutResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="stream")]
        System.IO.MemoryStream DownLoadStreamDataOut(string fileName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.cnblogs.com/startcaft/IWCFService/DownLoadStreamDataOut", ReplyAction="http://www.cnblogs.com/startcaft/IWCFService/DownLoadStreamDataOutResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="stream")]
        System.Threading.Tasks.Task<System.IO.MemoryStream> DownLoadStreamDataOutAsync(string fileName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.cnblogs.com/startcaft/IWCFService/UpLoadStreamData")]
        void UpLoadStreamData(System.IO.Stream stream);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.cnblogs.com/startcaft/IWCFService/UpLoadStreamData")]
        System.Threading.Tasks.Task UpLoadStreamDataAsync(System.IO.Stream stream);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWCFServiceChannel : Wcf.Streaming.Client.ServiceReference.IWCFService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WCFServiceClient : System.ServiceModel.ClientBase<Wcf.Streaming.Client.ServiceReference.IWCFService>, Wcf.Streaming.Client.ServiceReference.IWCFService {
        
        public WCFServiceClient() {
        }
        
        public WCFServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WCFServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WCFServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WCFServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.IO.MemoryStream DownLoadStreamData(string fileName) {
            return base.Channel.DownLoadStreamData(fileName);
        }
        
        public System.Threading.Tasks.Task<System.IO.MemoryStream> DownLoadStreamDataAsync(string fileName) {
            return base.Channel.DownLoadStreamDataAsync(fileName);
        }
        
        public System.IO.MemoryStream DownLoadStreamDataOut(string fileName) {
            return base.Channel.DownLoadStreamDataOut(fileName);
        }
        
        public System.Threading.Tasks.Task<System.IO.MemoryStream> DownLoadStreamDataOutAsync(string fileName) {
            return base.Channel.DownLoadStreamDataOutAsync(fileName);
        }
        
        public void UpLoadStreamData(System.IO.Stream stream) {
            base.Channel.UpLoadStreamData(stream);
        }
        
        public System.Threading.Tasks.Task UpLoadStreamDataAsync(System.IO.Stream stream) {
            return base.Channel.UpLoadStreamDataAsync(stream);
        }
    }
}
