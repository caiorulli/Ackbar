using System.Linq;
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
        private readonly IJwtUtils _jwt;

        public CustomersController(GameGuideContext context, IJwtUtils jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        [HttpGet("GetReportUrl")]
        [ProducesResponseType(typeof(ReportUrlDto), 200)]
        public IActionResult GetReportUrl()
        {
            var userId = _jwt.GetUserIdFromContext(HttpContext.User);
            if (userId == null)
            {
                return Unauthorized();
            }
            
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