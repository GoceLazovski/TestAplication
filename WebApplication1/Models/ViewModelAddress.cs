using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ViewModelAddress
    {
        public string AddressStreet { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
