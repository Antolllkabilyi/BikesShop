using System.Collections.Generic;
using System.Linq;
using BikesShop.DAL.EF;
using BikesShop.DAL.Entities;
using BikesShop.DAL.Interfaces;

namespace BikesShop.DAL.Repositories
{
   public class BicycleSizeRepository : IBicycleSizeRepository
    {
        private readonly BicycleContext _db;
        public BicycleSizeRepository(BicycleContext context)
        {
            _db = context;
        }

        public IEnumerable<BicycleSizeEntity> GetAll()
        {
            return _db.BicycleSize.ToList();
        }

        public BicycleSizeEntity Get(int? id)
        {
            if (id == null || id < 0)
                return null;

            return _db.BicycleSize.Find(id);
        }

        public IEnumerable<BicycleSizeEntity> GetPartFromIndex(int index, int count)
        {
            if (index < 0 || count < 0 || index > _db.BicycleSize.Count())
                return null;

            return _db.BicycleSize.OrderBy(f => f.Id).Skip(index).Take(count);
        }

        public IEnumerable<BicycleSizeEntity> Find(string predicate)
        {
            return from item in _db.BicycleSize
                   where item.Name.Contains(predicate)
                   select item;
        }

        public void Create(BicycleSizeEntity item)
        {
            _db.BicycleSize.Add(item);
        }

        public void Update(BicycleSizeEntity item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            BicycleSizeEntity sizeEntity = _db.BicycleSize.Find(id);
            if (sizeEntity != null)
            {
                _db.BicycleSize.Remove(sizeEntity);
            }
        }
    }
}
