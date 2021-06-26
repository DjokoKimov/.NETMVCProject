using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donut_Shop_App.Models
{
    public class Client
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public  string Address { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
    }
}