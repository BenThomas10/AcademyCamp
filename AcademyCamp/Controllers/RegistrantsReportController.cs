using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AcademyCamp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AcademyCamp.Controllers
{
    public class RegistrantsReportController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdminReport
        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return View();
        }
        
        // GET: PersonalReport
        [Authorize]
        public ActionResult Personal()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Admin", "RegistrantsReport");
                }
            }
            return View();
        }

    }
}