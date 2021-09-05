using Azure_ServiceBus_MsgReceiver.Models;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Azure_ServiceBus_MsgReceiver.Controllers
{
    public class ReceiveAPIController : ApiController
    {

        [HttpGet]
        [Route("api/qreceiver")]
        public void ReceiveMessage()
        {
            //Code for Adding Message in Queue

            //S1: The NamespaceManager object used to manage queues, topics etc.
            string connString = ConfigurationSettings.AppSettings["Microsoft.ServiceBus.ConnectionString"];

            QueueClient qClient = QueueClient.CreateFromConnectionString(connString, "qservice", ReceiveMode.PeekLock);
            //BrokeredMessage message = qClient.Receive();
           
            var messages = qClient.ReceiveBatch(1);

            

            foreach (var item in messages)
            {
                var msg=item.GetBody<Queue>();
                Console.WriteLine(msg);
                item.Complete(); //Remove Message from queue
            }//Ends Here
        }

    }
}
