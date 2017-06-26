using System;
using System.Collections.Generic;
using System.Linq;
using BikesShop.DAL.EF;
using BikesShop.DAL.Entities;
using BikesShop.DAL.Interfaces;

namespace BikesShop.DAL.Repositories
{
    public class ForkRepository : IRepository<Fork>
    {
        private readonly BicycleContext _db;
        public ForkRepository(BicycleContext context)
        {
            _db = context;
        }

        public void Create(Fork item)
        {
            _db.Forks.Add(item);
        }

        public void Delete(int id)
        {
            Fork fork = _db.Forks.Find(id);
            if (fork != null)
            {
                _db.Forks.Remove(fork);
            }
        }

        public IEnumerable<Fork> Find(Func<Fork, bool> predicate)
        {
            return _db.Forks.Where(predicate).ToList();
        }

        public Fork Get(int id)
        {
            return _db.Forks.Find(id);
        }

        public IEnumerable<Fork> GetAll()
        {
            return _db.Forks.ToList();
        }

        public void Update(Fork item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
