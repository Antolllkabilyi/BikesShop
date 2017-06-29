using System.Collections.Generic;
using System.Linq;
using BikesShop.BLL.DTO;
using BikesShop.BLL.Interfaces;
using BikesShop.DAL.Entities;
using BikesShop.DAL.Interfaces;

namespace BikesShop.BLL.Services
{
    public class BicycleService : IBicycleService
    {
        private readonly IUnitOfWork _db;

        public BicycleService(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        public BicycleDTO GetById(int? id)
        {
            if (id == null || id < 0)
                return null;

            var bicycle = _db.Bicycles.Get(id);

            if (bicycle == null)
                return null;

            BicycleDTO bicycleDto = new BicycleDTO
            {
                Id = bicycle.Id,
                ModelYear = bicycle.ModelYear,
                Price = bicycle.Price,
                ColorId = bicycle.ColorId,
                ForkId = bicycle.ForkId,
                SizeId = bicycle.SizeId,
                TypeId = bicycle.TypeId
            };

            return bicycleDto;
        }

        public IEnumerable<BicycleDTO> GetAll()
        {
            List<BicycleDTO> bicycles = _db.Bicycles.GetAll()
                .Select(bicycle => new BicycleDTO
                {
                    Id = bicycle.Id,
                    ModelYear = bicycle.ModelYear,
                    Price = bicycle.Price,
                    ColorId = bicycle.ColorId,
                    ForkId = bicycle.ForkId,
                    SizeId = bicycle.SizeId,
                    TypeId = bicycle.TypeId
                })
                .ToList();

            return bicycles;
        }

        public IEnumerable<BicycleDTO> GetPartFromIndex(int index, int count)
        {
            List<BicycleDTO> bicycles = _db.Bicycles.GetPartFromIndex(index,count)
                .Select(bicycle => new BicycleDTO
                {
                    Id = bicycle.Id,
                    ModelYear = bicycle.ModelYear,
                    Price = bicycle.Price,
                    ColorId = bicycle.ColorId,
                    ForkId = bicycle.ForkId,
                    SizeId = bicycle.SizeId,
                    TypeId = bicycle.TypeId
                })
                .ToList();

            return bicycles;
        }

        public IEnumerable<BicycleDTO> Find(string predicate)
        {
            List<BicycleDTO> bicycles = _db.Bicycles.Find(predicate)
                .Select(bicycle => new BicycleDTO
                {
                    Id = bicycle.Id,
                    ModelYear = bicycle.ModelYear,
                    Price = bicycle.Price,
                    ColorId = bicycle.ColorId,
                    ForkId = bicycle.ForkId,
                    SizeId = bicycle.SizeId,
                    TypeId = bicycle.TypeId
                })
                .ToList();

            return bicycles;
        }

        public void Create(BicycleDTO obj)
        {
            BicycleEntity bicycle = new BicycleEntity
            {

                Id = obj.Id,
                ModelYear = obj.ModelYear,
                Price = obj.Price,
                ColorId = obj.ColorId,
                ForkId = obj.ForkId,
                SizeId = obj.SizeId,
                TypeId = obj.TypeId
            };

            _db.Bicycles.Create(bicycle);
            _db.Save();
        }

        public void Delete(int id)
        {
            _db.Bicycles.Delete(id);
            _db.Save();
        }

        public void Update(BicycleDTO obj)
        {
            BicycleEntity bicycle = new BicycleEntity
            {

                Id = obj.Id,
                ModelYear = obj.ModelYear,
                Price = obj.Price,
                ColorId = obj.ColorId,
                ForkId = obj.ForkId,
                SizeId = obj.SizeId,
                TypeId = obj.TypeId
            };

            _db.Bicycles.Update(bicycle);
            _db.Save();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
