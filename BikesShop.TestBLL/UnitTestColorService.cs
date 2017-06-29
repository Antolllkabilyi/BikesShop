using System;
using System.Collections.Generic;
using System.Linq;
using BikesShop.BLL.DTO;
using BikesShop.BLL.Interfaces;
using BikesShop.BLL.Services;
using BikesShop.DAL.Entities;
using BikesShop.DAL.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject;

namespace BikesShop.TestBLL
{
    [TestClass]
    public class UnitTestColorService
    {
        private readonly Mock<IColorRepository> _colorRepositoryMock = new Mock<IColorRepository>();

        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
        private ColorsService _service;

        private IKernel _kernel;
        [TestInitialize]
        public void TestInit()
        {
            _kernel = new StandardKernel();
            _kernel.Bind<IColorRepository>().ToConstant(_unitOfWorkMock.Object.BicycleColors);
         
        }

        [TestMethod]
        public void GetAll_Color()
        {
            BicycleColorDTO color = new BicycleColorDTO
            {
                Name = "Blue"
            };

            var mock = new Mock<IUnitOfWork>();
           
            _service = new ColorsService(mock.Object);
            //_service.Create(color);
          
            _service.Create(color);
            List<BicycleColorDTO> colors = _service.GetAll().ToList();
            //Assert.IsTrue(isCreateCalled);
            Assert.AreEqual(0,colors.Count);
        }

    }
}
