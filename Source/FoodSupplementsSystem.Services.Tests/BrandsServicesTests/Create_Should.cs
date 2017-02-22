using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace FoodSupplementsSystem.Services.Tests.BrandsServicesTests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void Throw_WhenThePassedBrandIsNull()
        {
            //Arrange
            var brandsMock = new Mock<IRepository<Brand>>();
            BrandsServices brandsServices = new BrandsServices(brandsMock.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => brandsServices.Create(null));
        }

        [Test]
        public void InvokeRepositoryMethodAddOnce_WhenThePassedBrandIsValid()
        {
            //Arrange
            var brandsMock = new Mock<IRepository<Brand>>();
            BrandsServices brandsServices = new BrandsServices(brandsMock.Object);
            int brandId = 2;
            Brand brand = new Brand() { Id = brandId, Name = "Brand1" };

            //Act
            brandsServices.Create(brand);

            //Assert
            brandsMock.Verify(x => x.Add(It.IsAny<Brand>()), Times.Once);
        }
    }
}
