using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string AddressStreet { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
