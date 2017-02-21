using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.MVP.ViewCategories;
using System;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace FoodSupplementsSystem.Web.Public
{
    [PresenterBinding(typeof(ViewCategoriesPresenter))]
    public partial class ViewCategories : MvpPage<ViewCategoriesViewModel>, IViewCategoriesView
    {
        public event EventHandler OnCategoriesGetData;

        public IQueryable<Category> lvCategories_GetData()
        {
            this.OnCategoriesGetData?.Invoke(this, null);

            return this.Model.Categories;
        }
    }
}