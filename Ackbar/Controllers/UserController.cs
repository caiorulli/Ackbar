using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ackbar.Models;

namespace Ackbar.Controllers
{
    [Route("api/login")]
    public class UserController : Controller
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;

            if (_context.Users.Count() == 0)
            {
                _context.Users.Add(new User { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        //[HttpPost]
        //public IActionResult Login([FromBody] )
    }
}