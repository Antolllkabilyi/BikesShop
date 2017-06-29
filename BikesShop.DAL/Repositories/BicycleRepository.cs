using System.Collections.Generic;
using System.Linq;
using BikesShop.DAL.EF;
using BikesShop.DAL.Entities;
using BikesShop.DAL.Interfaces;

namespace BikesShop.DAL.Repositories
{
    class BicycleRepository : IBicycleRepository
    {
        private readonly BicycleContext _db;
        public BicycleRepository(BicycleContext context)
        {
            _db = context;
        }

        public IEnumerable<BicycleEntity> GetAll()
        {
            return _db.Bicycles.ToList();
        }

        public BicycleEntity Get(int? id)
        {
            if (id == null || id < 0)
                return null;

            return _db.Bicycles.Find(id); 
        }

        public IEnumerable<BicycleEntity> GetPartFromIndex(int index, int count)
        {
            if (index < 0 || count < 0 || index > _db.Bicycles.Count())
                return null;

            return _db.Bicycles.OrderBy(f => f.Id).Skip(index).Take(count);
        }

        public IEnumerable<BicycleEntity> Find(string predicate)
        {
            return from item in _db.Bicycles
                where item.Type.Name.Contains(predicate)
                      || item.Fork.ForkBrand.Contains(predicate)
                      || item.Fork.Name.Contains(predicate)
                      || item.Fork.ForkType.Contains(predicate)
                      || item.Size.Name.Contains(predicate)
                      || item.Color.Name.Contains(predicate)
                select item;
        }

        public void Create(BicycleEntity item)
        {
            _db.Bicycles.Add(item);
        }

        public void Update(BicycleEntity item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            BicycleEntity bicycle = _db.Bicycles.Find(id);
            if (bicycle != null)
            {
                _db.Bicycles.Remove(bicycle);
            }
        }
    }
}
