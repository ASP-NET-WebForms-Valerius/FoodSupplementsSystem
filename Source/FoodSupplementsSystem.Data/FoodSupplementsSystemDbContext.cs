﻿using System;
using System.Data.Entity;
using FoodSupplementsSystem.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FoodSupplementsSystem.Data
{
    public class FoodSupplementsSystemDbContext : IdentityDbContext<User>, IFoodSupplementsSystemDbContext
    {
        // Uncomment folowing lines if you want explicitly to use (LocalDb)
        //public FoodSupplementsSystemDbContext()
        //    : base("DefaultConnection", throwIfV1Schema: false)
        //{
        //}
        public FoodSupplementsSystemDbContext()
            : base("name=FoodSupplementsContextConnectionString", throwIfV1Schema: false)
        {
        }

        public Database Db {
            get
            {
                return base.Database;
            }
        }

        public IDbSet<Brand> Brands { get; set; }
        
        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Like> Likes { get; set; }

        public IDbSet<Rating> Ratings { get; set; }

        public IDbSet<Supplement> Supplements { get; set; }

        public IDbSet<Topic> Topics { get; set; }

        // TODO discuss if a good idea, when using container
        public static FoodSupplementsSystemDbContext Create()
        {
            return new FoodSupplementsSystemDbContext();
        }        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Supplement>()
                .HasRequired(p => p.Category)
                .WithMany(x => x.Supplements)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
