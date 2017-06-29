using System.Linq;
using System.Net;
using System.Web.Mvc;
using BikesShop.BLL.DTO;
using BikesShop.BLL.Interfaces;
using BikesShop.Models;

namespace BikesShop.Controllers
{
    public class BicycleController : Controller
    {
        private readonly IBicycleService _bicycleService;
        private readonly IBicycleTypeService _bicycleTypeService;
        private readonly IColorService _colorService;
        private readonly IForkService _forkService;
        private readonly ISizeService _sizeService;

        public BicycleController(IBicycleService bicycleService, IBicycleTypeService bicycleTypeService,
            IColorService colorService, IForkService forkService, ISizeService sizeService)
        {
            _bicycleService = bicycleService;
            _bicycleTypeService = bicycleTypeService;
            _colorService = colorService;
            _forkService = forkService;
            _sizeService = sizeService;
        }

        // GET: BicycleViewModels
        public ActionResult Index(string searchString)
        {
            var bicyclesDto = !string.IsNullOrEmpty(searchString) ? _bicycleService.Find(searchString) : _bicycleService.GetAll();

            var bicycles = bicyclesDto.Select(bicycle => SetBicycleDtoToViewModel(bicycle)).ToList();

            foreach (var bicycle in bicycles)
            {
                var bicycleViewModel = bicycle;
                LoadDataToObject(ref bicycleViewModel);
            }

            return View(bicycles);
        }

        // GET: BicycleViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var bicycle = _bicycleService.GetById(id);

            if (bicycle == null)
            {
                return HttpNotFound();
            }

            BicycleViewModel bicycleViewModel = SetBicycleDtoToViewModel(bicycle);

            LoadDataToObject(ref bicycleViewModel);

            return View(bicycleViewModel);
        }

        // GET: BicycleViewModels/Create
        public ActionResult Create()
        {
            ViewBag.ColorId = new SelectList(_colorService.GetAll(), "Id", "Name");
            ViewBag.ForkId = new SelectList(_forkService.GetAll(), "Id", "Name");
            ViewBag.SizeId = new SelectList(_sizeService.GetAll(), "Id", "Name");
            ViewBag.TypeId = new SelectList(_bicycleTypeService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: BicycleViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ModelYear,Price,TypeId,ForkId,SizeId,ColorId")] BicycleViewModel bicycleViewModel)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    BicycleDTO bicycle = SetBicycleViewModelToDto(bicycleViewModel);

                    _bicycleService.Create(bicycle);
                    return RedirectToAction("Index");
                }
            }

            ViewBag.ColorId = new SelectList(_colorService.GetAll(), "Id", "Name", bicycleViewModel.ColorId);
            ViewBag.ForkId = new SelectList(_forkService.GetAll(), "Id", "Name", bicycleViewModel.ForkId);
            ViewBag.SizeId = new SelectList(_sizeService.GetAll(), "Id", "Name", bicycleViewModel.SizeId);
            ViewBag.TypeId = new SelectList(_bicycleTypeService.GetAll(), "Id", "Name", bicycleViewModel.TypeId);
            return View(bicycleViewModel);
        }

        // GET: BicycleViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var bicycle = _bicycleService.GetById(id);

            if (bicycle == null)
            {
                return HttpNotFound();
            }

            BicycleViewModel bicycleViewModel = SetBicycleDtoToViewModel(bicycle);

            LoadDataToObject(ref bicycleViewModel);
            ViewBag.ColorId = new SelectList(_colorService.GetAll(), "Id", "Name", bicycleViewModel.ColorId);
            ViewBag.ForkId = new SelectList(_forkService.GetAll(), "Id", "Name", bicycleViewModel.ForkId);
            ViewBag.SizeId = new SelectList(_sizeService.GetAll(), "Id", "Name", bicycleViewModel.SizeId);
            ViewBag.TypeId = new SelectList(_bicycleTypeService.GetAll(), "Id", "Name", bicycleViewModel.TypeId);

            return View(bicycleViewModel);
        }

        // POST: BicycleViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ModelYear,Price,TypeId,ForkId,SizeId,ColorId")] BicycleViewModel bicycleViewModel)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    BicycleDTO bicycle = SetBicycleViewModelToDto(bicycleViewModel);

                    _bicycleService.Update(bicycle);
                    return RedirectToAction("Index");
                }
            }

            ViewBag.ColorId = new SelectList(_colorService.GetAll(), "Id", "Name", bicycleViewModel.ColorId);
            ViewBag.ForkId = new SelectList(_forkService.GetAll(), "Id", "Name", bicycleViewModel.ForkId);
            ViewBag.SizeId = new SelectList(_sizeService.GetAll(), "Id", "Name", bicycleViewModel.SizeId);
            ViewBag.TypeId = new SelectList(_bicycleTypeService.GetAll(), "Id", "Name", bicycleViewModel.TypeId);
            return View(bicycleViewModel);
        }

        // GET: BicycleViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var bicycle = _bicycleService.GetById(id);

            if (bicycle == null)
            {
                return HttpNotFound();
            }

            BicycleViewModel bicycleViewModel = SetBicycleDtoToViewModel(bicycle);

            LoadDataToObject(ref bicycleViewModel);

            return View(bicycleViewModel);
        }

        // POST: BicycleViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _bicycleService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _bicycleService.Dispose();
                _bicycleTypeService.Dispose();
                _colorService.Dispose();
                _forkService.Dispose();
                _sizeService.Dispose();
            }
            base.Dispose(disposing);
        }

        private BicycleDTO SetBicycleViewModelToDto(BicycleViewModel bicycle)
        {
            return new BicycleDTO
            {
                Id = bicycle.Id,
                ModelYear = bicycle.ModelYear,
                Price = bicycle.Price,
                ColorId = bicycle.ColorId,
                ForkId = bicycle.ForkId,
                SizeId = bicycle.SizeId,
                TypeId = bicycle.TypeId
            };
        }

        private BicycleViewModel SetBicycleDtoToViewModel(BicycleDTO bicycle)
        {
            return new BicycleViewModel
            {
                Id = bicycle.Id,
                ModelYear = bicycle.ModelYear,
                Price = bicycle.Price,
                ColorId = bicycle.ColorId,
                ForkId = bicycle.ForkId,
                SizeId = bicycle.SizeId,
                TypeId = bicycle.TypeId
            };
        }

        private void LoadDataToObject(ref BicycleViewModel bicycle)
        {
            var bicycleColor = _colorService.GetById(bicycle.ColorId);

            bicycle.Color = new BicycleColorViewModel
            {
                Id = bicycleColor.Id,
                Name = bicycleColor.Name
            };

            var fork = _forkService.GetById(bicycle.ForkId);
            bicycle.Fork = new ForkViewModel
            {
                Id = fork.Id,
                Name = fork.Name,
                ForkBrand = fork.ForkBrand,
                ForkType = fork.ForkType
            };

            var type = _bicycleTypeService.GetById(bicycle.TypeId);
            bicycle.Type = new BicycleTypeViewModel()
            {
                Id = type.Id,
                Name = type.Name
            };

            var size = _sizeService.GetById(bicycle.SizeId);
            bicycle.Size = new BicycleSizeViewModel()
            {
                Id = size.Id,
                Name = size.Name,
                Size = size.Size
            };
        }
    }
}
