using System;
using System.Data.Entity;
using BikesShop.DAL.Entities;
using BikesShop.DAL.Repositories;

namespace BikesShop.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IColorRepository BicycleColors { get; }
        IRepository<ForkEntity> Forks { get; }
        
        void Save();
    }
}
