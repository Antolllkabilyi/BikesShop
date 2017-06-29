using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BikesShop.BLL.DTO;
using BikesShop.BLL.Interfaces;
using BikesShop.Models;

namespace BikesShop.Controllers
{
    public class BicycleTypeController : Controller
    {
        private readonly IBicycleTypeService _typeService;

        public BicycleTypeController(IBicycleTypeService typeService)
        {
            _typeService = typeService;
        }

        // GET: BicycleType
        public ActionResult Index(string searchString)
        {
            List<BicycleTypeViewModel> colors;
            if (!string.IsNullOrEmpty(searchString))
            {
                colors = _typeService.Find(searchString)
                    .Select(t => new BicycleTypeViewModel
                    {
                        Id = t.Id,
                        Name = t.Name
                    }).ToList();
            }
            else
            {
                colors = _typeService.GetAll()
                    .Select(t => new BicycleTypeViewModel
                    {
                        Id = t.Id,
                        Name = t.Name
                    }).ToList();
            }

            return View(colors);
        }


        // GET: BicycleType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BicycleType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] BicycleTypeViewModel bicycleTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                BicycleTypeDTO type = new BicycleTypeDTO
                {
                    Id = bicycleTypeViewModel.Id,
                    Name = bicycleTypeViewModel.Name
                };

                _typeService.Create(type);
                return RedirectToAction("Index");
            }

            return View(bicycleTypeViewModel);
        }

        // GET: BicycleType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var bicycleTypeDto = _typeService.GetById(id);

            if (bicycleTypeDto == null)
            {
                return HttpNotFound();
            }

            BicycleTypeViewModel type = new BicycleTypeViewModel
            {
                Id = bicycleTypeDto.Id,
                Name = bicycleTypeDto.Name
            };

            return View(type);
        }

        // POST: BicycleType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] BicycleTypeViewModel bicycleTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                BicycleTypeDTO type = new BicycleTypeDTO
                {
                    Id = bicycleTypeViewModel.Id,
                    Name = bicycleTypeViewModel.Name
                };
                _typeService.Update(type);
                return RedirectToAction("Index");
            }
            return View(bicycleTypeViewModel);
        }

        // GET: BicycleType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bicycleType = _typeService.GetById(id);

            if (bicycleType == null)
            {
                return HttpNotFound();
            }

            BicycleTypeViewModel type = new BicycleTypeViewModel
            {
                Id = bicycleType.Id,
                Name = bicycleType.Name
            };
            return View(type);
        }

        // POST: BicycleType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _typeService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _typeService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
