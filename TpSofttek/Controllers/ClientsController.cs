using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpSofttek.Data;
using TpSofttek.Models;

namespace TpSofttek.Controllers
{
    public class ClientsController : Controller
    {
        DataClient dataClient = new DataClient();
        public IActionResult SaveClient()
        {
            return View();
        }
        public IActionResult ListClient()
        {
            var listClients = dataClient.modelClients();
            return View(listClients);
        }
        [HttpPost]
        public IActionResult SaveClient(ModelClient modelClient)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var response = dataClient.SaveClient(modelClient);

            if (response)
            {
                return RedirectToAction("ListClient");
            }
            else
                return View();
        }
        public IActionResult EditClient(int id)
        {
            var listClients = dataClient.GetClient(id);

            return View(listClients);
        }
        [HttpPost]
        public IActionResult EditClient(ModelClient modelClient)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            var response = dataClient.EditClient(modelClient);

            if (response)
            {
                return RedirectToAction("ListClient");
            }
            else
                return View();
        }
        public IActionResult DeleteClient(int id)
        {
            var listClients = dataClient.GetClient(id);
            {
                return View(listClients);
            }
        }
            [HttpPost]
           public IActionResult DeleteClient(ModelClient modelClient)
        {
            var response = dataClient.DeleteClient(modelClient.Id);


            if (response)
            {
                return RedirectToAction("ListClient");
            }
            else
                return View();            
        }
    }
}
