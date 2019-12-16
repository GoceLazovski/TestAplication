using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ViewModelRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SelectedUserId { get; set; }

        public IEnumerable<SelectListItem> User { get; set; }
    }
}
