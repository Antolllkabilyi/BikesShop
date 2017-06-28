using System.Collections.Generic;
using System.Linq;
using BikesShop.BLL.DTO;
using BikesShop.BLL.Interfaces;
using BikesShop.DAL.Entities;
using BikesShop.DAL.Interfaces;

namespace BikesShop.BLL.Services
{
    public class ColorsService : IColorService
    {
        private readonly IUnitOfWork _db;

        public ColorsService(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        public BicycleColorDTO GetById(int? id)
        {
            if (id == null || id < 0)
                return null;

            var color = _db.BicycleColors.Get(id);

            if (color == null)
                return null;

            BicycleColorDTO colorDto = new BicycleColorDTO
            {
                Id = color.Id,
                Name = color.Name
            };

            return colorDto;
        }

        public IEnumerable<BicycleColorDTO> GetAll()
        {
            List<BicycleColorDTO> colorsDto = _db.BicycleColors.GetAll()
                .Select(t => new BicycleColorDTO
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToList();

            return colorsDto;
        }

        public IEnumerable<BicycleColorDTO> GetPartFromIndex(int index, int count)
        {
            List<BicycleColorDTO> colorsDto = _db.BicycleColors
                .GetPartFromIndex(index, count)
                .Select(t => new BicycleColorDTO
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToList();

            return colorsDto;
        }

        public IEnumerable<BicycleColorDTO> Find(string predicate)
        {
            List<BicycleColorDTO> colorsDto = _db.BicycleColors
                  .Find(predicate)
                  .Select(t => new BicycleColorDTO
                  {
                      Id = t.Id,
                      Name = t.Name
                  })
                  .ToList();

            return colorsDto;
        }

        public void Create(BicycleColorDTO obj)
        {
            BicycleColorEntity color = new BicycleColorEntity
            {
                Id = obj.Id,
                Name = obj.Name
            };

            _db.BicycleColors.Create(color);
            _db.Save();
        }

        public void Delete(int id)
        {
            _db.BicycleColors.Delete(id);
            _db.Save();
        }

        public void Update(BicycleColorDTO obj)
        {
            BicycleColorEntity color = new BicycleColorEntity
            {
                Id = obj.Id,
                Name = obj.Name
            };

            _db.BicycleColors.Update(color);
            _db.Save();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
