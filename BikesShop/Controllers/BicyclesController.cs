using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BikesShop.DAL.Models;


namespace BikesShop.Controllers
{
    public class BicyclesController : Controller
    {
        private BicycleContext db = new BicycleContext();

        // GET: Bicycles
        public ActionResult Index()
        {
            var bicycles = db.Bicycles.Include(b => b.Brand).Include(b => b.Fork).Include(b => b.FrameMaterial).Include(b => b.Gender);
            return View(bicycles.ToList());
        }

        // GET: Bicycles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicycle bicycle = db.Bicycles.Find(id);
            if (bicycle == null)
            {
                return HttpNotFound();
            }
            return View(bicycle);
        }

        // GET: Bicycles/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name");
            ViewBag.ForkId = new SelectList(db.Forks, "Id", "Name");
            ViewBag.FrameMaterialId = new SelectList(db.FrameMaterials, "Id", "Material");
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name");
            return View();
        }

        // POST: Bicycles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ModelYear,Price,BrandId,GenderId,FrameMaterialId,ForkId,SizeId")] Bicycle bicycle)
        {
            if (ModelState.IsValid)
            {
                db.Bicycles.Add(bicycle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", bicycle.BrandId);
            ViewBag.ForkId = new SelectList(db.Forks, "Id", "Name", bicycle.ForkId);
            ViewBag.FrameMaterialId = new SelectList(db.FrameMaterials, "Id", "Material", bicycle.FrameMaterialId);
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name", bicycle.GenderId);
            ViewBag.SizeId = new SelectList(db.BicycleSize, "Id", "Name", bicycle.SizeId);
            return View(bicycle);
        }

        // GET: Bicycles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicycle bicycle = db.Bicycles.Find(id);
            if (bicycle == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", bicycle.BrandId);
            ViewBag.ForkId = new SelectList(db.Forks, "Id", "Name", bicycle.ForkId);
            ViewBag.FrameMaterialId = new SelectList(db.FrameMaterials, "Id", "Material", bicycle.FrameMaterialId);
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name", bicycle.GenderId);
            return View(bicycle);
        }

        // POST: Bicycles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ModelYear,Price,BrandId,GenderId,FrameMaterialId,ForkId,SizeId")] Bicycle bicycle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bicycle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", bicycle.BrandId);
            ViewBag.ForkId = new SelectList(db.Forks, "Id", "Name", bicycle.ForkId);
            ViewBag.FrameMaterialId = new SelectList(db.FrameMaterials, "Id", "Material", bicycle.FrameMaterialId);
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name", bicycle.GenderId);
            return View(bicycle);
        }

        // GET: Bicycles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicycle bicycle = db.Bicycles.Find(id);
            if (bicycle == null)
            {
                return HttpNotFound();
            }
            return View(bicycle);
        }

        // POST: Bicycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bicycle bicycle = db.Bicycles.Find(id);
            db.Bicycles.Remove(bicycle);
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
