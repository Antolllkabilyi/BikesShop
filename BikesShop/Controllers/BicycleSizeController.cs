using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BikesShop.BLL.DTO;
using BikesShop.BLL.Interfaces;
using BikesShop.Models;

namespace BikesShop.Controllers
{
    public class BicycleSizeController : Controller
    {
        private readonly ISizeService _sizeService;

        public BicycleSizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        // GET: BicycleSize
        public ActionResult Index(string searchString)
        {
            List<BicycleSizeViewModel> sizeViewModels;
            if (!string.IsNullOrEmpty(searchString))
            {
                sizeViewModels = _sizeService.Find(searchString)
                    .Select(t => new BicycleSizeViewModel
                    {
                        Id = t.Id,
                        Name = t.Name,
                        Size = t.Size
                    }).ToList();
            }
            else
            {
                sizeViewModels = _sizeService.GetAll()
                    .Select(t => new BicycleSizeViewModel
                    {
                        Id = t.Id,
                        Name = t.Name,
                        Size = t.Size
                    }).ToList();
            }

            return View(sizeViewModels);
        }

        // GET: BicycleSize/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BicycleSize/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Size")] BicycleSizeViewModel bicycleSizeViewModel)
        {
            if (ModelState.IsValid)
            {
                BicycleSizeDTO size = new BicycleSizeDTO
                {
                    Id = bicycleSizeViewModel.Id,
                    Name = bicycleSizeViewModel.Name,
                    Size = bicycleSizeViewModel.Size
                };

                _sizeService.Create(size);
                return RedirectToAction("Index");
            }

            return View(bicycleSizeViewModel);
        }

        // GET: BicycleSize/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sizeDto = _sizeService.GetById(id);

            if (sizeDto == null)
            {
                return HttpNotFound();
            }

            BicycleSizeViewModel size = new BicycleSizeViewModel
            {
                Id = sizeDto.Id,
                Name = sizeDto.Name,
                Size = sizeDto.Size
            };
            return View(size);
        }

        // POST: BicycleSize/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Size")] BicycleSizeViewModel bicycleSizeViewModel)
        {
            if (ModelState.IsValid)
            {
                BicycleSizeDTO size = new BicycleSizeDTO
                {
                    Id = bicycleSizeViewModel.Id,
                    Name = bicycleSizeViewModel.Name,
                    Size = bicycleSizeViewModel.Size
                };

                _sizeService.Update(size);
                return RedirectToAction("Index");
            }
            return View(bicycleSizeViewModel);
        }

        // GET: BicycleSize/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sizeDto = _sizeService.GetById(id);

            if (sizeDto == null)
            {
                return HttpNotFound();
            }

            BicycleSizeViewModel size = new BicycleSizeViewModel
            {
                Id = sizeDto.Id,
                Name = sizeDto.Name,
                Size = sizeDto.Size
            };
            return View(size);
        }

        // POST: BicycleSize/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _sizeService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _sizeService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
