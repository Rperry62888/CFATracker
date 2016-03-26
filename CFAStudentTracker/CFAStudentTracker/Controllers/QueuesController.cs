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
    public class QueuesController : Controller
    {
        private CFAEntities db = new CFAEntities();

        // GET: Queues
        public async Task<ActionResult> Index()
        {
            var queue = db.Queue.Include(q => q.Group).Include(q => q.Queue2).Include(q => q.QueueOrder);
            foreach (var item in queue)
            {
                item.SetupQueueData();
            }
            return View(await queue.ToListAsync());
        }

        // GET: Queues/Details/5
        public async Task<ActionResult> Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Queue queue = await db.Queue.FindAsync(id);
            if (queue == null)
            {
                return HttpNotFound();
            }
            return View(queue);
        }


        // GET: Queues/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(db.Group, "GroupID", "GroupName");
            ViewBag.QueueNextQueue = new SelectList(db.Queue, "QueueID", "QueueDescription");
            ViewBag.QueueOrderID = new SelectList(db.QueueOrder, "QueueOrderID", "QueueOrderDescription");
            return View();
        }

        // POST: Queues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "QueueID,QueueDescription,QueueNextQueue,GroupID,QueueOrderID")] Queue queue)
        {
            if (ModelState.IsValid)
            {
                db.Queue.Add(queue);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(db.Group, "GroupID", "GroupName", queue.GroupID);
            ViewBag.QueueNextQueue = new SelectList(db.Queue, "QueueID", "QueueDescription", queue.QueueNextQueue);
            ViewBag.QueueOrderID = new SelectList(db.QueueOrder, "QueueOrderID", "QueueOrderDescription", queue.QueueOrderID);
            return View(queue);
        }

        // GET: Queues/Edit/5
        public async Task<ActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Queue queue = await db.Queue.FindAsync(id);
            if (queue == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(db.Group, "GroupID", "GroupName", queue.GroupID);
            ViewBag.QueueNextQueue = new SelectList(db.Queue, "QueueID", "QueueDescription", queue.QueueNextQueue);
            ViewBag.QueueOrderID = new SelectList(db.QueueOrder, "QueueOrderID", "QueueOrderDescription", queue.QueueOrderID);
            return View(queue);
        }

        // POST: Queues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "QueueID,QueueDescription,QueueNextQueue,GroupID,QueueOrderID")] Queue queue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(queue).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.Group, "GroupID", "GroupName", queue.GroupID);
            ViewBag.QueueNextQueue = new SelectList(db.Queue, "QueueID", "QueueDescription", queue.QueueNextQueue);
            ViewBag.QueueOrderID = new SelectList(db.QueueOrder, "QueueOrderID", "QueueOrderDescription", queue.QueueOrderID);
            return View(queue);
        }

        // GET: Queues/Delete/5
        public async Task<ActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Queue queue = await db.Queue.FindAsync(id);
            if (queue == null)
            {
                return HttpNotFound();
            }
            return View(queue);
        }

        // POST: Queues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(short id)
        {
            Queue queue = await db.Queue.FindAsync(id);
            db.Queue.Remove(queue);
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
