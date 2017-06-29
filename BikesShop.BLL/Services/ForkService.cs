using System.Collections.Generic;
using System.Linq;
using BikesShop.BLL.DTO;
using BikesShop.BLL.Interfaces;
using BikesShop.DAL.Entities;
using BikesShop.DAL.Interfaces;

namespace BikesShop.BLL.Services
{
    public class ForkService : IForkService
    {
        private readonly IUnitOfWork _db;

        public ForkService(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        public ForkDTO GetById(int? id)
        {
            if (id == null || id < 0)
                return null;

            var fork = _db.Forks.Get(id);

            if (fork == null)
                return null;

            ForkDTO forkDto = new ForkDTO
            {
                Id = fork.Id,
                Name = fork.Name,
                ForkBrand = fork.ForkBrand,
                ForkType = fork.ForkType
            };

            return forkDto;
        }

        public IEnumerable<ForkDTO> GetAll()
        {
            List<ForkDTO> forks = _db.Forks.GetAll()
                .Select(fork => new ForkDTO
                {
                    Id = fork.Id,
                    Name = fork.Name,
                    ForkBrand = fork.ForkBrand,
                    ForkType = fork.ForkType
                })
                .ToList();

            return forks;
        }

        public IEnumerable<ForkDTO> GetPartFromIndex(int index, int count)
        {
            List<ForkDTO> forks = _db.Forks.GetPartFromIndex(index,count)
                .Select(fork => new ForkDTO
                {
                    Id = fork.Id,
                    Name = fork.Name,
                    ForkBrand = fork.ForkBrand,
                    ForkType = fork.ForkType
                })
                .ToList();

            return forks;
        }

        public IEnumerable<ForkDTO> Find(string predicate)
        {
            List<ForkDTO> forks = _db.Forks.Find(predicate)
                .Select(fork => new ForkDTO
                {
                    Id = fork.Id,
                    Name = fork.Name,
                    ForkBrand = fork.ForkBrand,
                    ForkType = fork.ForkType
                })
                .ToList();

            return forks;
        }

        public void Create(ForkDTO obj)
        {
            ForkEntity fork = new ForkEntity
            {
                Id = obj.Id,
                Name = obj.Name,
                ForkBrand = obj.ForkBrand,
                ForkType = obj.ForkType
            };

            _db.Forks.Create(fork);
            _db.Save();
        }

        public void Delete(int id)
        {
            _db.Forks.Delete(id);
            _db.Save();
        }

        public void Update(ForkDTO obj)
        {
            ForkEntity fork = new ForkEntity()
            {
                Id = obj.Id,
                Name = obj.Name,
                ForkBrand = obj.ForkBrand,
                ForkType = obj.ForkType
            };

            _db.Forks.Update(fork);
            _db.Save();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
