using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using BikesShop.BLL.DTO;
using BikesShop.BLL.Interfaces;
using BicycleColorViewModel = BikesShop.Models.BicycleColorViewModel;

namespace BikesShop.Controllers
{
    public class BicycleColorsController : Controller
    {
        private readonly IColorService _colorsService;

        public BicycleColorsController(IColorService colorsService)
        {
            _colorsService = colorsService;
        }

        // GET: BicycleColors
        public ActionResult Index()
        {
            var colors = new List<BicycleColorViewModel>();
            var dbcolors = _colorsService.GetAll();
            foreach (var color in dbcolors)
            {
                colors.Add(new BicycleColorViewModel
                {
                    Id = color.Id,
                    Name = color.Name
                });
            }

            return View(colors);
        }

        // GET: BicycleColors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var bicycleColor = _colorsService.GetById(id);


            if (bicycleColor == null)
            {
                return HttpNotFound();
            }

            BicycleColorViewModel color = new BicycleColorViewModel
            {
                Id = bicycleColor.Id,
                Name = bicycleColor.Name
            };
            return View(color);
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
        public ActionResult Create([Bind(Include = "Id,Name")] BicycleColorViewModel bicycleColor)
        {
            if (ModelState.IsValid)
            {
                BicycleColorDTO color = new BicycleColorDTO
                {
                    Id = bicycleColor.Id,
                    Name = bicycleColor.Name
                };

                _colorsService.Create(color);
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

            var bicycleColor = _colorsService.GetById(id);

            if (bicycleColor == null)
            {
                return HttpNotFound();
            }

            BicycleColorViewModel color = new BicycleColorViewModel
            {
                Id = bicycleColor.Id,
                Name = bicycleColor.Name
            };

            return View(color);
        }

        // POST: BicycleColors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] BicycleColorViewModel bicycleColor)
        {
            if (ModelState.IsValid)
            {
                BicycleColorDTO color = new BicycleColorDTO
                {
                    Id = bicycleColor.Id,
                    Name = bicycleColor.Name
                };
                _colorsService.Update(color);

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

            var bicycleColor = _colorsService.GetById(id);

            if (bicycleColor == null)
            {
                return HttpNotFound();
            }

            BicycleColorViewModel color = new BicycleColorViewModel
            {
                Id = bicycleColor.Id,
                Name = bicycleColor.Name
            };
          
            return View(color);
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
