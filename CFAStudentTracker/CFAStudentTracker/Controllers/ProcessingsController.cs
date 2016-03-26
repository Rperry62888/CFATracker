using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CFAStudentTracker.Models;

namespace CFAStudentTracker.Controllers
{
    public class ProcessingsController : Controller
    {
        private CFAEntities db = new CFAEntities();

        // GET: Processings
        public async Task<ActionResult> Index(short i = 1)
        {
            var processing = db.Processing.Include(p => p.Queue).Include(p => p.Record).Include(p => p.User).Include(p => p.Record.StudentFile).Where(p => p.QueueID == i);
            foreach (var item in processing)
            {
                item.SetStatus();
            }
            return View(await processing.ToListAsync());
        }

        // GET: Processings/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Processing processing = await db.Processing.FindAsync(id);
            if (processing == null)
            {
                return HttpNotFound();
            }
            return View(processing);
        }

        // GET: Processings/Create
        public ActionResult Create()
        {
            ViewBag.QueueID = new SelectList(db.Queue, "QueueID", "QueueDescription");
            ViewBag.RecordID = new SelectList(db.Record, "RecordID", "RecordID");
            ViewBag.Username = new SelectList(db.User, "Username", "Username");
            return View();
        }

        // POST: Processings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProcID,InFilingCabinet,ProcInQueue,ProcToUser,ProcUserComplete,Username,QueueID,RecordID")] Processing processing)
        {
            if (ModelState.IsValid)
            {
                db.Processing.Add(processing);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.QueueID = new SelectList(db.Queue, "QueueID", "QueueDescription", processing.QueueID);
            ViewBag.RecordID = new SelectList(db.Record, "RecordID", "RecordID", processing.RecordID);
            ViewBag.Username = new SelectList(db.User, "Username", "Username", processing.Username);
            return View(processing);
        }

        // GET: Processings/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Processing processing = await db.Processing.FindAsync(id);
            if (processing == null)
            {
                return HttpNotFound();
            }
            ViewBag.QueueID = new SelectList(db.Queue, "QueueID", "QueueDescription", processing.QueueID);
            ViewBag.RecordID = new SelectList(db.Record, "RecordID", "RecordID", processing.RecordID);
            ViewBag.Username = new SelectList(db.User, "Username", "Username", processing.Username);
            return View(processing);
        }

        // POST: Processings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProcID,InFilingCabinet,ProcInQueue,ProcToUser,ProcUserComplete,Username,QueueID,RecordID")] Processing processing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(processing).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.QueueID = new SelectList(db.Queue, "QueueID", "QueueDescription", processing.QueueID);
            ViewBag.RecordID = new SelectList(db.Record, "RecordID", "RecordID", processing.RecordID);
            ViewBag.Username = new SelectList(db.User, "Username", "Username", processing.Username);
            return View(processing);
        }

        // GET: Processings/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Processing processing = await db.Processing.FindAsync(id);
            if (processing == null)
            {
                return HttpNotFound();
            }
            return View(processing);
        }

        // POST: Processings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Processing processing = await db.Processing.FindAsync(id);
            db.Processing.Remove(processing);
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
