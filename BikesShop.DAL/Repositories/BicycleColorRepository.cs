using System.Collections.Generic;
using System.Linq;
using BikesShop.DAL.EF;
using BikesShop.DAL.Entities;
using BikesShop.DAL.Interfaces;

namespace BikesShop.DAL.Repositories
{
    public class BicycleColorRepository : IColorRepository
    {
        private readonly BicycleContext _db;
        public BicycleColorRepository(BicycleContext context)
        {
            _db = context;
        }

        public void Create(BicycleColorEntity item)
        {
            _db.BicycleColors.Add(item);
        }

        public void Delete(int id)
        {
            BicycleColorEntity bicycleColorEntity = _db.BicycleColors.Find(id);
            if (bicycleColorEntity != null)
            {
                _db.BicycleColors.Remove(bicycleColorEntity);
            }
        }

        public IEnumerable<BicycleColorEntity> GetPartFromIndex(int index, int count)
        {
            if (index < 0 || count < 0 || index > _db.BicycleColors.Count())
                return null;

            return _db.BicycleColors.OrderBy(f => f.Id).Skip(index).Take(count);
        }

        public IEnumerable<BicycleColorEntity> Find(string predicate)
        {
           // return _db.BicycleColors.Where(t => t.Name.Contains(predicate)).ToList();
           return from item in _db.BicycleColors
                  where item.Name.Contains(predicate)
                  select item;
        }

        public BicycleColorEntity Get(int? id)
        {
            if (id == null || id < 0 || id >= _db.BicycleColors.Count())
                return null;

            return _db.BicycleColors.Find(id);
        }

        public IEnumerable<BicycleColorEntity> GetAll()
        {
            return _db.BicycleColors.ToList();
        }

        public void Update(BicycleColorEntity item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
