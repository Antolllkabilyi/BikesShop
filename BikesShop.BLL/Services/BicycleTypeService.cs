using System.Collections.Generic;
using System.Linq;
using BikesShop.BLL.DTO;
using BikesShop.BLL.Interfaces;
using BikesShop.DAL.Entities;
using BikesShop.DAL.Interfaces;

namespace BikesShop.BLL.Services
{
    public class BicycleTypeService : IBicycleTypeService
    {
        private readonly IUnitOfWork _db;

        public BicycleTypeService(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        public BicycleTypeDTO GetById(int? id)
        {
            if (id == null || id < 0)
                return null;

            var type = _db.BicycleType.Get(id);

            if (type == null)
                return null;

            BicycleTypeDTO typeDto = new BicycleTypeDTO
            {
                Id = type.Id,
                Name = type.Name
            };

            return typeDto;
        }

        public IEnumerable<BicycleTypeDTO> GetAll()
        {
            List<BicycleTypeDTO> sizes = _db.BicycleType.GetAll()
                .Select(t => new BicycleTypeDTO
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToList();

            return sizes;
        }

        public IEnumerable<BicycleTypeDTO> GetPartFromIndex(int index, int count)
        {
            List<BicycleTypeDTO> sizes = _db.BicycleType.GetPartFromIndex(index, count)
                .Select(t => new BicycleTypeDTO
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToList();

            return sizes;
        }

        public IEnumerable<BicycleTypeDTO> Find(string predicate)
        {
            List<BicycleTypeDTO> sizes = _db.BicycleType.Find(predicate)
                .Select(t => new BicycleTypeDTO
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToList();

            return sizes;
        }

        public void Create(BicycleTypeDTO obj)
        {
            BicycleTypeEntity size = new BicycleTypeEntity
            {
                Id = obj.Id,
                Name = obj.Name
            };

            _db.BicycleType.Create(size);
            _db.Save();
        }

        public void Delete(int id)
        {
            _db.BicycleType.Delete(id);
            _db.Save();
        }

        public void Update(BicycleTypeDTO obj)
        {
            BicycleTypeEntity size = new BicycleTypeEntity
            {
                Id = obj.Id,
                Name = obj.Name
            };

            _db.BicycleType.Update(size);
            _db.Save();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
