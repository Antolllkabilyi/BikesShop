﻿using System;
using System.Collections.Generic;
using System.Linq;
using BikesShop.DAL.EF;
using BikesShop.DAL.Entities;
using BikesShop.DAL.Interfaces;

namespace BikesShop.DAL.Repositories
{
    public class ForkRepository : IRepository<ForkEntity>
    {
        private readonly BicycleContext _db;
        public ForkRepository(BicycleContext context)
        {
            _db = context;
        }

        public void Create(ForkEntity item)
        {
            _db.Forks.Add(item);
        }

        public void Delete(int id)
        {
            ForkEntity forkEntity = _db.Forks.Find(id);
            if (forkEntity != null)
            {
                _db.Forks.Remove(forkEntity);
            }
        }

        public IEnumerable<ForkEntity> GetPartFromIndex(int index, int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ForkEntity> Find(string predicate)
        {
            /* return _db.Forks.Where(t=> 
                                      t.Name.Contains(predicate) 
                                      || t.ForkBrand.Contains(predicate)
                                      || t.ForkType.Contains(predicate))
                             .ToList();*/
            return from item in _db.Forks
                   where item.Name.Contains(predicate)
                   || item.ForkBrand.Contains(predicate)
                   || item.ForkType.Contains(predicate)
                   select item;
        }

        public ForkEntity Get(int id)
        {
            return _db.Forks.Find(id);
        }

        public IEnumerable<ForkEntity> GetAll()
        {
            return _db.Forks.ToList();
        }

        public ForkEntity Get(int? id)
        {
            throw new NotImplementedException();
        }

        public void Update(ForkEntity item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
