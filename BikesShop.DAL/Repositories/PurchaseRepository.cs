using System.Collections.Generic;
using System.Linq;
using BikesShop.DAL.EF;
using BikesShop.DAL.Entities;
using BikesShop.DAL.Interfaces;

namespace BikesShop.DAL.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly BicycleContext _db;
        public PurchaseRepository(BicycleContext context)
        {
            _db = context;
        }
        public IEnumerable<PurchaseEntity> GetAll()
        {
            return _db.Purchase.ToList();
        }

        public PurchaseEntity Get(int? id)
        {
            if (id == null || id < 0)
                return null;

            return _db.Purchase.Find(id);
        }

        public IEnumerable<PurchaseEntity> GetPartFromIndex(int index, int count)
        {
            if (index < 0 || count < 0 || index > _db.Purchase.Count())
                return null;

            return _db.Purchase.OrderBy(f => f.Id).Skip(index).Take(count);
        }

        public IEnumerable<PurchaseEntity> Find(string predicate)
        {
            throw new System.NotImplementedException();
        }

        public void Create(PurchaseEntity item)
        {
            _db.Purchase.Add(item);
        }

        public void Update(PurchaseEntity item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            PurchaseEntity purchase = _db.Purchase.Find(id);
            if (purchase != null)
            {
                _db.Purchase.Remove(purchase);
            }
        }
    }
}
