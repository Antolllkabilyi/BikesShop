using System;
using BikesShop.DAL.EF;
using BikesShop.DAL.Interfaces;

namespace BikesShop.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly BicycleContext _db;
        private bool _disposed;
        private IBicycleRepository _bicycleRepository;
        private IBicycleSizeRepository _bicycleSizeRepository;
        private IBicycleTypeRepository _bicycleTypeRepository;
        private IColorRepository _bicycleColorRepository;
        private IForkRepository _forksRepository;
        private IPurchaseRepository _purchaseRepository;

        public EFUnitOfWork()
        {
            _db = new BicycleContext();
        }
        
        public EFUnitOfWork(string connectionString)
        {
            _db = new BicycleContext(connectionString);
        }

        public IBicycleRepository Bicycles => _bicycleRepository ?? (_bicycleRepository = new BicycleRepository(_db));
        public IBicycleSizeRepository BicyclesSize => _bicycleSizeRepository ?? (_bicycleSizeRepository = new BicycleSizeRepository(_db));
        public IBicycleTypeRepository BicycleType => _bicycleTypeRepository ?? (_bicycleTypeRepository = new BicycleTypeRepository(_db));
        public IColorRepository BicycleColors => _bicycleColorRepository ?? (_bicycleColorRepository = new BicycleColorRepository(_db));
        public IForkRepository Forks => _forksRepository ?? (_forksRepository = new ForkRepository(_db));
        public IPurchaseRepository Purchases => _purchaseRepository ?? (_purchaseRepository = new PurchaseRepository(_db));

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposed)
        {
            if (!_disposed)
            {
                if (disposed)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
