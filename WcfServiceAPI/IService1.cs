using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        // TODO: Add your service operations here


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetData/{value}", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        string GetData(string value);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/PayBill/{PayId}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string PayBill(string PayId);


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Insert", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        MessageResponse InsertData(WCF_Enter enter);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetAllData", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<WCF_Enter> GetAllData();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetSpecificData/{id}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<WCF_Enter> GetSpecificData(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/deleteData", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        MessageResponse deleteData(DeleteRequest Id);
    }
 

}
