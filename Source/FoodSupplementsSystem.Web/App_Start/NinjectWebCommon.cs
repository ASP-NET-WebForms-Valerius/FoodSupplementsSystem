[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(FoodSupplementsSystem.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(FoodSupplementsSystem.Web.App_Start.NinjectWebCommon), "Stop")]

namespace FoodSupplementsSystem.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;

    using Data;
    using Data.Repositories.Contracts;
    using Data.Repositories;
    using Data.Contracts;
    using FoodSupplements;
    using NinjectBindingsModules;
    using WebFormsMvp.Binder;
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            Kernel = new StandardKernel();
            try
            {
                Kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                Kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(Kernel);
                return Kernel;
            }
            catch
            {
                Kernel.Dispose();
                throw;
            }
        }

        public static IKernel Kernel
        {
            get;
            private set;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Load(new MvpNinjectModule());

            PresenterBinder.Factory = kernel.Get<IPresenterFactory>();

            kernel.Bind(typeof(IFoodSupplementsSystemDbContext)).To(typeof(FoodSupplementsSystemDbContext)).InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
            kernel.Bind<IBrandRepository>().To<BrandRepository>();
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            kernel.Bind<IRatingRepository>().To<RatingRepository>();
            kernel.Bind<ISupplementRepository>().To<SupplementRepository>();
            kernel.Bind<ITopicRepository>().To<TopicRepository>();

            kernel.Bind(b => b.From("FoodSupplementsSystem.Services")
                              .SelectAllClasses()
                              .BindDefaultInterface());

            kernel.Bind<ISupplementFilters>().To<SupplementFilters>().InRequestScope();

        }
    }
}
