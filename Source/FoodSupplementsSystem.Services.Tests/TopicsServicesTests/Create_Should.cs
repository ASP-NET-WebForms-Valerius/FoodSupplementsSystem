using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace FoodSupplementsSystem.Services.Tests.TopicsServicesTests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void Throw_WhenThePassedTopicIsNull()
        {
            //Arrange
            var topicsMock = new Mock<IRepository<Topic>>();
            TopicsServices topicsServices = new TopicsServices(topicsMock.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => topicsServices.Create(null));
        }

        [Test]
        public void InvokeRepositoryMethodAddOnce_WhenThePassedTopicIsValid()
        {
            //Arrange
            var topicsMock = new Mock<IRepository<Topic>>();
            TopicsServices topicsServices = new TopicsServices(topicsMock.Object);
            int topicId = 2;
            Topic topic = new Topic() { Id = topicId, Name = "Topic1" };

            //Act
            topicsServices.Create(topic);

            //Assert
            topicsMock.Verify(x => x.Add(It.IsAny<Topic>()), Times.Once);
        }
    }
}
