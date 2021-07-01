using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Donut_Shop_App.Models
{
    public class DonutsContext: DbContext
    {
        public DbSet<Client> clients { get; set; }
        public DbSet<Donut> donuts{ get; set; }
        public DonutsContext(): base("DefaultConnection") { }
        public static DonutsContext Create()
        {
            return new DonutsContext();
        }
    }
}