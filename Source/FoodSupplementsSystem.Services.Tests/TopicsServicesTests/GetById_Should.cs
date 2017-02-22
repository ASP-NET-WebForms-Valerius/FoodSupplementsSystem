using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories.Contracts;
using Moq;
using NUnit.Framework;

namespace FoodSupplementsSystem.Services.Tests.TopicsServicesTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ReturnNull_WhenIdParameterIsInvalid()
        {
            // Arrange
            var topicsMock = new Mock<IRepository<Topic>>();
            TopicsServices topicsServices = new TopicsServices(topicsMock.Object);

            // Act
            Topic topicResult = topicsServices.GetById(-1);

            // Assert
            Assert.IsNull(topicResult);
        }

        [Test]
        public void ReturnTopic_WhenIdIsValid()
        {
            //Arrange
            var topicsMock = new Mock<IRepository<Topic>>();
            int topicId = 1;
            Topic topic = new Topic() { Id = topicId, Name = "Topic1" };

            topicsMock.Setup(c => c.GetById(topicId)).Returns(topic);

            TopicsServices topicsServices = new TopicsServices(topicsMock.Object);

            //Act
            Topic topicResult = topicsServices.GetById(topicId);

            //Assert
            Assert.AreSame(topic, topicResult);
        }
    }
}
