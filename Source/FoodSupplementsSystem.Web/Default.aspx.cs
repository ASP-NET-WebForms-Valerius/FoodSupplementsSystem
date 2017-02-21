using FoodSupplementsSystem.Data.Contracts;
using FoodSupplementsSystem.Services.Contracts;
using FoodSupplementsSystem.Web.App_Start;
using Microsoft.AspNet.Identity;
using Ninject;
using System;
using System.Web.UI;

namespace FoodSupplementsSystem.Web
{
    public partial class _Default : Page
    {
        public _Default()
        {
            this.UnitOfWork = NinjectWebCommon.Kernel.Get<IUnitOfWork>();
            this.CommentsService = NinjectWebCommon.Kernel.Get<ICommentsServices>();
        }

        protected IUnitOfWork UnitOfWork { get; private set; }
        protected ICommentsServices CommentsService { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Uncomment if you want to seed the data from the SeedDataAlexDb class.
            //string userId = this.User.Identity.GetUserId();
            //SeedDataAlexDb seedData = new SeedDataAlexDb(this.UnitOfWork, this.CommentsService, userId);
            //seedData.SeedAllData();
        }
    }
}