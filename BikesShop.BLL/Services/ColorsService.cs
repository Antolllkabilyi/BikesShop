using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BikesShop.BLL.Interfaces;
using BikesShop.DAL.EF;
using BikesShop.DAL.Entities;

namespace BikesShop.BLL.Services
{
    public class ColorsService : IService<BicycleColor>
    {
        private readonly BicycleContext _db;
        private DbSet<BicycleColor> _colors;

        public ColorsService()
        {
            _db = new BicycleContext();
            _colors = _db.BicycleColors;
        }

        public BicycleColor GetById(int? id)
        {
            if (id == null || id < 0 || id >= _colors.Count())
                return null;

            return _colors.Find(id);
        }

        public IEnumerable<BicycleColor> GetAll()
        {
            return _colors.ToList();
        }

        public IEnumerable<BicycleColor> GetPartFromIndex(int index, int count)
        {
            if (index < 0 || count < 0 || index > _colors.Count())
                return null;

            return _colors.OrderBy(f => f.Id).Skip(index).Take(count);
        }

        public void Create(BicycleColor obj)
        {
            _colors.Add(obj);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            BicycleColor color = GetById(id);
            _colors.Remove(color);
            _db.SaveChanges();
        }

        public void Update(BicycleColor obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _colors = null;
            _db.Dispose();
        }
    }
}
