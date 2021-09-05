using Microsoft.Azure.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System.Configuration;
using System.Text;
using System.Text.Json;

namespace Azure_ServiceBus_MsgReceiver.Models
{
    public class Sender
    {
        public void CreateOrder(Queue que)
        {           
            string connString = ConfigurationSettings.AppSettings["Microsoft.ServiceBus.ConnectionString"];
            Microsoft.ServiceBus.Messaging.QueueClient client = Microsoft.ServiceBus.Messaging.QueueClient.CreateFromConnectionString(connString, "qservice");
            
           BrokeredMessage message = new BrokeredMessage(que);
            /*
            string messageBody = JsonSerializer.Serialize(que);
            var message = new Message(Encoding.UTF8.GetBytes(messageBody));
            Microsoft.ServiceBus.Messaging.QueueClient.SendAsync(message);
            */

            client.SendAsync(message);
        }
            
    }
}
