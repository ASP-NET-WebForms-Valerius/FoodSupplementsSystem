using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Data.Contracts;

namespace FoodSupplementsSystem.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly FoodSupplementsSystemDbContext context;
        private SupplementRepository supplementRepository;
        private RatingRepository ratingRepository;
        private CategoryRepository categoryRepository;
        private TopicRepository topicRepository;
        private BrandRepository brandRepository;

        private bool disposed = false;

        public UnitOfWork(FoodSupplementsSystemDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("An instance of DbContext is required to use this UnitOfWork.", "context");
            }

            this.context = context;
        }

        // TODO check how to do property injection
        public SupplementRepository SupplementRepository
        {
            get
            {
                if (this.supplementRepository == null)
                {
                    this.supplementRepository = new SupplementRepository(this.context);
                }

                return this.supplementRepository;
            }
        }

        // TODO check how to do property injection
        public RatingRepository RatingRepository
        {
            get
            {
                if (this.ratingRepository == null)
                {
                    this.ratingRepository = new RatingRepository(this.context);
                }

                return this.ratingRepository;
            }
        }

        // TODO check how to do property injection
        public CategoryRepository CategoryRepository
        {
            get
            {
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new CategoryRepository(this.context);
                }

                return this.categoryRepository;
            }
        }

        // TODO check how to do property injection
        public TopicRepository TopicRepository
        {
            get
            {
                if (this.topicRepository == null)
                {
                    this.topicRepository = new TopicRepository(this.context);
                }

                return this.topicRepository;
            }
        }

        // TODO check how to do property injection
        public BrandRepository BrandRepository
        {
            get
            {
                if (this.brandRepository == null)
                {
                    this.brandRepository = new BrandRepository(this.context);
                }

                return this.brandRepository;
            }
        }


        public void Save()
        {
            this.context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            bool isDisposed = this.disposed;
            if (!isDisposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
