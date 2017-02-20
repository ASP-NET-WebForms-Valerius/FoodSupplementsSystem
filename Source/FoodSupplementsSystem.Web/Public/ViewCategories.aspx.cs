using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Contracts;
using FoodSupplementsSystem.Web.App_Start;
using Ninject;
using System;
using System.Linq;
using System.Web.UI;

namespace FoodSupplementsSystem.Web.Public
{
    public partial class ViewCategories : Page
    {
        private readonly ICategoriesServices categoriesServices;

        public ViewCategories()
        {
            this.categoriesServices = NinjectWebCommon.Kernel.Get<ICategoriesServices>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Category> lvCategories_GetData()
        {
            return this.categoriesServices.GetAll().OrderBy(x => x.Id);
        }
    }
}