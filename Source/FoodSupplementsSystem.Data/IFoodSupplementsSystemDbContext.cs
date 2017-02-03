using FoodSupplementsSystem.Data.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace FoodSupplementsSystem.Data
{
    public interface IFoodSupplementsSystemDbContext : IDisposable
    {
        int SaveChanges();

        IDbSet<User> Users { get; set; }

        IDbSet<Supplement> Supplements { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Topic> Topics { get; set; }

        IDbSet<Brand> Brands { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Like> Likes { get; set; }

        IDbSet<Rating> Ratings { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
