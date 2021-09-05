using Microsoft.ServiceBus.Messaging;
using System;
using System.Configuration;
using System.Diagnostics;

namespace Azure_ServiceBus_MsgReceiver.Models
{
    public class Receiver
    {
        Queue msg;
       
        public Queue ReceiveMessage()
        {
            string connString = ConfigurationSettings.AppSettings["Microsoft.ServiceBus.ConnectionString"];

            QueueClient qClient = QueueClient.CreateFromConnectionString(connString, "qservice", ReceiveMode.PeekLock);
            var messages = qClient.ReceiveBatch(1);

            foreach (var item in messages)
            {
                msg = item.GetBody<Queue>();
                Console.WriteLine(msg);
                item.Complete(); //Remove Message from queue
                return msg;
            }
            return msg;
        }
    }
}
