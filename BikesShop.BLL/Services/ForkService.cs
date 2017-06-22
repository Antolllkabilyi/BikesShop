using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BikesShop.BLL.Interfaces;
using BikesShop.DAL.Models;

namespace BikesShop.BLL.Services
{
    public class ForkService : IService<Fork>
    {
        private readonly BicycleContext _db;
        private DbSet<Fork> _forks;

        public ForkService()
        {
            _db = new BicycleContext();
            _forks = _db.Forks;
        }

        public Fork GetById(int? id)
        {
            if (id == null || id < 0 || id >= _db.Forks.Count())
                return null;

            return _forks.Find(id);
        }

        public IEnumerable<Fork> GetAll()
        {
            return _forks.ToList();
        }

        public IEnumerable<Fork> GetPartFromIndex(int index, int count)
        {
            throw new System.NotImplementedException();
        }

        public void Create(Fork fork)
        {
            _forks.Add(fork);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            Fork fork = GetById(id);
            _forks.Remove(fork);
            _db.SaveChanges();
        }

        public void Update(Fork fork)
        {
            _db.Entry(fork).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _forks = null;
            _db.Dispose();
        }
    }
}
