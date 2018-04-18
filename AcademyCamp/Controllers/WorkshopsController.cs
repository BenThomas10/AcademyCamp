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

namespace AcademyCamp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class WorkshopsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Workshops
        public async Task<ActionResult> Index()
        {
            var workshops = db.Workshops.Include(w => w.Event);
            return View(await workshops.ToListAsync());
        }

        // GET: Workshops/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workshop workshop = await db.Workshops.FindAsync(id);
            if (workshop == null)
            {
                return HttpNotFound();
            }
            return View(workshop);
        }

        // GET: Workshops/Create
        public ActionResult Create()
        {
            ViewBag.EventId = new SelectList(db.Events, "EventId", "Name");
            return View();
        }

        // POST: Workshops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "WorkshopId,EventId,WorkshopName")] Workshop workshop)
        {
            if (ModelState.IsValid)
            {
                db.Workshops.Add(workshop);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EventId = new SelectList(db.Events, "EventId", "Name", workshop.EventId);
            return View(workshop);
        }

        // GET: Workshops/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workshop workshop = await db.Workshops.FindAsync(id);
            if (workshop == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventId = new SelectList(db.Events, "EventId", "Name", workshop.EventId);
            return View(workshop);
        }

        // POST: Workshops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "WorkshopId,EventId,WorkshopName")] Workshop workshop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workshop).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EventId = new SelectList(db.Events, "EventId", "Name", workshop.EventId);
            return View(workshop);
        }

        // GET: Workshops/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workshop workshop = await db.Workshops.FindAsync(id);
            if (workshop == null)
            {
                return HttpNotFound();
            }
            return View(workshop);
        }

        // POST: Workshops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Workshop workshop = await db.Workshops.FindAsync(id);
            db.Workshops.Remove(workshop);
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
