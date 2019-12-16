using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RoleController : Controller
    {
        private readonly ModelsContext _context;

        public RoleController(ModelsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var role = new ViewModelRole
            {
                User = _context.Users.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.FirstName

                })
            };
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ViewModelRole role)
        {
            if (ModelState.IsValid)
            {
                var r = new Role { Name = role.Name };
                var user = _context.Users.Find(role.SelectedUserId);
                var ur = new UserRole { UserId = role.SelectedUserId };

                r.UserRoles.Add(ur);
                _context.Roles.Add(r);

                await _context.SaveChangesAsync();

                return Ok();// RedirectToAction(nameof(Index));
            }

            return Ok();//RedirectToAction("Index");
        }
    }
}