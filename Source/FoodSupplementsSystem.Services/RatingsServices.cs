using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories.Contracts;
using FoodSupplementsSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public virtual IEnumerable<Rating> ExecuteStoredProcedure(string spName, int param1Value)
        {
            string param1Key = "@param1";
            string sqlCommand = "EXECUTE [dbo].[" + spName + "] " + param1Key + " ";
            SqlParameter sqlParam1 = new SqlParameter(param1Key, SqlDbType.VarChar);
            sqlParam1.Value = param1Value;

            IEnumerable<Rating> ratingToReturn = this.ratingRepository.ExecuteStoredProcedure(spName, sqlParam1);

            return ratingToReturn;
        }

        public virtual IEnumerable<Rating> ExecuteStoredProcedure(string spName, string param1Value, int param2Value)
        {
            string param1Key = "@param1";
            string param2Key = "@param2";
            string sqlCommand = "EXECUTE [dbo].[" + spName + "] " + param1Key + ", " + param2Key + " ";
            SqlParameter sqlParam1 = new SqlParameter(param1Key, SqlDbType.VarChar);
            SqlParameter sqlParam2 = new SqlParameter(param2Key, SqlDbType.Int);
            sqlParam1.Value = param1Value;
            sqlParam2.Value = param2Value;

            IEnumerable<Rating> ratingToReturn = this.ratingRepository.ExecuteStoredProcedure(spName, sqlParam1, sqlParam2);

            return ratingToReturn;
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
