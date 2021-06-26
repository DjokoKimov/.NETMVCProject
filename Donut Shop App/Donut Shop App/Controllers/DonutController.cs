using Donut_Shop_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Donut_Shop_App.Controllers
{
    public class DonutController : Controller
    {
        static List<Donut> donutList = new List<Donut>()
        {
        new Donut()
        {
            Id =1,
            Name = "Chocolate Donut",
            Calories = 100,
            Description = "Chocolate covered donut",
            Price = 50,
            Image=@"nekoeURL"
        }
        };
       
        public static List<Client> clients = new List<Client>(){
        new Client(){Name="Djoko",
        Address="Sample",
        Age=18,
        Phone="070 111 111"
        }
        };
    
        // GET: Donut
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult ShowClients(int id)
        {
            return View(clients.ElementAt(id));
        }
        public ActionResult GetAllDonuts()
        {
            return View(donutList);
        }
        public ActionResult GetAllClients()
        {
            return View(clients);
        }
        public ActionResult NewDonut()
        {
            Donut model = new Donut();
            return View(model);
        }
        public ActionResult NewClient()
        {
            Client model = new Client();
            return View(model);
        }

        [HttpPost]
        public ActionResult InsertNewDonut(Donut model)
        {
            if (!ModelState.IsValid)
            {
                return View("NewDonut",model);
            }

            donutList.Add(model);
            return View("GetAllDonuts", donutList);
        }
        [HttpPost]
        public ActionResult InsertNewClient(Client model)
        {
            if (!ModelState.IsValid)
            {
                return View("NewClient", model);
            }

            clients.Add(model);
            return View("GetAllClients", clients);
        }
        public ActionResult EditDonut(int id)
        {
            var model = donutList.ElementAt(id);
            model.Id = id;
            return View(model);
        }

        [HttpPost]
        public ActionResult EditDonut(Donut model)
        {
            if (!ModelState.IsValid)
            {
                return View("EditDonut", model);
            }
            var forUpdate = donutList.ElementAt(model.Id);
            forUpdate.Name = model.Name;
            forUpdate.Calories= model.Calories;
            forUpdate.Price= model.Price;
            forUpdate.Description= model.Description;
            forUpdate.Image= model.Image;
            return View("GetAllDonuts",donutList);
        }
        public ActionResult EditClient(int id)
        {
            var model = clients.ElementAt(id);
            model.Id = id;
            return View(model);
        }

        [HttpPost]
        public ActionResult EditClient(Client model)
        {
            if (!ModelState.IsValid)
            {
                return View("EditClient", model);
            }
            var forUpdate = clients.ElementAt(model.Id);
            forUpdate.Name = model.Name;
            forUpdate.Address = model.Address;
            forUpdate.Phone = model.Phone;
            forUpdate.Age = model.Age;
            
            return View("GetAllClients", clients);
        }
        public ActionResult DeleteDonut(int id)
        {
            donutList.RemoveAt(id);
            return View("GetAllDonuts", donutList);
        }
        public ActionResult DeleteClient(int id)
        {
            clients.RemoveAt(id);
            return View("GetAllClients", clients);
        }

    }
}