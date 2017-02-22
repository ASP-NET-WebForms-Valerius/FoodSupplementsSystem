using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace FoodSupplementsSystem.Services.Tests.CategoriesServicesTests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void Throw_WhenThePassedCategoryIsNull()
        {
            //Arrange
            var categoriesMock = new Mock<IRepository<Category>>();
            CategoriesServices categoriesServices = new CategoriesServices(categoriesMock.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => categoriesServices.Create(null));
        }

        [Test]
        public void InvokeRepositoryMethodAddOnce_WhenThePassedCategoryIsValid()
        {
            //Arrange
            var categoriesMock = new Mock<IRepository<Category>>();
            CategoriesServices categoriesServices = new CategoriesServices(categoriesMock.Object);
            int categoryId = 6;
            Category category = new Category() { Id = categoryId, Name = "Cards" };

            //Act
            categoriesServices.Create(category.Name);

            //Assert
            categoriesMock.Verify(x => x.Add(It.IsAny<Category>()), Times.Once);
        }
    }
}
