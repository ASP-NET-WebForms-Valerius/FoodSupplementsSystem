using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories.Contracts;
using Moq;
using NUnit.Framework;

namespace FoodSupplementsSystem.Services.Tests.BrandsServicesTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ReturnNull_WhenIdParameterIsInvalid()
        {
            // Arrange
            var brandsMock = new Mock<IRepository<Brand>>();
            BrandsServices brandsServices = new BrandsServices(brandsMock.Object);

            // Act
            Brand brandResult = brandsServices.GetById(-1);

            // Assert
            Assert.IsNull(brandResult);
        }

        [Test]
        public void ReturnBrand_WhenIdIsValid()
        {
            //Arrange
            var brandsMock = new Mock<IRepository<Brand>>();
            int brandId = 1;
            Brand brand = new Brand() { Id = brandId, Name = "Brand1" };

            brandsMock.Setup(c => c.GetById(brandId)).Returns(brand);

            BrandsServices brandsServices = new BrandsServices(brandsMock.Object);

            //Act
            Brand brandResult = brandsServices.GetById(brandId);

            //Assert
            Assert.AreSame(brand, brandResult);
        }
    }
}
