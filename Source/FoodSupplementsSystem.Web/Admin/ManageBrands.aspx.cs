using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Contracts;
using Ninject;
using System;
using System.Linq;
using System.Web.UI;

namespace FoodSupplementsSystem.Web.Admin
{
    public partial class ManageBrands : Page
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
        public IQueryable<Brand> gvBrands_GetData()
        {
            return this.BrandsServices.GetAll().OrderBy(x => x.Id);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void gvBrands_UpdateItem(int id)
        {
            var brand = new Brand();

            TryUpdateModel(brand);

            this.BrandsServices.UpdateById(id, brand);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void gvBrands_DeleteItem(int id)
        {
            this.BrandsServices.DeleteById(id);
        }
    }
}