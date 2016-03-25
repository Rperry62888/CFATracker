using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CFAStudentTracker.Models;

namespace CFAStudentTracker.Controllers
{
    public class StudentFileController : Controller
    {
        private CFAEntities db = new CFAEntities();
        // GET: StudentFile
        public ActionResult Index()
        {
            return View();
        }

        // GET: StudentFile/Details/5
        public ActionResult ProcessingDetails(long id = 1L)
        {
            ProcessingDetail pd = new ProcessingDetail();
            pd.Proc = (db.Processing.Where(p => p.ProcID == id).ToList<Processing>()).ElementAt(0);
            pd.Queue = (db.Queue.Where(q => q.QueueID == pd.Proc.QueueID).ToList<Queue>()).ElementAt(0);
            pd.Rec = (db.Record.Where(r => r.RecordID == pd.Proc.RecordID).ToList<Record>()).ElementAt(0);
            pd.StudFile = (db.StudentFile.Where(s => s.FileID == pd.Rec.FileID).ToList<StudentFile>()).ElementAt(0);
            pd.Notes = db.Note.Where(n => n.RecordID == pd.Rec.RecordID).ToList<Note>();
            return View(pd);
        }

        // GET: StudentFile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentFile/Create
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

        // GET: StudentFile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentFile/Edit/5
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

        // GET: StudentFile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentFile/Delete/5
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
