using System;
using System.Linq;
using Ackbar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ackbar.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Customer")]
    public class CustomersController : Controller
    {
        private readonly GameGuideContext _context;
        private readonly IJwtUtils _jwt;

        public CustomersController(GameGuideContext context, IJwtUtils jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        [HttpGet("Info")]
        [ProducesResponseType(typeof(Customer), 200)]
        public IActionResult GetCustomerInfo()
        {
            var userId = _jwt.GetUserIdFromContext(HttpContext.User);
            if (userId == null)
            {
                return Unauthorized();
            }
            
            try {
                var customer = _context.Customers
                .Include(c => c.Reports)
                .First(p => p.User.Id == userId);
                
                return Ok(customer);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
        
    }
}