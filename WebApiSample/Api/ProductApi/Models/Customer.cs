using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required, StringLength(5)]
        public string Name { get; set; }
        [RegularExpression(@"^([\w\.\-]+)@(\w\-]+)((\.(\w){2,3})+)$", ErrorMessage ="Email format is not valid")]
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
