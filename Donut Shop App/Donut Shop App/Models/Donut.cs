using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Donut_Shop_App.Models
{
    public class Donut
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        public virtual ICollection<Client> clients { get; set; }

        public Donut()
        {
            clients = new List<Client>();
        }
    }

}