using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;


namespace Azure_ServiceBus_MsgReceiver.Models
{
    public class Sender
    {
        public void CreateOrder(Queue que)
        {
            Queue q = new Queue()
            {
                Count = que.Count,
                Message = que.Message
            };
           

            //Code for Adding Message in Queue

            //S1: The NamespaceManager object used to manage queues, topics etc.
            string connString = ConfigurationSettings.AppSettings["Microsoft.ServiceBus.ConnectionString"];

            /*NamespaceManager namespaceManager = NamespaceManager.CreateFromConnectionString(connString);

            //S2: The Queue Description using QueueName
            QueueDescription queue = new QueueDescription("qservice");
            queue.MaxSizeInMegabytes = 5120; //5 MB
            queue.DefaultMessageTimeToLive = new TimeSpan(0, 30, 0); //For 30 Mins
            */

            //S3: Send the Message
            QueueClient client = QueueClient.CreateFromConnectionString(connString, "qservice");
            BrokeredMessage message = new BrokeredMessage(q);

            client.Send(message);



            QueueClient qClient = QueueClient.CreateFromConnectionString(connString, "qservice", ReceiveMode.PeekLock);
            //BrokeredMessage message = qClient.Receive();



            var messages = qClient.ReceiveBatch(1);

            List<Queue> quee = new List<Queue>();


            foreach (var item in messages)
            {
                quee.Add(item.GetBody<Queue>());
                item.Complete(); //Remove Message from queue
            }//Ends Here
        }

    }
}