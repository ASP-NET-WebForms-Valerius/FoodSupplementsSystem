using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Contracts;
using FoodSupplementsSystem.Web.App_Start;
using Ninject;
using System;
using System.Linq;
using System.Web.UI;

namespace FoodSupplementsSystem.Web.Admin
{
    public partial class ManageBrands : Page
    {
        private readonly IBrandsServices brandsServices;

        public ManageBrands()
        {
            this.brandsServices = NinjectWebCommon.Kernel.Get<IBrandsServices>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Brand> gvBrands_GetData()
        {
            return this.brandsServices.GetAll().OrderBy(x => x.Id);
        }

        public void gvBrands_UpdateItem(int id)
        {
            var brand = new Brand();

            TryUpdateModel(brand);

            this.brandsServices.UpdateById(id, brand);
        }

        public void gvBrands_DeleteItem(int id)
        {
            this.brandsServices.DeleteById(id);
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Brand brandToInsert = new Brand();

            brandToInsert.Name = this.tbInsertName.Text;
            brandToInsert.WebSite = this.tbInsertWebSite.Text;

            this.brandsServices.Create(brandToInsert);

            this.tbInsertName.Text = "";
            this.tbInsertWebSite.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.tbInsertName.Text = "";
            this.tbInsertWebSite.Text = "";
        }
    }
}