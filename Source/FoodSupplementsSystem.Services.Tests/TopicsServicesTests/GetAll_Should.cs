using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories.Contracts;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace FoodSupplementsSystem.Services.Tests.TopicsServicesTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void Invoke_TheRepositoryMethodGetAll_Once()
        {
            //Arrange
            var topicsMock = new Mock<IRepository<Topic>>();
            TopicsServices topicsServices = new TopicsServices(topicsMock.Object);

            //Act
            IEnumerable<Topic> topicResult = topicsServices.GetAll();

            //Assert
            topicsMock.Verify(c => c.All(), Times.Once);
        }

        [Test]
        public void ReturnResult_WhenInvokingRepositoryMethod_GetAll()
        {
            //Arrange
            var topicsMock = new Mock<IRepository<Topic>>();
            IEnumerable<Topic> expectedResultCollection = new List<Topic>();

            topicsMock.Setup(c => c.All()).Returns(() =>
              {
                  return expectedResultCollection;
              });

            TopicsServices topicsServices = new TopicsServices(topicsMock.Object);

            //Act
            IEnumerable<Topic> topicResult = topicsServices.GetAll();

            //Assert
            Assert.That(topicResult, Is.EqualTo(expectedResultCollection));
        }

        [Test]
        public void ReturnResultOfCorrectType()
        {
            //Arrange
            var topicsMock = new Mock<IRepository<Topic>>();

            topicsMock.Setup(c => c.All()).Returns(() =>
            {
                IEnumerable<Topic> expectedResultCollection = new List<Topic>();
                return expectedResultCollection;
            });

            TopicsServices topicsServices = new TopicsServices(topicsMock.Object);

            //Act
            IEnumerable<Topic> topicResult = topicsServices.GetAll();

            //Assert
            Assert.That(topicResult, Is.InstanceOf<IEnumerable<Topic>>());
        }

        [Test]
        public void ReturnNull_WhenReposityMethodGetAll_ReturnsNull()
        {
            //Arrange
            var topicsMock = new Mock<IRepository<Topic>>();

            topicsMock.Setup(c => c.All()).Returns(() =>
            {
                return null;
            });

            TopicsServices topicsServices = new TopicsServices(topicsMock.Object);

            //Act
            IEnumerable<Topic> topicResult = topicsServices.GetAll();

            //Assert
            Assert.IsNull(topicResult);
        }
    }
}
