using System.Linq;
using System.Security.Claims;
using Ackbar.Api.Dto;
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

        public CustomersController(GameGuideContext context)
        {
            _context = context;
        }

        [HttpGet("GetReportUrl")]
        [ProducesResponseType(typeof(ReportUrlDto), 200)]
        public IActionResult GetReportUrl()
        {
            var currentUser = HttpContext.User;
            if (!currentUser.HasClaim(c => c.Type == ClaimTypes.NameIdentifier))
            {
                return Unauthorized();
            }
            var userId = long.Parse(currentUser.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            
            var customer = _context.Customers
                .Include(c => c.Reports)
                .First(p => p.User.Id == userId);
            if (customer.Reports == null)
            {
                return BadRequest();
            }
            return Ok(new ReportUrlDto
            {
                ReportUrls = customer.Reports.Select(r => r.ReportUrl).ToArray()
            });
        }
        
    }
}