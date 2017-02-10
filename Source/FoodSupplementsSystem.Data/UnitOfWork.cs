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

        private bool disposed = false;

        public UnitOfWork(FoodSupplementsSystemDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("An instance of DbContext is required to use this UnitOfWork.", "context");
            }

            this.context = context;
        }

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
