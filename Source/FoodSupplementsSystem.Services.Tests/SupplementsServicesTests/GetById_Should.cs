using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace FoodSupplementsSystem.Services.Tests.SupplementsServicesTests
{
    public class GetById_Should
    {
        [Test]
        public void ReturnNull_WhenIdParameterIsInvalid()
        {
            // Arrange
            var supplementsServicesMocked = new Mock<ISupplementsServices>();
            int id = -1;

            // Act
            Supplement supplementResult = supplementsServicesMocked.Object.GetById(id);

            // Assert
            Assert.AreSame(null, supplementResult);
        }
    }
}
