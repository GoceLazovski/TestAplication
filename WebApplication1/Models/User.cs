using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        
        public ICollection<Address> Addresses { get; set; }
    }
}
