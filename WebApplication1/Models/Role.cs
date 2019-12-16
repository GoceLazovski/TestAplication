using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}

