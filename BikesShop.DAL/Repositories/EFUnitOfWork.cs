using System;
using BikesShop.DAL.EF;
using BikesShop.DAL.Entities;
using BikesShop.DAL.Interfaces;

namespace BikesShop.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly BicycleContext _db;
        private bool _disposed;
        private BicycleColorRepository _bicycleColorRepository;
        private ForkRepository _forksRepository;

        public EFUnitOfWork()
        {
            _db = new BicycleContext("BicycleContext");
        }


        public EFUnitOfWork(string connectionString)
        {
            _db = new BicycleContext(connectionString);
        }

        public IColorRepository BicycleColors
        {
            get
            {
                if(_bicycleColorRepository == null)
                    _bicycleColorRepository = new BicycleColorRepository(_db);
                return _bicycleColorRepository;
            }
        }

        public IRepository<ForkEntity> Forks
        {
            get
            {
                if (_forksRepository == null)
                    _forksRepository = new ForkRepository(_db);
                return _forksRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
