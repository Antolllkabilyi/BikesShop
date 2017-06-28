using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BikesShop.DAL.EF;
using BikesShop.DAL.Entities;
using BicycleViewModel = BikesShop.Models.BicycleViewModel;


namespace BikesShop.Controllers
{
    public class BicyclesController : Controller
    {
        private readonly BicycleContext _db = new BicycleContext();

        // GET: Bicycles
        public ActionResult Index()
        {
            var bicycles = _db.Bicycles.Include(b => b.Brand).Include(b => b.Fork).Include(b => b.FrameMaterial).Include(b => b.Gender);
            return View(bicycles.ToList());
        }

        // GET: Bicycles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BicycleEntity bicycleEntity = _db.Bicycles.Find(id);
            if (bicycleEntity == null)
            {
                return HttpNotFound();
            }
            return View(bicycleEntity);
        }

        // GET: Bicycles/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(_db.Brands, "Id", "Name");
            ViewBag.ForkId = new SelectList(_db.Forks, "Id", "Name");
            ViewBag.FrameMaterialId = new SelectList(_db.FrameMaterials, "Id", "Material");
            ViewBag.GenderId = new SelectList(_db.Genders, "Id", "Name");
            ViewBag.SizeId = new SelectList(_db.BicycleSize, "BicycleSizeId", "Name");
            ViewBag.Colors = new SelectList(_db.BicycleColors, "Id", "Name");
            return View();
        }

        // POST: Bicycles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ModelYear,Price,BrandId,GenderId,FrameMaterialId,ForkId,SizeId")] BicycleEntity bicycleEntity)
        {
            if (ModelState.IsValid)
            {
                _db.Bicycles.Add(bicycleEntity);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(_db.Brands, "Id", "Name", bicycleEntity.BrandId);
            ViewBag.ForkId = new SelectList(_db.Forks, "Id", "Name", bicycleEntity.ForkId);
            ViewBag.FrameMaterialId = new SelectList(_db.FrameMaterials, "Id", "Material", bicycleEntity.FrameMaterialId);
            ViewBag.GenderId = new SelectList(_db.Genders, "Id", "Name", bicycleEntity.GenderId);
            ViewBag.SizeId = new SelectList(_db.BicycleSize, "Id", "Name", bicycleEntity.SizeId);
            ViewBag.Colors = new SelectList(_db.BicycleColors, "Id", "Name", bicycleEntity.Colors);
          
            return View(bicycleEntity);
        }

        // GET: Bicycles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BicycleEntity bicycleEntity = _db.Bicycles.Find(id);
            if (bicycleEntity == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(_db.Brands, "Id", "Name", bicycleEntity.BrandId);
            ViewBag.ForkId = new SelectList(_db.Forks, "Id", "Name", bicycleEntity.ForkId);
            ViewBag.FrameMaterialId = new SelectList(_db.FrameMaterials, "Id", "Material", bicycleEntity.FrameMaterialId);
            ViewBag.GenderId = new SelectList(_db.Genders, "Id", "Name", bicycleEntity.GenderId);
            return View(bicycleEntity);
        }

        // POST: Bicycles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ModelYear,Price,BrandId,GenderId,FrameMaterialId,ForkId,SizeId")] BicycleEntity bicycleEntity)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(bicycleEntity).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(_db.Brands, "Id", "Name", bicycleEntity.BrandId);
            ViewBag.ForkId = new SelectList(_db.Forks, "Id", "Name", bicycleEntity.ForkId);
            ViewBag.FrameMaterialId = new SelectList(_db.FrameMaterials, "Id", "Material", bicycleEntity.FrameMaterialId);
            ViewBag.GenderId = new SelectList(_db.Genders, "Id", "Name", bicycleEntity.GenderId);
            return View(bicycleEntity);
        }

        // GET: Bicycles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BicycleEntity bicycleEntity = _db.Bicycles.Find(id);
            if (bicycleEntity == null)
            {
                return HttpNotFound();
            }
            return View(bicycleEntity);
        }

        // POST: Bicycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BicycleEntity bicycleEntity = _db.Bicycles.Find(id);
            _db.Bicycles.Remove(bicycleEntity);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
