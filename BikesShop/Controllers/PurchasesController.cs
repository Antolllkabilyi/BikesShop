using System.Linq;
using System.Net;
using System.Web.Mvc;
using BikesShop.BLL.DTO;
using BikesShop.BLL.Interfaces;
using BikesShop.Models;

namespace BikesShop.Controllers
{
    public class PurchasesController : Controller
    {
        private readonly IPurchaseService _purchaseService;
        private readonly IBicycleService _bicycleService;
        private readonly IBicycleTypeService _bicycleTypeService;
        private readonly IColorService _colorService;
        private readonly IForkService _forkService;
        private readonly ISizeService _sizeService;

        public PurchasesController(IPurchaseService purchaseService, IBicycleService bicycleService,
            IBicycleTypeService bicycleTypeService, IColorService colorService, IForkService forkService,
            ISizeService sizeService)
        {
            _purchaseService = purchaseService;
            _bicycleService = bicycleService;
            _bicycleTypeService = bicycleTypeService;
            _colorService = colorService;
            _forkService = forkService;
            _sizeService = sizeService;
        }

        // GET: Purchases
        public ActionResult Index()
        {
            var purchaseDTo = _purchaseService.GetAll();
            var purchases = purchaseDTo.Select(purchase => SetPurchaseDtoToViewModel(purchase)).ToList();

            foreach (var purchase in purchases)
            {
                var purchaseViewModel = purchase;
                LoadPurchaseDataToObject(ref purchaseViewModel);
            }

            return View(purchases);
        }

        // GET: Purchases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var purchase = _purchaseService.GetById(id);

            if (purchase == null)
            {
                return HttpNotFound();
            }

            PurchaseViewModel purchaseViewModel = SetPurchaseDtoToViewModel(purchase);

            LoadPurchaseDataToObject(ref purchaseViewModel);

            return View(purchaseViewModel);
        }

        // GET: Purchases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var purchase = _purchaseService.GetById(id);

            if (purchase == null)
            {
                return HttpNotFound();
            }

            PurchaseViewModel purchaseViewModel = SetPurchaseDtoToViewModel(purchase);

            LoadPurchaseDataToObject(ref purchaseViewModel);

            return View(purchaseViewModel);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _purchaseService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _purchaseService.Dispose();
                _bicycleService.Dispose();
                _bicycleTypeService.Dispose();
                _colorService.Dispose();
                _forkService.Dispose();
                _sizeService.Dispose();
            }
            base.Dispose(disposing);
        }

        private PurchaseDTO SetPurchaseViewModelToDto(PurchaseViewModel purchase)
        {
            return new PurchaseDTO
            {
                Id = purchase.Id,
                BicycleId = purchase.BicycleId,
                UserId = purchase.UserId,
                IsPaid = purchase.IsPaid
            };
        }

        private PurchaseViewModel SetPurchaseDtoToViewModel(PurchaseDTO purchase)
        {
            return new PurchaseViewModel
            {
                Id = purchase.Id,
                BicycleId = purchase.BicycleId,
                UserId = purchase.UserId,
                IsPaid = purchase.IsPaid
            };
        }

        private void LoadPurchaseDataToObject(ref PurchaseViewModel purchase)
        {
            var bicycle = _bicycleService.GetById(purchase.BicycleId);

            BicycleViewModel bicycleViewModel = SetBicycleDtoToViewModel(bicycle);

            LoadBicycleDataToObject(ref bicycleViewModel);

            purchase.Bicycle = bicycleViewModel;
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

        private void LoadBicycleDataToObject(ref BicycleViewModel bicycle)
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
