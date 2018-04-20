using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ackbar.Controllers.Admin
{
    public class MigrationController : Controller
    {
        private GameGuideContext db;

        public MigrationController(GameGuideContext dbContext)
        {
            this.db = dbContext;
        }

        public IActionResult Index()
        {
            try
            {
                db.Database.Migrate();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }
    }
}