using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BikesShop.BLL.Interfaces;
using BikesShop.DAL.EF;
using BikesShop.DAL.Entities;
using ForkDTO = BikesShop.BLL.DTO.ForkDTO;

namespace BikesShop.BLL.Services
{
    public class ForkService : IForkService
    {
        private readonly BicycleContext _db;
        private DbSet<ForkEntity> _forks;

        public ForkService()
        {
            _db = new BicycleContext();
            _forks = _db.Forks;
        }

        public ForkEntity GetById(int? id)
        {
            if (id == null || id < 0 || id >= _forks.Count())
                return null;

            return _forks.Find(id);
        }

        public IEnumerable<ForkEntity> GetAll()
        {
            return _forks.ToList();
        }

        public IEnumerable<ForkEntity> GetPartFromIndex(int index, int count)
        {
            if (index < 0 || count < 0 || index > _forks.Count())
                return null;

            return _forks.OrderBy(f=>f.Id).Skip(index).Take(count);
        }

        public IEnumerable<ForkEntity> Find(string predicate)
        {
            return null;// _forks.Find(predicate);
        }

        public void Create(ForkEntity forkEntity)
        {
            _forks.Add(forkEntity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            ForkEntity forkEntity = GetById(id);
            _forks.Remove(forkEntity);
            _db.SaveChanges();
        }

        public void Update(ForkEntity forkEntity)
        {
            _db.Entry(forkEntity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _forks = null;
            _db.Dispose();
        }
    }
}
