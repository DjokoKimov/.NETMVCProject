using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donut_Shop_App.Models
{
    public class DonutOrder
    {
        public Donut donut { get; set; }
        public List<Client> clients { get; set; }

        public DonutOrder()
        {
            clients = new List<Client>();
        }
    }
}