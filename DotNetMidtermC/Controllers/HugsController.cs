using System;

using System.Data.Entity;
using System.Linq;
using System.Net;

using System.Web.Mvc;

namespace DotNetMidtermC.Controllers
{
    public class Hugsmodel
    {
        public Hugsmodel()
        {
        }
    }
    public class HugsController : Controller
       
    {
        private Models.Hug  db = new Models.HugsModel();

        // GET: Hugs
        public ActionResult Index()
        {
            var hugs = db.Hugs.Include(h => h.HugType);
            return View(hugs.ToList());
        }

        // GET: Hugs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hug hug = db.Hugs.Find(id);
            if (hug == null)
            {
                return HttpNotFound();
            }
            return View(hug);
        }

        // GET: Hugs/Create
        public ActionResult Create()
        {
            ViewBag.HugTypeId = new SelectList(db.HugTypes, "HugTypeId", "HugType1");
            return View();
        }

        // POST: Hugs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HugId,Hugee,HugTypeId,HugDate")] Hugsmodel hugsmodel)
        {
            if (hugsmodel ==null )
            {
                throw new ArgumentNullException(nameof(hugsmodel));
            }
            if (ModelState.IsValid)
            {
                db.Hugs.Add(hug);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HugTypeId = new SelectList(db.HugTypes, "HugTypeId", "HugType1", hug.HugTypeId);
            return View(hug);
        }

        // GET: Hugs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hug hug = db.Hugs.Find(id);
            if (hug == null)
            {
                return HttpNotFound();
            }
            ViewBag.HugTypeId = new SelectList(db.HugTypes, "HugTypeId", "HugType1", hug.HugTypeId);
            return View(hug);
        }

        // POST: Hugs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HugId,Hugee,HugTypeId,HugDate")] Hugsmodel hugsmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hug).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HugTypeId = new SelectList(db.HugTypes, "HugTypeId", "HugType1", hug.HugTypeId);
            return View(hug);
        }

        // GET: Hugs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hug hug = db.Hugs.Find(id);
            if (hug == null)
            {
                return HttpNotFound();
            }
            return View(hug);
        }

        // POST: Hugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hug hug = db.Hugs.Find(id);
            db.Hugs.Remove(hug);
            db.SaveChanges();
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
