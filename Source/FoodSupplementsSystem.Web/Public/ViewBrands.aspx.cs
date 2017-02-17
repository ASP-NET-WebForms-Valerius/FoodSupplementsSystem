using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Contracts;
using Ninject;
using System;
using System.Linq;
using System.Web.UI;

namespace FoodSupplementsSystem.Web.Public
{
    public partial class ViewBrands : Page
    {
        [Inject]
        public IBrandsServices BrandsServices { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Brand> lvBrands_GetData()
        {
            return this.BrandsServices.GetAll().OrderBy(x => x.Id);
        }
    }
}