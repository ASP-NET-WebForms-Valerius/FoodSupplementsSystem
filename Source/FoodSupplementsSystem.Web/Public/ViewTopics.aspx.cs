using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Contracts;
using FoodSupplementsSystem.Web.App_Start;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace FoodSupplementsSystem.Web.Public
{
    public partial class ViewTopics : Page
    {
        private readonly ITopicsServices topicsServices;

        public ViewTopics()
        {
            this.topicsServices = NinjectWebCommon.Kernel.Get<ITopicsServices>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Topic> lvTopics_GetData()
        {
            return this.topicsServices.GetAll().OrderBy(x => x.Id);
        }
    }
}