using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CFAStudentTracker.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace CFAStudentTracker.Controllers
{
    public class UserQueueController : Controller
    {
        private CFAEntities db = new CFAEntities();
        // GET: UserQueue
        public ActionResult Index()
        {
            var queues = db.GetQueues(User.Identity.GetUserName()).ToList<GetQueues_Result>();
            if(queues.Count > 0)
            {
                var records = db.UserQueue(User.Identity.GetUserName(), 1).ToList<UserQueue_Result>();
                return View(records);
            }
            else
            {
                return null;
            }
        }

        // GET: UserQueue/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserQueue/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserQueue/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserQueue/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserQueue/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserQueue/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserQueue/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
