using System;
using System.Collections.Generic;
using System.Linq;
using BikesShop.BLL.DTO;
using BikesShop.BLL.Interfaces;
using BikesShop.DAL.Entities;
using BikesShop.DAL.Interfaces;

namespace BikesShop.BLL.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IUnitOfWork _db;

        public PurchaseService(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }
        public PurchaseDTO GetById(int? id)
        {
            if (id == null || id < 0)
                return null;

            var purchase = _db.Purchases.Get(id);

            if (purchase == null)
                return null;

            PurchaseDTO purchaseDto = new PurchaseDTO
            {
                Id = purchase.Id,
                BicycleId = purchase.BicycleId,
                UserId = purchase.UserId,
                IsPaid = purchase.IsPaid
            };

            return purchaseDto;
        }

        public IEnumerable<PurchaseDTO> GetAll()
        {
            List<PurchaseDTO> purchases = _db.Purchases.GetAll()
                .Select(purchase => new PurchaseDTO
                {
                    Id = purchase.Id,
                    BicycleId = purchase.BicycleId,
                    UserId = purchase.UserId,
                    IsPaid = purchase.IsPaid
                })
                .ToList();

            return purchases;
        }

        public IEnumerable<PurchaseDTO> GetPartFromIndex(int index, int count)
        {
            List<PurchaseDTO> purchases = _db.Purchases.GetPartFromIndex(index,count)
                .Select(purchase => new PurchaseDTO
                {
                    Id = purchase.Id,
                    BicycleId = purchase.BicycleId,
                    UserId = purchase.UserId,
                    IsPaid = purchase.IsPaid
                })
                .ToList();

            return purchases;
        }

        public IEnumerable<PurchaseDTO> Find(string predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(PurchaseDTO obj)
        {
            PurchaseEntity purchase = new PurchaseEntity
            {
                Id = obj.Id,
                BicycleId = obj.BicycleId,
                UserId = obj.UserId,
                IsPaid = obj.IsPaid
            };

            _db.Purchases.Create(purchase);
            _db.Save();
        }

        public void Delete(int id)
        {
            _db.Purchases.Delete(id);
            _db.Save();
        }

        public void Update(PurchaseDTO obj)
        {

            PurchaseEntity purchase = new PurchaseEntity
            {
                Id = obj.Id,
                BicycleId = obj.BicycleId,
                UserId = obj.UserId,
                IsPaid = obj.IsPaid
            };

            _db.Purchases.Update(purchase);
            _db.Save();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
