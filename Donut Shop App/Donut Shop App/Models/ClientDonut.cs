using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donut_Shop_App.Models
{
    public class ClientDonut
    {   
        public Donut donuts { get; set; }
        public List<Client> clients { get; set; }
        public int DonutId { get; set; }
        public  int ClientId { get; set; }
    }
}