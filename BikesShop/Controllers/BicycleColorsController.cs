using System.Net;
using System.Web.Mvc;
using BikesShop.BLL.Interfaces;
using BikesShop.BLL.Services;
using BikesShop.DAL.Entities;

namespace BikesShop.Controllers
{
    public class BicycleColorsController : Controller
    {
        private readonly IService<BicycleColor> _colorsService;

        public BicycleColorsController(IService<BicycleColor> colorsService)
        {
            _colorsService = colorsService;
        }

        // GET: BicycleColors
        public ActionResult Index()
        {
            return View(_colorsService.GetAll());
        }

        // GET: BicycleColors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BicycleColor bicycleColor = _colorsService.GetById(id);
            if (bicycleColor == null)
            {
                return HttpNotFound();
            }
            return View(bicycleColor);
        }

        // GET: BicycleColors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BicycleColors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] BicycleColor bicycleColor)
        {
            if (ModelState.IsValid)
            {
                _colorsService.Create(bicycleColor);
                return RedirectToAction("Index");
            }

            return View(bicycleColor);
        }

        // GET: BicycleColors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BicycleColor bicycleColor = _colorsService.GetById(id);
            if (bicycleColor == null)
            {
                return HttpNotFound();
            }
            return View(bicycleColor);
        }

        // POST: BicycleColors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] BicycleColor bicycleColor)
        {
            if (ModelState.IsValid)
            {
                _colorsService.Update(bicycleColor);
                return RedirectToAction("Index");
            }
            return View(bicycleColor);
        }

        // GET: BicycleColors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BicycleColor bicycleColor = _colorsService.GetById(id);
            if (bicycleColor == null)
            {
                return HttpNotFound();
            }
            return View(bicycleColor);
        }

        // POST: BicycleColors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _colorsService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _colorsService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
