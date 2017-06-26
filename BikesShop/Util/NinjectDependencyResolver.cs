using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BikesShop.BLL.Interfaces;
using BikesShop.BLL.Services;
using BikesShop.DAL.Entities;
using Ninject;

namespace BikesShop.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            _kernel.Bind<IService<BicycleColor>>().To<ColorsService>();
            _kernel.Bind<IService<Fork>>().To<ForkService>();
           
        }
    }
}