using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplementsSystem.Services.Tests.CategoriesServicesTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void Invoke_TheRepositoryMethodGetAll_Once()
        {
            //Arrange
            var categoriesMock = new Mock<IRepository<Category>>();
            CategoriesServices categoriesServices = new CategoriesServices(categoriesMock.Object);

            //Act
            IEnumerable<Category> categoryResult = categoriesServices.GetAll();

            //Assert
            categoriesMock.Verify(c => c.All(), Times.Once);
        }

        [Test]
        public void ReturnResult_WhenInvokingRepositoryMethod_GetAll()
        {
            //Arrange
            var categoriesMock = new Mock<IRepository<Category>>();
            IEnumerable<Category> expectedResultCollection = new List<Category>();

            categoriesMock.Setup(c => c.All()).Returns(() =>
              {
                  return expectedResultCollection;
              });

            CategoriesServices categoriesServices = new CategoriesServices(categoriesMock.Object);

            //Act
            IEnumerable<Category> categoryResult = categoriesServices.GetAll();

            //Assert
            Assert.That(categoryResult, Is.EqualTo(expectedResultCollection));
        }

        [Test]
        public void ReturnResultOfCorrectType()
        {
            //Arrange
            var categoriesMock = new Mock<IRepository<Category>>();

            categoriesMock.Setup(c => c.All()).Returns(() =>
            {
                IEnumerable<Category> expectedResultCollection = new List<Category>();
                return expectedResultCollection;
            });

            CategoriesServices categoriesServices = new CategoriesServices(categoriesMock.Object);

            //Act
            IEnumerable<Category> categoryResult = categoriesServices.GetAll();

            //Assert
            Assert.That(categoryResult, Is.InstanceOf<IEnumerable<Category>>());
        }

        [Test]
        public void ReturnNull_WhenReposityMethodGetAll_ReturnsNull()
        {
            //Arrange
            var categoriesMock = new Mock<IRepository<Category>>();

            categoriesMock.Setup(c => c.All()).Returns(() =>
            {
                return null;
            });

            CategoriesServices categoriesServices = new CategoriesServices(categoriesMock.Object);

            //Act
            IEnumerable<Category> categoryResult = categoriesServices.GetAll();

            //Assert
            Assert.IsNull(categoryResult);
        }
    }
}
