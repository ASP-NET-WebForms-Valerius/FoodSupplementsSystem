using NUnit.Framework;

using FoodSupplementsSystem.Data;
using FoodSupplementsSystem.Data.Models;

namespace FoodSupplementsSystem.Services.Tests.SupplementsServicesTests
{
    public class GetById_Should
    {
        [Test]
        public void ReturnNull_WhenIdParameterIsNull()
        {
            // Arrange
            var dbContextMocked = new FoodSupplementsSystemDbContext();
            var unitOfWorkMocked = new UnitOfWork(dbContextMocked);
            var supplementsServicesMocked = new SupplementsServices(unitOfWorkMocked.SupplementRepository);
            int id = -1;

            // Act
            Supplement supplementResult = supplementsServicesMocked.GetById(id);

            // Assert
            Assert.AreSame(null, supplementResult);
        }
    }
}
