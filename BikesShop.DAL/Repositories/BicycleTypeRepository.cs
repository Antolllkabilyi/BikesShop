using System.Collections.Generic;
using System.Linq;
using BikesShop.DAL.EF;
using BikesShop.DAL.Entities;
using BikesShop.DAL.Interfaces;

namespace BikesShop.DAL.Repositories
{
    public class BicycleTypeRepository : IBicycleTypeRepository
    {
        private readonly BicycleContext _db;
        public BicycleTypeRepository(BicycleContext context)
        {
            _db = context;
        }

        public IEnumerable<BicycleTypeEntity> GetAll()
        {
            return _db.Types.ToList();
        }

        public BicycleTypeEntity Get(int? id)
        {
            if (id == null || id < 0)
                return null;

            return _db.Types.Find(id);
        }

        public IEnumerable<BicycleTypeEntity> GetPartFromIndex(int index, int count)
        {
            if (index < 0 || count < 0 || index > _db.Types.Count())
                return null;

            return _db.Types.OrderBy(f => f.Id).Skip(index).Take(count);
        }

        public IEnumerable<BicycleTypeEntity> Find(string predicate)
        {
            return from item in _db.Types
                   where item.Name.Contains(predicate)
                   select item;
        }

        public void Create(BicycleTypeEntity item)
        {
            _db.Types.Add(item);
        }

        public void Update(BicycleTypeEntity item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            BicycleTypeEntity bicycleType = _db.Types.Find(id);
            if (bicycleType != null)
            {
                _db.Types.Remove(bicycleType);
            }
        }
    }
}
