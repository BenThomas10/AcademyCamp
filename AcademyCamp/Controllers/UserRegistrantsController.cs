using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using AcademyCamp.Models;
using Microsoft.AspNet.Identity;

namespace AcademyCamp.Controllers
{
    [Authorize]
    public class UserRegistrantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //Called from Create and Edit View's Javascript to fill Workshops dropdownlist based Event dropdown selection onchange
        public JsonResult FillWorkshops(int? Event)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Workshop> Workshop = db.Workshops.Where(m => m.EventId == Event).ToList();
            return Json(Workshop, JsonRequestBehavior.AllowGet);
        }

        // GET: Filterable, sortable, and searchable Registrants of current user
        public async Task<ActionResult> Index(string sortOrder, string searchString, string filterString)
        {

            //If user is in Admin role redirect to Admin Resgistrants Index
            if (User.Identity.IsAuthenticated)
            {
                    if (User.IsInRole("Admin"))
                    {
                        return RedirectToAction("Index", "Registrants");
                    }
            }

            // Viewbag for Event dropdown filter
            var events = await db.Events.ToListAsync();
            ViewBag.EventList = new SelectList(events, "Name", "Name");

            //Viewbags for HTML Action link table header sorters
            ViewBag.EventSort = string.IsNullOrEmpty(sortOrder) ? "eventDesc" : "";
            ViewBag.FNameSort = sortOrder == "FName" ? "fnameDesc" : "FName";
            ViewBag.LNameSort = sortOrder == "LName" ? "lnameDesc" : "LName";
            ViewBag.EmailSort = sortOrder == "Email" ? "emailDesc" : "Email";
            ViewBag.AgeSort = sortOrder == "Age" ? "ageDesc" : "Age";
            ViewBag.GenderSort = sortOrder == "Gender" ? "genderDesc" : "Gender";
            ViewBag.TsizeSort = sortOrder == "Tsize" ? "tsizeDesc" : "Tsize";
            ViewBag.WorkshopSort = sortOrder == "Workshop" ? "workshopDesc" : "Workshop";

            //Create db instance for index //ONLY PERSONAL DATA
            string currentUserId = User.Identity.GetUserId();
            var registrants = db.Registrants.Where(m => m.SubmitterId == currentUserId);

            //Filter by search
            if (!String.IsNullOrEmpty(searchString))
            {
                registrants = registrants.Where(m => m.FirstName.Contains(searchString) ||
                m.LastName.Contains(searchString) ||
                m.FirstName.Contains(searchString) ||
                m.Age.ToString() == (searchString) ||
                m.Tsize.Contains(searchString) ||
                m.Workshop.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(filterString)) //Sort Filtered Data
            {
                switch (sortOrder)
                {
                    case "eventDesc":
                        registrants = registrants.OrderByDescending(m => m.Event).ThenBy(m => m.FirstName).Where(m => m.Event.Contains(filterString));
                        break;
                    case "fnameDesc":
                        registrants = registrants.OrderByDescending(m => m.FirstName).ThenBy(m => m.LastName).Where(m => m.Event.Contains(filterString));
                        break;
                    case "lnameDesc":
                        registrants = registrants.OrderByDescending(m => m.LastName).ThenBy(m => m.FirstName).Where(m => m.Event.Contains(filterString));
                        break;
                    case "emailDesc":
                        registrants = registrants.OrderByDescending(m => m.Email).ThenBy(m => m.FirstName).Where(m => m.Event.Contains(filterString));
                        break;
                    case "ageDesc":
                        registrants = registrants.OrderByDescending(m => m.Age).ThenBy(m => m.FirstName).Where(m => m.Event.Contains(filterString));
                        break;
                    case "genderDesc":
                        registrants = registrants.OrderByDescending(m => m.Gender).ThenBy(m => m.FirstName).Where(m => m.Event.Contains(filterString));
                        break;
                    case "tsizeDesc":
                        registrants = registrants.OrderByDescending(m => m.Tsize).ThenBy(m => m.FirstName).Where(m => m.Event.Contains(filterString));
                        break;
                    case "worksDesc":
                        registrants = registrants.OrderByDescending(m => m.Workshop).ThenBy(m => m.FirstName).Where(m => m.Event.Contains(filterString));
                        break;
                    case "FName":
                        registrants = registrants.OrderBy(m => m.FirstName).ThenBy(m => m.LastName).Where(m => m.Event.Contains(filterString));
                        break;
                    case "LName":
                        registrants = registrants.OrderBy(m => m.LastName).ThenBy(m => m.FirstName).Where(m => m.Event.Contains(filterString));
                        break;
                    case "Email":
                        registrants = registrants.OrderBy(m => m.Email).ThenBy(m => m.FirstName).Where(m => m.Event.Contains(filterString));
                        break;
                    case "Age":
                        registrants = registrants.OrderBy(m => m.Age).ThenBy(m => m.FirstName).Where(m => m.Event.Contains(filterString));
                        break;
                    case "Gender":
                        registrants = registrants.OrderBy(m => m.Gender).ThenBy(m => m.FirstName).Where(m => m.Event.Contains(filterString));
                        break;
                    case "Tsize":
                        registrants = registrants.OrderBy(m => m.Tsize).ThenBy(m => m.FirstName).Where(m => m.Event.Contains(filterString));
                        break;
                    case "Workshop":
                        registrants = registrants.OrderBy(m => m.Workshop).ThenBy(m => m.FirstName).Where(m => m.Event.Contains(filterString));
                        break;
                    default:
                        registrants = registrants.OrderBy(m => m.Event).ThenBy(m => m.FirstName).Where(m => m.Event.Contains(filterString));
                        break;
                }
            }
            else //Sort Unfiltered Data
            {
                switch (sortOrder)
                {
                    case "eventDesc":
                        registrants = registrants.OrderByDescending(m => m.Event).ThenBy(m => m.FirstName);
                        break;
                    case "fnameDesc":
                        registrants = registrants.OrderByDescending(m => m.FirstName).ThenBy(m => m.LastName);
                        break;
                    case "lnameDesc":
                        registrants = registrants.OrderByDescending(m => m.LastName).ThenBy(m => m.FirstName);
                        break;
                    case "emailDesc":
                        registrants = registrants.OrderByDescending(m => m.Email).ThenBy(m => m.FirstName);
                        break;
                    case "ageDesc":
                        registrants = registrants.OrderByDescending(m => m.Age).ThenBy(m => m.FirstName);
                        break;
                    case "genderDesc":
                        registrants = registrants.OrderByDescending(m => m.Gender).ThenBy(m => m.FirstName);
                        break;
                    case "tsizeDesc":
                        registrants = registrants.OrderByDescending(m => m.Tsize).ThenBy(m => m.FirstName);
                        break;
                    case "worksDesc":
                        registrants = registrants.OrderByDescending(m => m.Workshop).ThenBy(m => m.FirstName);
                        break;
                    case "FName":
                        registrants = registrants.OrderBy(m => m.FirstName).ThenBy(m => m.LastName);
                        break;
                    case "LName":
                        registrants = registrants.OrderBy(m => m.LastName).ThenBy(m => m.FirstName);
                        break;
                    case "Email":
                        registrants = registrants.OrderBy(m => m.Email).ThenBy(m => m.FirstName);
                        break;
                    case "Age":
                        registrants = registrants.OrderBy(m => m.Age).ThenBy(m => m.FirstName);
                        break;
                    case "Gender":
                        registrants = registrants.OrderBy(m => m.Gender).ThenBy(m => m.FirstName);
                        break;
                    case "Tsize":
                        registrants = registrants.OrderBy(m => m.Tsize).ThenBy(m => m.FirstName);
                        break;
                    case "Workshop":
                        registrants = registrants.OrderBy(m => m.Workshop).ThenBy(m => m.FirstName);
                        break;
                    default:
                        registrants = registrants.OrderBy(m => m.Event).ThenBy(m => m.FirstName);
                        break;
                }
            }
            return View(await registrants.ToListAsync());
        }

        // GET: Registrants/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registrant registrant = await db.Registrants.FindAsync(id);
            if (registrant == null)
            {
                return HttpNotFound();
            }
            return View(registrant);
        }

        // GET: Registrants/Create
        public async Task<ActionResult> Create()
        {
            //Populate dropdownlists
            var events = await db.Events.ToListAsync();
            var workshops = await db.Workshops.ToListAsync();
            var tsizes = new List<string>();
            tsizes.Add("S");
            tsizes.Add("M");
            tsizes.Add("L");
            tsizes.Add("XL");
            tsizes.Add("XXL");
            var genders = new List<string>();
            genders.Add("M");
            genders.Add("F");
            ViewBag.GenderList = new SelectList(genders);
            ViewBag.TsizeList = new SelectList(tsizes);
            ViewBag.EventList = new SelectList(events, "EventId", "Name");
            ViewBag.WorkshopList = new SelectList(workshops, "WorkshopId", "WorkshopName");
            return View();
        }

        // POST: Registrants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Event,FirstName,LastName,Email,Age,Gender,Tsize,Workshop,SubmitDate,SubmitterId")] Registrant registrant)
        {
            if (ModelState.IsValid)
            {
                //Add User ID and Date/Time to registrant record on save
                registrant.SubmitterId = User.Identity.GetUserId();
                registrant.SubmitDate = DateTime.Now.ToString();

                //Ensure proper case for Names
                registrant.FirstName = registrant.FirstName.First().ToString().ToUpper() + registrant.FirstName.Substring(1);
                registrant.LastName = registrant.LastName.First().ToString().ToUpper() + registrant.LastName.Substring(1);

                db.Registrants.Add(registrant);

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(registrant);
        }

        // GET: Registrants/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registrant registrant = db.Registrants.Find(id);
            if (registrant == null)
            {
                return HttpNotFound();
            }

            //Populate dropdownlists
            var events = await db.Events.ToListAsync();
            var workshops = await db.Workshops.ToListAsync();
            var tsizes = new List<string>();
            tsizes.Add("S");
            tsizes.Add("M");
            tsizes.Add("L");
            tsizes.Add("XL");
            tsizes.Add("XXL");
            var genders = new List<string>();
            genders.Add("M");
            genders.Add("F");
            ViewBag.GenderList = new SelectList(genders);
            ViewBag.TsizeList = new SelectList(tsizes);
            ViewBag.EventList = new SelectList(events, "EventId", "Name");
            ViewBag.WorkshopList = new SelectList(workshops, "WorkshopName", "WorkshopName");

            return View(registrant);
        }



        // POST: Registrants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Event,FirstName,LastName,Email,Age,Gender,Tsize,Workshop,SubmitterId,SubmitDate")] Registrant registrant)
        {
            if (ModelState.IsValid)
            {
                //Ensure proper case for Names
                registrant.FirstName = registrant.FirstName.First().ToString().ToUpper() + registrant.FirstName.Substring(1);
                registrant.LastName = registrant.LastName.First().ToString().ToUpper() + registrant.LastName.Substring(1);

                db.Entry(registrant).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(registrant);
        }

        // GET: Registrants/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registrant registrant = await db.Registrants.FindAsync(id);
            if (registrant == null)
            {
                return HttpNotFound();
            }
            return View(registrant);
        }

        // POST: Registrants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Registrant registrant = await db.Registrants.FindAsync(id);
            db.Registrants.Remove(registrant);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
