using FoodSupplementsSystem.Services.Contracts;
using System;
using WebFormsMvp;

namespace FoodSupplementsSystem.MVP.ViewCategories
{
    public class ViewCategoriesPresenter : Presenter<IViewCategoriesView>
    {
        private readonly ICategoriesServices categoriesServices;

        public ViewCategoriesPresenter(IViewCategoriesView view, ICategoriesServices categoriesServices) : base(view)
        {
            this.categoriesServices = categoriesServices;

            this.View.OnCategoriesGetData += this.View_OnCategoriesGetData;
        }

        private void View_OnCategoriesGetData(object sender, EventArgs e)
        {
            this.View.Model.Categories = this.categoriesServices.GetAll();
        }
    }
}
