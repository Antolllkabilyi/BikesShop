using System;
using System.Collections.Generic;
using System.Linq;
using BikesShop.DAL.EF;
using BikesShop.DAL.Entities;
using BikesShop.DAL.Interfaces;

namespace BikesShop.DAL.Repositories
{
    public class BicycleColorRepository : IRepository<BicycleColor>
    {
        private readonly BicycleContext _db;
        public BicycleColorRepository(BicycleContext context)
        {
            _db = context;
        }

        public void Create(BicycleColor item)
        {
            _db.BicycleColors.Add(item);
        }

        public void Delete(int id)
        {
            BicycleColor bicycleColor = _db.BicycleColors.Find(id);
            if (bicycleColor != null)
            {
                _db.BicycleColors.Remove(bicycleColor);
            }
        }

        public IEnumerable<BicycleColor> Find(Func<BicycleColor, bool> predicate)
        {
            return _db.BicycleColors.Where(predicate).ToList();
        }

        public BicycleColor Get(int id)
        {
            return _db.BicycleColors.Find(id);
        }

        public IEnumerable<BicycleColor> GetAll()
        {
            return _db.BicycleColors.ToList();
        }

        public void Update(BicycleColor item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
