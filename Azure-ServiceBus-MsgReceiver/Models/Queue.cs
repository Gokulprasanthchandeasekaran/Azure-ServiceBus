using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Azure_ServiceBus_MsgReceiver.Models
{
    [DataContract(Name = "Queue", Namespace = "Queue")]
    public class Queue
    {
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}