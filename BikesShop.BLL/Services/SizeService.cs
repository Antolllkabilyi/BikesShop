using System.Collections.Generic;
using System.Linq;
using BikesShop.BLL.DTO;
using BikesShop.BLL.Interfaces;
using BikesShop.DAL.Entities;
using BikesShop.DAL.Interfaces;

namespace BikesShop.BLL.Services
{
    public class SizeService : ISizeService
    {
        private readonly IUnitOfWork _db;

        public SizeService(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        public BicycleSizeDTO GetById(int? id)
        {
            if (id == null || id < 0)
                return null;

            var size = _db.BicyclesSize.Get(id);

            if (size == null)
                return null;

            BicycleSizeDTO sizeDto = new BicycleSizeDTO
            {
                Id = size.Id,
                Name = size.Name,
                Size = size.Size
            };

            return sizeDto;
        }

        public IEnumerable<BicycleSizeDTO> GetAll()
        {
            List<BicycleSizeDTO> sizes = _db.BicyclesSize.GetAll()
                .Select(size => new BicycleSizeDTO
                {
                    Id = size.Id,
                    Name = size.Name,
                    Size = size.Size
                })
                .ToList();

            return sizes;
        }

        public IEnumerable<BicycleSizeDTO> GetPartFromIndex(int index, int count)
        {
            List<BicycleSizeDTO> sizes = _db.BicyclesSize.GetPartFromIndex(index, count)
                .Select(size => new BicycleSizeDTO
                {
                    Id = size.Id,
                    Name = size.Name,
                    Size = size.Size
                })
                .ToList();

            return sizes;
        }

        public IEnumerable<BicycleSizeDTO> Find(string predicate)
        {
            List<BicycleSizeDTO> sizes = _db.BicyclesSize.Find(predicate)
                .Select(size => new BicycleSizeDTO
                {
                    Id = size.Id,
                    Name = size.Name,
                    Size = size.Size
                })
                .ToList();

            return sizes;
        }

        public void Create(BicycleSizeDTO obj)
        {
            BicycleSizeEntity size = new BicycleSizeEntity
            {
                Id = obj.Id,
                Name = obj.Name,
                Size = obj.Size
            };

            _db.BicyclesSize.Create(size);
            _db.Save();
        }

        public void Delete(int id)
        {
            _db.BicyclesSize.Delete(id);
            _db.Save();
        }

        public void Update(BicycleSizeDTO obj)
        {
            BicycleSizeEntity size = new BicycleSizeEntity
            {
                Id = obj.Id,
                Name = obj.Name,
                Size = obj.Size
            };

            _db.BicyclesSize.Update(size);
            _db.Save();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
