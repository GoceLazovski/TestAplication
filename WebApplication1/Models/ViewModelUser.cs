using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ViewModelUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int SelectedRoleId { get; set; }
        public int? SelectedAddressId { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
        public IEnumerable<SelectListItem> Addresses { get; set; }
    }
}
