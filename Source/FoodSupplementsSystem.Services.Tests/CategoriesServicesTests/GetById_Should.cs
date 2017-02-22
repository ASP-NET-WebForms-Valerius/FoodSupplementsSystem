using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories.Contracts;
using Moq;
using NUnit.Framework;

namespace FoodSupplementsSystem.Services.Tests.CategoriesServicesTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ReturnNull_WhenIdParameterIsInvalid()
        {
            // Arrange
            var categoriesMock = new Mock<IRepository<Category>>();
            CategoriesServices categoriesServices = new CategoriesServices(categoriesMock.Object);

            // Act
            Category categoryResult = categoriesServices.GetById(-1);

            // Assert
            Assert.IsNull(categoryResult);
        }

        [Test]
        public void ReturnCategory_WhenIdIsValid()
        {
            //Arrange
            var categoriesMock = new Mock<IRepository<Category>>();
            int categoryId = 1;
            Category category = new Category() { Id = 1, Name = "Category1" };

            categoriesMock.Setup(c => c.GetById(categoryId)).Returns(category);

            CategoriesServices categoriesServices = new CategoriesServices(categoriesMock.Object);

            //Act
            Category categoryResult = categoriesServices.GetById(categoryId);

            //Assert
            Assert.AreSame(category, categoryResult);
        }
    }
}
