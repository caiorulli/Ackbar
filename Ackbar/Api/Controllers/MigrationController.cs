using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ackbar.Api.Controllers
{
    public class MigrationController : Controller
    {
        private readonly GameGuideContext _db;

        public MigrationController(GameGuideContext dbContext)
        {
            _db = dbContext;
        }

        public IActionResult Index()
        {
            try
            {
                _db.Database.Migrate();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);   
            }
        }
    }
}