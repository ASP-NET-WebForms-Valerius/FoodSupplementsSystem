using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories.Contracts;
using FoodSupplementsSystem.Services.Contracts;
using System.Collections.Generic;

namespace FoodSupplementsSystem.Services
{
    public class TopicsServices : ITopicsServices
    {
        private IRepository<Topic> topics;

        public TopicsServices(IRepository<Topic> topics)
        {
            this.topics = topics;
        }

        public IEnumerable<Topic> GetAll()
        {
            return this.topics.All();
        }

        public Topic GetById(int id)
        {
            return this.topics.GetById(id);
        }

        public void Create(Topic topic)
        {
            this.topics.Add(topic);
            this.topics.SaveChanges();
        }

        public void UpdateById(int id, Topic updateTopic)
        {
            var topicToUpdate = this.topics.GetById(id);

            topicToUpdate.Name = updateTopic.Name;
            topicToUpdate.Description = updateTopic.Description;

            this.topics.SaveChanges();
        }

        public void DeleteById(int id)
        {
            this.topics.Delete(id);
            this.topics.SaveChanges();
        }
    }
}