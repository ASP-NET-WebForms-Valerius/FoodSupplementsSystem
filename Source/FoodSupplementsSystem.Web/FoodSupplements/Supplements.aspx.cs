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
using FoodSupplementsSystem.Services.Contracts;
using FoodSupplementsSystem.Web.App_Start;
using Ninject;

namespace FoodSupplementsSystem.Web.FoodSupplements
{
    public partial class Supplements : Page
    {

        public Supplements()
        {
            this.SupplementsServices = NinjectWebCommon.Kernel.Get<ISupplementsServices>();
        }

        protected ISupplementsServices SupplementsServices { get; private set; }
        protected SupplementFilters SupplementFilters { get; private set; }

        public int ItemsPerPaga { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            //this.DbContext = new FoodSupplementsSystemDbContext();
            //this.UnitOfWork = new UnitOfWork(this.DbContext);
            //this.SupplementsServices = new SupplementsServices(this.UnitOfWork.SupplementRepository);

            // TODO bind to ninject
            this.SupplementFilters = new SupplementFilters(this.SupplementsServices);

            // TODO to consts
            this.ItemsPerPaga = 2;


            if (this.Page.IsPostBack)
            {
                return;
            }

            this.BindListViewSupplements();
            this.BindDataPagersSupplements();
            this.BindDataButtonsRemoveFilters();
        }

        //public FoodSupplementsSystemDbContext DbContext { get; private set; }

        //public UnitOfWork UnitOfWork { get; private set; }



        //protected  IEnumerable<Supplement> AllSuppelments
        //{
        //    get
        //    {
        //        IEnumerable<Supplement> supplementsToReturn = null;

        //        supplementsToReturn = this.SupplementFilters.GetFilteredSupplements();

        //        return supplementsToReturn;
        //    }
        //}



        //protected string DetailsLink
        //{
        //    get
        //    {
        //        string linkTo = "Details.aspx?id=" + "1";

        //        return linkTo;
        //    }
        //}



        // ----------------------------------------------
        // Helper Functions Folowing
        //      \/
        private void BindListViewSupplements()
        {
            this.ListViewSupplements.DataSource = this.SupplementFilters.GetFilteredSupplements();
            this.ListViewSupplements.DataBind();
        }

        private void BindDataPagersSupplements()
        {
            this.DataPagersSupplements.PagedControlID = this.ListViewSupplements.ID.ToString(); // "ListViewSupplements";
            this.DataPagersSupplements.DataBind();
            this.DataPagersSupplements.PageSize = this.ItemsPerPaga;
        }

        private void BindDataButtonsRemoveFilters()
        {
            this.ButtonRemoveCategoryFilter.DataBind();
            this.ButtonRemoveTopicFilter.DataBind();
            this.ButtonRemoveBrandFilter.DataBind();
        }

        protected string GetDetailsUrl(int? supplementid)
        {
            string urlToReturn = string.Empty;

            urlToReturn = Consts.Url.FoodSupplement.DetailsPage + supplementid;

            return urlToReturn;
        }

        // ----------------------------------------------
        // Events Folowing
        //      \/
       

        protected void DataPagersSupplements_PreRender(object sender, EventArgs e)
        {           
            this.DataPagersSupplements.PageSize = this.ItemsPerPaga;
        }

        protected void ListViewSupplements_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            this.DataPagersSupplements.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindListViewSupplements();
        }

        protected void LinkButtonSetCategoryFilter_Command(object sender, CommandEventArgs e)
        {
            var name = e.CommandArgument.ToString();
            this.SupplementFilters.CategoryEnabled = true;
            this.SupplementFilters.CategoryName = name;

            this.BindListViewSupplements();
            this.BindDataPagersSupplements();
            this.ButtonRemoveCategoryFilter.DataBind();
        }
        protected void LinkButtonSetTopicFilter_Command(object sender, CommandEventArgs e)
        {
            var name = e.CommandArgument.ToString();
            this.SupplementFilters.TopicEnabled = true;
            this.SupplementFilters.TopicName = name;

            this.BindListViewSupplements();
            this.BindDataPagersSupplements();
            this.ButtonRemoveTopicFilter.DataBind();
        }
        protected void LinkButtonSetBrandFilter_Command(object sender, CommandEventArgs e)
        {
            var name = e.CommandArgument.ToString();
            this.SupplementFilters.BrandEnabled = true;
            this.SupplementFilters.BrandName = name;

            this.BindListViewSupplements();
            this.BindDataPagersSupplements();
            this.ButtonRemoveBrandFilter.DataBind();
        }

        protected void ButtonRemoveCategoryFilter_Click(object sender, EventArgs e)
        {
            this.SupplementFilters.CategoryEnabled = false;
            this.SupplementFilters.CategoryName = null;

            this.BindListViewSupplements();
            this.BindDataPagersSupplements();
            this.ButtonRemoveCategoryFilter.DataBind();
        }
        protected void ButtonRemoveTopicFilter_Click(object sender, EventArgs e)
        {
            this.SupplementFilters.TopicEnabled = false;
            this.SupplementFilters.TopicName = null;

            this.BindListViewSupplements();
            this.BindDataPagersSupplements();
            this.ButtonRemoveTopicFilter.DataBind();
        }
        protected void ButtonRemoveBrandFilter_Click(object sender, EventArgs e)
        {
            this.SupplementFilters.BrandEnabled = false;
            this.SupplementFilters.BrandName = null;

            this.BindListViewSupplements();
            this.BindDataPagersSupplements();
            this.ButtonRemoveBrandFilter.DataBind();
        }

        protected void SupplementRating_Changed(object sender, RatingEventArgs e)
        {

        }

       
    }
}