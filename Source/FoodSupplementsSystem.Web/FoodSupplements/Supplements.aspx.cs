using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

using FoodSupplementsSystem.Data;
using FoodSupplementsSystem.Services;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Models.Constants;

namespace FoodSupplementsSystem.Web.FoodSupplements
{
    public partial class Supplements : Page
    {
        private bool categoryFilterEnabled;
        private string categoryFilterName;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.DbContext == null)
            {
                this.DbContext = new FoodSupplementsSystemDbContext();
            }
            if (this.UnitOfWork == null)
            {
                this.UnitOfWork = new UnitOfWork(this.DbContext);
            }
            if (this.SupplementsServices == null)
            {
                this.SupplementsServices = new SupplementsServices(this.UnitOfWork.SupplementRepository);
            }

            this.ItemsPerPaga = 2;

            if (this.Page.IsPostBack)
            {
                return;
            }

            this.BindListViewSupplements();
            this.BindDataPagersSupplements();
        }

        public FoodSupplementsSystemDbContext DbContext { get; private set; }

        public UnitOfWork UnitOfWork { get; private set; }

        protected SupplementsServices SupplementsServices { get; set; }

        protected  IEnumerable<Supplement> AllSuppelments
        {
            get
            {
                IEnumerable<Supplement> supplementsToReturn = null;

                if (this.CategoryFilterEnabled)
                {
                    if (this.categoryFilterName == string.Empty)
                    {
                        DisableCategoryFilter();
                        throw new ArgumentNullException("Could not enable empty Category filter!");
                    }

                    supplementsToReturn = this.SupplementsServices.GetFiltered(this.categoryFilterName);
                }

                if (supplementsToReturn == null)
                {
                    supplementsToReturn = this.SupplementsServices.GetAll(); 
                }

                return supplementsToReturn;
            }
        }

        public int ItemsPerPaga { get; set; }

        protected string DetailsLink
        {
            get
            {
                string linkTo = "Details.aspx?id=" + "1";

                return linkTo;
            }
        }

        protected bool CategoryFilterEnabled
        {
            get
            {
                return this.categoryFilterEnabled;
            }
            private set
            {
                this.categoryFilterEnabled = value;
            }
        }



        private void BindListViewSupplements()
        {
            this.ListViewSupplements.DataSource = this.AllSuppelments.ToList();
            this.ListViewSupplements.DataBind();
        }

        private void BindDataPagersSupplements()
        {
            this.DataPagersSupplements.PagedControlID = this.ListViewSupplements.ID.ToString(); // "ListViewSupplements";
            this.DataPagersSupplements.DataBind();
            this.DataPagersSupplements.PageSize = this.ItemsPerPaga;
        }

        protected void ListViewSupplements_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            this.DataPagersSupplements.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            //rebind List View
            this.BindListViewSupplements();
        }

        protected void DataPagersSupplements_PreRender(object sender, EventArgs e)
        {           
            this.DataPagersSupplements.PageSize = this.ItemsPerPaga;
        }

        protected string GetDetailsUrl(int supplementid)
        {
            string urlToReturn = string.Empty;

            urlToReturn = Consts.Url.FoodSupplement.DetailsPage + supplementid;

            return urlToReturn;
        }

        protected void SetCategoryFilter(string categoryName)
        {
            string categoryFilterName = string.Empty;

            // TODO perform category name exist check
            bool categoryNameExist = true;
            if (!categoryNameExist)
            {
                throw new MissingMemberException("Category name does not exist in the categories collection!");
            }

            // TODO perform category name null or empty check
            bool categoryNameIsNullOrEmpty = false;
            if (categoryNameIsNullOrEmpty)
            {
                throw new MissingMemberException("Category name is null ot empty!");
            }

            EnableCategoryFilter();
            this.categoryFilterName = categoryName;
        }

        protected void EnableCategoryFilter()
        {
            this.CategoryFilterEnabled = true;
        }
        protected void DisableCategoryFilter()
        {
            this.CategoryFilterEnabled = false;
            this.categoryFilterName = null;
        }

        protected void LinkButtonCategory_Command(object sender, CommandEventArgs e)
        {
            var n = e.CommandArgument.ToString();
            this.SetCategoryFilter(n);

            this.BindListViewSupplements();
            this.BindDataPagersSupplements();
        }

        protected void ButtonRemoveCategoryFilter_Click(object sender, EventArgs e)
        {
            this.DisableCategoryFilter();

            this.BindListViewSupplements();
            this.BindDataPagersSupplements();
        }
    }
}