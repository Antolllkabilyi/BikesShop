using System;
using System.Collections.Generic;

namespace BikesShop.BLL.Interfaces
{
    public interface IService<T>
    {
        T GetById(int? id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetPartFromIndex(int index, int count);
        IEnumerable<T> Find(string predicate);
        void Create(T obj);
        void Delete(int id);
        void Update(T obj);
        void Dispose();
      
    }
}
