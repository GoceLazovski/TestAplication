using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AddressController : Controller
    {
        private readonly ModelsContext _context;

        public AddressController(ModelsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var addresses = _context.Addresses.ToList();

            return View(addresses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ViewModelAddress address)
        {
            var a = new Address { AddressStreet = address.AddressStreet};
            _context.Addresses.Add(a);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}