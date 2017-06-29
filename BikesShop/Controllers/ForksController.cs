using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BikesShop.BLL.DTO;
using BikesShop.BLL.Interfaces;
using BikesShop.Models;

namespace BikesShop.Controllers
{
    public class ForksController : Controller
    {
        private readonly IForkService _forkService;

        public ForksController(IForkService forkService)
        {
            _forkService = forkService;
        }

        // GET: Forks
        public ActionResult Index(string searchString)
        {
            List<ForkViewModel> forks;
            if (!string.IsNullOrEmpty(searchString))
            {
                forks = _forkService.Find(searchString)
                    .Select(t => new ForkViewModel
                    {
                        Id = t.Id,
                        Name = t.Name,
                        ForkBrand = t.ForkBrand,
                        ForkType = t.ForkType
                    }).ToList();
            }
            else
            {
                forks = _forkService.GetAll()
                    .Select(t => new ForkViewModel
                    {
                        Id = t.Id,
                        Name = t.Name,
                        ForkBrand = t.ForkBrand,
                        ForkType = t.ForkType
                    }).ToList();
            }

            return View(forks);
        }

        // GET: Forks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Forks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ForkType,ForkBrand")] ForkViewModel forkViewModel)
        {
            if (ModelState.IsValid)
            {
                ForkDTO fork = new ForkDTO
                {
                    Id = forkViewModel.Id,
                    Name = forkViewModel.Name,
                    ForkBrand = forkViewModel.ForkBrand,
                    ForkType = forkViewModel.ForkType
                };

                _forkService.Create(fork);
                return RedirectToAction("Index");
            }

            return View(forkViewModel);
        }

        // GET: Forks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var forkDto = _forkService.GetById(id);

            if (forkDto == null)
            {
                return HttpNotFound();
            }

            ForkViewModel fork = new ForkViewModel
            {
                Id = forkDto.Id,
                Name = forkDto.Name,
                ForkBrand = forkDto.ForkBrand,
                ForkType = forkDto.ForkType
            };

            return View(fork);
        }

        // POST: Forks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ForkType,ForkBrand")] ForkViewModel forkViewModel)
        {
            /*if (ModelState.IsValid)
            {
                _forkService.Update(forkViewModel);
                return RedirectToAction("Index");
            }
            return View(forkViewModel);*/

            if (ModelState.IsValid)
            {
                ForkDTO forkDto = new ForkDTO
                {
                    Id = forkViewModel.Id,
                    Name = forkViewModel.Name,
                    ForkBrand = forkViewModel.ForkBrand,
                    ForkType = forkViewModel.ForkType
                };
                _forkService.Update(forkDto);

                return RedirectToAction("Index");
            }
            return View(forkViewModel);
        }

        // GET: Forks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var forkDto = _forkService.GetById(id);

            if (forkDto == null)
            {
                return HttpNotFound();
            }

            ForkViewModel fork = new ForkViewModel
            {
                Id = forkDto.Id,
                Name = forkDto.Name,
                ForkBrand = forkDto.ForkBrand,
                ForkType = forkDto.ForkType
            };

            return View(fork);
        }

        // POST: Forks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _forkService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _forkService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
