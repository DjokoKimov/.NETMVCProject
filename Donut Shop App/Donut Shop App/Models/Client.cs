using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Donut_Shop_App.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public  string Name { get; set; }
        [Required]
        public  string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [Range(1,99,ErrorMessage ="Age must be between 1 and 99")]
        public int Age { get; set; }
        
        public virtual ICollection<Donut> donuts { get; set; }

        public Client()
        {
            donuts= new List<Donut>();
        }
    }
}