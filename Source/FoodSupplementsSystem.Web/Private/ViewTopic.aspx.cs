using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Contracts;
using FoodSupplementsSystem.Web.App_Start;
using Ninject;
using System;
using System.Web.ModelBinding;
using System.Web.UI;

namespace FoodSupplementsSystem.Web.Private
{
    public partial class ViewTopic : Page
    {
        private ITopicsServices topicsServices;

        public ViewTopic()
        {
            this.topicsServices = NinjectWebCommon.Kernel.Get<ITopicsServices>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Topic fvDetails_GetItem([QueryString]string id)
        {
            return this.topicsServices.GetById(int.Parse(id));
        }
    }
}