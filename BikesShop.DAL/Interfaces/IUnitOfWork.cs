using System;
using BikesShop.DAL.Entities;

namespace BikesShop.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBicycleRepository Bicycles { get; }
        IBicycleSizeRepository BicyclesSize { get; }
        IBicycleTypeRepository BicycleType { get; }
        IColorRepository BicycleColors { get; }
        IForkRepository Forks { get; }

        void Save();
    }
}
