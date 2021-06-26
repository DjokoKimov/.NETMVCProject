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
        public static Donut donut = new Donut()
        {
            Name = "Chocolate Donut",
            Calories = 100,
            Description = "Chocolate covered donut",
            Price = 50,
            Image=@"nekoeURL"
        };
        public static List<Client> clients = new List<Client>()
        {
        new Client(){
            Id = 1,
            Name = "Djoko",
            Address = "Sample Address",
            Phone = "070 111 111",
            Age = 20
        },
        new Client(){ 
            Id = 2,
            Name = "Test",
            Address = "Sample Address",
            Phone = "070 222 222",
            Age = 21
        },
        new Client(){
            Id = 1,
            Name = "Djoko",
            Address = "Sample Address",
            Phone = "070 111 111",
            Age = 20
        }
        };
    
        // GET: Donut
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Random()
        {
            DonutOrder model = new DonutOrder();
            model.donut = donut;
            model.clients = clients;
            return View(model);
        }
        public ActionResult ShowClients(int id)
        {
            return View(clients.ElementAt(id));
        }
    }
}