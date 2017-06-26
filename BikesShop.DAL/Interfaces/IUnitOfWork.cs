using System;
using BikesShop.DAL.Entities;
using BikesShop.DAL.Repositories;

namespace BikesShop.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<BicycleColor> BicycleColors { get; }
        IRepository<Fork> Forks { get; }
        
        void Save();
    }
}
