using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories.Contracts;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace FoodSupplementsSystem.Services.Tests.BrandsServicesTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void Invoke_TheRepositoryMethodGetAll_Once()
        {
            //Arrange
            var brandsMock = new Mock<IRepository<Brand>>();
            BrandsServices brandsServices = new BrandsServices(brandsMock.Object);

            //Act
            IEnumerable<Brand> brandResult = brandsServices.GetAll();

            //Assert
            brandsMock.Verify(c => c.All(), Times.Once);
        }

        [Test]
        public void ReturnResult_WhenInvokingRepositoryMethod_GetAll()
        {
            //Arrange
            var brandsMock = new Mock<IRepository<Brand>>();
            IEnumerable<Brand> expectedResultCollection = new List<Brand>();

            brandsMock.Setup(c => c.All()).Returns(() =>
              {
                  return expectedResultCollection;
              });

            BrandsServices brandsServices = new BrandsServices(brandsMock.Object);

            //Act
            IEnumerable<Brand> brandResult = brandsServices.GetAll();

            //Assert
            Assert.That(brandResult, Is.EqualTo(expectedResultCollection));
        }

        [Test]
        public void ReturnResultOfCorrectType()
        {
            //Arrange
            var brandsMock = new Mock<IRepository<Brand>>();

            brandsMock.Setup(c => c.All()).Returns(() =>
            {
                IEnumerable<Brand> expectedResultCollection = new List<Brand>();
                return expectedResultCollection;
            });

            BrandsServices brandsServices = new BrandsServices(brandsMock.Object);

            //Act
            IEnumerable<Brand> brandResult = brandsServices.GetAll();

            //Assert
            Assert.That(brandResult, Is.InstanceOf<IEnumerable<Brand>>());
        }

        [Test]
        public void ReturnNull_WhenReposityMethodGetAll_ReturnsNull()
        {
            //Arrange
            var brandsMock = new Mock<IRepository<Brand>>();

            brandsMock.Setup(c => c.All()).Returns(() =>
            {
                return null;
            });

            BrandsServices brandsServices = new BrandsServices(brandsMock.Object);

            //Act
            IEnumerable<Brand> brandResult = brandsServices.GetAll();

            //Assert
            Assert.IsNull(brandResult);
        }
    }
}
