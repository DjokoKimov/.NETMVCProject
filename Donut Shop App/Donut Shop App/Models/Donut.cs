using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donut_Shop_App.Models
{
    public class Donut
    {
        public string Name { get; set; }
        public  int Calories { get; set; }
        public  int Price { get; set; }
        public string  Description { get; set; }
        public string Image { get; set; }
    }
}