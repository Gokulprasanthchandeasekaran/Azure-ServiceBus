using Azure_ServiceBus_MsgReceiver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Azure_ServiceBus_MsgReceiver.Controllers
{
    public class MessageReceiverController : Controller
    {
        Receiver obj;

        public MessageReceiverController()
        {
            obj = new Receiver();
        }

        // GET: 
        public ActionResult Index()
        {

            var Queue = new Queue()
            {

                Count = 1,
                Message = "Sandeep Singh Shekhawat"
            };


           /* foreach (var item in Queue)
            {
                var msg = item.GetBody<Queue>();
                Console.WriteLine(msg);
                item.Complete(); //Remove Message from queue
            }*/

            ViewBag.Data = Queue;
            return View();
        }


        [HttpPost]
        public ActionResult Index(Queue c)
        {
           Queue result = obj.ReceiveMessage();

            ViewBag.Count = result.Count;
            ViewBag.Message = result.Message;
            return View(c);
        }

    }
}