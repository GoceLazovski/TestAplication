using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private readonly ModelsContext _context;

        public UserController(ModelsContext context)
        {
            _context = context;
        }

        //private SignInManager<IdentityUser> _signManager;
        //private UserManager<IdentityUser> _userManager;

        //public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager)
        //{
        //    _userManager = userManager;
        //    _signManager = signManager;
        //}

        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            
            return View(users);
        }

        public IActionResult SignIn()
        {
            var user = new ViewModelUser
            {
                Roles = _context.Roles.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }),
                Addresses = _context.Addresses.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.AddressStreet
                })
            };
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(ViewModelUser user) //(string FirstName)  //([Bind("Id,FirstName,LastName,UserName,Password ")] User user)
        {
            
            if (ModelState.IsValid)
            {
                var u = new User {LastName = user.LastName, FirstName = user.FirstName, UserName = user.UserName, Password = user.Password};

                var role = _context.Roles.Find(user.SelectedRoleId);
                
                var ur = new UserRole { RoleId = user.SelectedRoleId };

                var address = _context.Addresses.Find(user.SelectedAddressId);
                //address.UserId = u.Id;
                //if
                

                u.UserRoles.Add(ur);
                u.Addresses.Add(address);

                _context.Users.Add(u);
                
                await _context.SaveChangesAsync();

                return Ok();// RedirectToAction(nameof(Index));

            }

            return Ok();//RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn (ViewModelUserLogIn user)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.SerialNumber, user.Password),
            }, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(Id);
            if (user == null)
            {
                return NotFound();
            }
            return Json(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, [Bind("Id, FirstName, LastName, UserName, Password")] User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}