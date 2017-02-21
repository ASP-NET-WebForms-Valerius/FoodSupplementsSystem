using FoodSupplementsSystem.Web.PresenterFactories;
using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;
using WebFormsMvp.Binder;

namespace FoodSupplementsSystem.Web.NinjectBindingsModules
{
    public class MvpNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IPresenterFactory>()
                .To<WebFormsMvpPresenterFactory>()
                .InSingletonScope();

            this.Bind<ICustomPresenterFactory>()
                .ToFactory()
                .InSingletonScope();

            this.Bind<IPresenter>()
                .ToMethod(this.GetPresenterFactoryMethod)
                .NamedLikeFactoryMethod((ICustomPresenterFactory factory) => factory.GetPresenter(null, null));
        }

        private IPresenter GetPresenterFactoryMethod(IContext context)
        {
            var parameters = context.Parameters.ToList();

            var requestedType = (Type)parameters[0].GetValue(context, null);
            var viewInstance = (IView)parameters[1].GetValue(context, null);

            var viewInstanceCtorParameter = new ConstructorArgument("view", viewInstance);

            return (IPresenter)context.Kernel.Get(requestedType, viewInstanceCtorParameter);
        }
    }
}