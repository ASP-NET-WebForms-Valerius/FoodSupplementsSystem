using System;
using WebFormsMvp;

namespace FoodSupplementsSystem.MVP.ViewCategories
{
    public interface IViewCategoriesView : IView<ViewCategoriesViewModel>
    {
        event EventHandler OnCategoriesGetData;
    }
}
