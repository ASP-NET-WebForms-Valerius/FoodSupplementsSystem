using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Contracts;
using FoodSupplementsSystem.Web.App_Start;
using Ninject;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodSupplementsSystem.Web.Admin
{
    public partial class ManageCategories : Page
    {
        private readonly ICategoriesServices categoriesServices;

        public ManageCategories()
        {
            this.categoriesServices = NinjectWebCommon.Kernel.Get<ICategoriesServices>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Category> gvCategories_GetData()
        {
            return this.categoriesServices.GetAll().OrderBy(x => x.Id);
        }

        public void gvCategories_UpdateItem(int id)
        {
            var editTitleBox = this.gvCategories.Rows[this.gvCategories.EditIndex].Controls[0].Controls[0] as TextBox;

            this.categoriesServices.UpdateNameById(id, editTitleBox.Text);
        }

        public void gvCategories_DeleteItem(int id)
        {
            this.categoriesServices.DeleteId(id);
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            this.categoriesServices.Create(this.tbInsert.Text);

            this.tbInsert.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.tbInsert.Text = "";
        }
    }
}