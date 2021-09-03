using Azure_ServiceBus_MsgReceiver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Azure_ServiceBus_MsgReceiver.Controllers
{
    public class MessageSenderController : Controller
    {
        Sender obj;

        public MessageSenderController()
        {
            obj = new Sender();
        }

        // GET: OrderManager
        public ActionResult Index()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Index(Queue c)
        {
            obj.CreateOrder(c);
            ModelState.Clear();
            return View(c);
        }
       
    }
}