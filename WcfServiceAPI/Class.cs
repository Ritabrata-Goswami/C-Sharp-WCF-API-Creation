using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfServiceAPI
{

    [DataContract]
    public class MessageResponse
    {
        [DataMember]
        public string Message { get; set; }
        [DataMember] 
        public int Status_Code { get; set; }
    }


    [DataContract]
    public class WCF_Enter
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string Gender { get; set; }
    }


    [DataContract]
    public class DeleteRequest
    {
        [DataMember]
        public int Id { get; set; }
    }
}