using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

using FoodSupplementsSystem.Data.Repositories.Contracts;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace FoodSupplementsSystem.Data.Repositories
{
    public class GenericRepository<T> : IRepository<T>, IExtendedRepository<T> where T : class
    {
        public GenericRepository(IFoodSupplementsSystemDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
            this.Db = this.Context.Db;
        }

        protected IFoodSupplementsSystemDbContext Context { get; set; }

        protected IDbSet<T> DbSet { get; set; }

        protected Database Db { get; set; }

        public virtual IQueryable<T> ExecuteStoredProcedure(string spName, Object param1Value)
        {
            //context.Database.SqlQuery<myEntityType>(
            //    "mySpName @param1, @param2, @param3",
            //    new SqlParameter("param1", param1),
            //    new SqlParameter("param2", param2),
            //    new SqlParameter("param3", param3)
            //);
            // Sourcees:
            // http://stackoverflow.com/questions/4873607/how-to-use-dbcontext-database-sqlquerytelementsql-params-with-stored-proced
            // https://msdn.microsoft.com/en-US/data/jj592907

            string param1Key = "@param1";
            string sqlCommand = "EXECUTE [dbo].["+ spName + "] " + param1Key + " ";
            SqlParameter sqlParam1 = new SqlParameter(param1Key, SqlDbType.Int);
            sqlParam1.Value = param1Value;

            ICollection<T> commandResult = this.Db.SqlQuery<T>(sqlCommand, sqlParam1).ToList<T>();

            //"[dbo].[usp_GetSupplementRatingBySupplementId]", this.Id


            return commandResult.AsQueryable<T>();
        }

        public virtual IQueryable<T> ExecuteStoredProcedure(string spName, Object param1Value, Object param2Value)
        {
            //context.Database.SqlQuery<myEntityType>(
            //    "mySpName @param1, @param2, @param3",
            //    new SqlParameter("param1", param1),
            //    new SqlParameter("param2", param2),
            //    new SqlParameter("param3", param3)
            //);
            // Sourcees:
            // http://stackoverflow.com/questions/4873607/how-to-use-dbcontext-database-sqlquerytelementsql-params-with-stored-proced
            // https://msdn.microsoft.com/en-US/data/jj592907

            string param1Key = "@param1";
            string param2Key = "@param2";
            string sqlCommand = "EXECUTE [dbo].[" + spName + "] " + param1Key + ", " + param2Key + " ";
            SqlParameter sqlParam1 = new SqlParameter(param1Key, SqlDbType.VarChar);
            SqlParameter sqlParam2 = new SqlParameter(param2Key, SqlDbType.Int);
            sqlParam1.Value = param1Value;
            sqlParam2.Value = param2Value;

            //SqlParameter sqlParam1 = new SqlParameter(param1Name, param1Value);
            //SqlParameter sqlParam2 = new SqlParameter(param2Name, param2Value);
            ICollection<T> commandResult = this.Db.SqlQuery<T>(sqlCommand, sqlParam1, sqlParam2).ToList<T>();

            return commandResult.AsQueryable<T>();
        }

        public virtual IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }

        public virtual T GetById(int id)
        {
            return this.DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }

        public virtual void Delete(int id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public virtual void Detach(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            entry.State = EntityState.Detached;
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}
