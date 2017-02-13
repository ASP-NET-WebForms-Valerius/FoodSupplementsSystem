using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Contracts;
using Ninject;
using System;
using System.Linq;

namespace FoodSupplementsSystem.Web.Admin
{
    public partial class ManageCategories : System.Web.UI.Page
    {
        [Inject]
        public ICategoriesServices CategoriesServices { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Category> gvCategories_GetData()
        {
            return this.CategoriesServices.GetAll().OrderBy(x => x.Id);
        }
    }
}