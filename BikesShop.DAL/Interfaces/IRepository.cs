﻿using System.Collections.Generic;

namespace BikesShop.DAL.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int? id);
        IEnumerable<T> GetPartFromIndex(int index, int count);
        IEnumerable<T> Find(string predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
