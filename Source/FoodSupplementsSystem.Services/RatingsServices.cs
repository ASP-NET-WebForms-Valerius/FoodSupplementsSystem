using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories.Contracts;
using FoodSupplementsSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplementsSystem.Services
{
    public class RatingsServices : IRatingsServices
    {
        private readonly IRatingRepository ratingRepository;

        public RatingsServices(IRatingRepository ratingRepository)
        {
            this.ratingRepository = ratingRepository;
        }

        public Rating GetById(int id)
        {
            Rating ratingToReturn = this.ratingRepository.GetById(id);

            return ratingToReturn;
        }

        public IEnumerable<Rating> GetAll()
        {
            IEnumerable<Rating> ratingsToReturn = this.ratingRepository.All();

            return ratingsToReturn;
        }

        public virtual void Add(Rating rating)
        {
            this.ratingRepository.Add(rating);

            this.ratingRepository.SaveChanges();
        }

        public virtual void Update(Rating rating)
        {
            this.ratingRepository.Update(rating);

            this.ratingRepository.SaveChanges();
        }

        public virtual void Delete(Rating rating)
        {
            this.ratingRepository.Delete(rating);

            this.ratingRepository.SaveChanges();
        }

        public virtual void Delete(int ratingId)
        {
            this.ratingRepository.Delete(ratingId);

            this.ratingRepository.SaveChanges();
        }

        public virtual void Dispose()
        {
            this.ratingRepository.Dispose();
        }
    }
}
