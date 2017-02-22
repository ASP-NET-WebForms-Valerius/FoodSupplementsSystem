using FoodSupplementsSystem.Data.Models.Constants;
using FoodSupplementsSystem.Services.Contracts;
using FoodSupplementsSystem.Web.App_Start;
using Ninject;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodSupplementsSystem.Web.FoodSupplements
{
    public partial class Supplements : Page
    {

        public Supplements()
        {
            this.SupplementsServices = NinjectWebCommon.Kernel.Get<ISupplementsServices>();
            this.SupplementFilters = NinjectWebCommon.Kernel.Get<ISupplementFilters>();
        }

        protected ISupplementsServices SupplementsServices { get; private set; }
        protected ISupplementFilters SupplementFilters { get; private set; }

        public int ItemsPerPaga { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ItemsPerPaga = Consts.ItemsPerPage;

            if (this.Page.IsPostBack)
            {
                this.GetSessionItemToThis();

                return;
            }

            this.SetSessionItemsFromThis();
            this.BindListViewSupplements();
            this.BindDataPagersSupplements();
            this.BindDataButtonsRemoveFilters();
        }

        private bool SessionAndThisSupplementAreSame(ISupplementFiltersProperties sessoinSupplementFilters, ISupplementFilters thisSupplementFilters)
        {
            if (sessoinSupplementFilters.CategoryEnabled != thisSupplementFilters.CategoryEnabled)
            {
                return false;
            }
            if (sessoinSupplementFilters.TopicEnabled != thisSupplementFilters.TopicEnabled)
            {
                return false;
            }
            if (sessoinSupplementFilters.BrandEnabled != thisSupplementFilters.BrandEnabled)
            {
                return false;
            }
            if (!sessoinSupplementFilters.CategoryName.Equals(thisSupplementFilters.CategoryName))
            {
                return false;
            }
            if (!sessoinSupplementFilters.TopicName.Equals(thisSupplementFilters.TopicName))
            {
                return false;
            }
            if (!sessoinSupplementFilters.BrandName.Equals(thisSupplementFilters.BrandName))
            {
                return false;
            }

            return true;
        }

        protected ISupplementFiltersProperties SupplementFiltersPropertiesTransferToSessionElement(ISupplementFilters fromThisSupplement)
        {
            ISupplementFiltersProperties sessionElement = new SessionSupplementFilters();

            sessionElement.BrandEnabled = fromThisSupplement.BrandEnabled;
            sessionElement.BrandName = fromThisSupplement.BrandName;

            sessionElement.CategoryEnabled = fromThisSupplement.CategoryEnabled;
            sessionElement.CategoryName = fromThisSupplement.CategoryName;

            sessionElement.TopicEnabled = fromThisSupplement.TopicEnabled;
            sessionElement.TopicName = fromThisSupplement.TopicName;

            return sessionElement;
        }
        protected void SupplementFiltersPropertiesTransferToThisElement(ISupplementFiltersProperties fromSessionElement)
        {
            this.SupplementFilters.BrandEnabled = fromSessionElement.BrandEnabled;
            this.SupplementFilters.BrandName = fromSessionElement.BrandName;

            this.SupplementFilters.CategoryEnabled = fromSessionElement.CategoryEnabled;
            this.SupplementFilters.CategoryName = fromSessionElement.CategoryName;

            this.SupplementFilters.TopicEnabled = fromSessionElement.TopicEnabled;
            this.SupplementFilters.TopicName = fromSessionElement.TopicName;

        }
        
        private void GetSessionItemToThis()
        {
            ISupplementFiltersProperties sessionSupplementFilters = (SessionSupplementFilters)this.Session["SupplementFilters"];
            if (sessionSupplementFilters == null)
            {
                string errorMessage = string.Format("Session item Supplement is null and can not be edited further.");
                throw new ArgumentException(errorMessage);
            }

            this.SupplementFiltersPropertiesTransferToThisElement(sessionSupplementFilters);
        }
        private void SetSessionItemsFromThis()
        {
            if (this.SupplementFilters == null)
            {
                string errorMessage = string.Format("SupplementFilters item is null and can not be edited further.");
                throw new ArgumentException(errorMessage);
            }

            ISupplementFiltersProperties sessionSupplementFilters = this.SupplementFiltersPropertiesTransferToSessionElement(this.SupplementFilters);

            Session["SupplementFilters"] = sessionSupplementFilters;
        }

        //private void UpdateSessionSupplemetFilters()
        //{
        //    ISupplementFiltersProperties sessionSupplementFilters = (SessionSupplementFilters)this.Session["SupplementFilters"];
        //    if (sessionSupplementFilters == null)
        //    {
        //        sessionSupplementFilters = new SessionSupplementFilters();
        //        //sessionSupplementFilters = this.SupplementFiltersTransferProperties(this.SupplementFilters, sessionSupplementFilters);
        //        Session["SupplementFilters"] = sessionSupplementFilters;
        //    }
        //    else if (sessionSupplementFilters != null && this.SupplementFilters != null)
        //    {
        //        if (!this.SessionAndThisSupplementAreSame(sessionSupplementFilters, this.SupplementFilters))
        //        {
        //            sessionSupplementFilters = this.SupplementFiltersTransferProperties(this.SupplementFilters, sessionSupplementFilters);
        //            Session["SupplementFilters"] = sessionSupplementFilters;
        //        }
        //    }
        //    else
        //    {
        //        this.SupplementFilters = this.SupplementFiltersTransferProperties(sessionSupplementFilters, this.SupplementFilters);
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
            this.PlaceHolderRemoveCategoryFilterButtons.DataBind();
            this.PlaceHolderRemoveTopicFilterButtons.DataBind();
            this.PlaceHolderRemoveBrandFilterButtons.DataBind();
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

            this.SetSessionItemsFromThis();

            this.BindListViewSupplements();
            this.BindDataPagersSupplements();
            this.PlaceHolderRemoveCategoryFilterButtons.DataBind();
            this.ButtonRemoveCategoryFilter.DataBind();
        }
        protected void LinkButtonSetTopicFilter_Command(object sender, CommandEventArgs e)
        {
            var name = e.CommandArgument.ToString();
            this.SupplementFilters.TopicEnabled = true;
            this.SupplementFilters.TopicName = name;

            this.SetSessionItemsFromThis();
            
            this.BindListViewSupplements();
            this.BindDataPagersSupplements();
            this.PlaceHolderRemoveTopicFilterButtons.DataBind();
            this.ButtonRemoveTopicFilter.DataBind();
        }
        protected void LinkButtonSetBrandFilter_Command(object sender, CommandEventArgs e)
        {
            var name = e.CommandArgument.ToString();
            this.SupplementFilters.BrandEnabled = true;
            this.SupplementFilters.BrandName = name;

            this.SetSessionItemsFromThis();

            this.BindListViewSupplements();
            this.BindDataPagersSupplements();
            this.PlaceHolderRemoveBrandFilterButtons.DataBind();
            this.ButtonRemoveBrandFilter.DataBind();
        }

        protected void ButtonRemoveCategoryFilter_Click(object sender, EventArgs e)
        {
            this.SupplementFilters.CategoryEnabled = false;
            this.SupplementFilters.CategoryName = string.Empty;

            this.SetSessionItemsFromThis();
            
            this.BindListViewSupplements();
            this.BindDataPagersSupplements();
            this.PlaceHolderRemoveCategoryFilterButtons.DataBind();
            this.ButtonRemoveCategoryFilter.DataBind();
        }
        protected void ButtonRemoveTopicFilter_Click(object sender, EventArgs e)
        {
            this.SupplementFilters.TopicEnabled = false;
            this.SupplementFilters.TopicName = string.Empty;

            this.SetSessionItemsFromThis();

            this.BindListViewSupplements();
            this.BindDataPagersSupplements();
            this.PlaceHolderRemoveTopicFilterButtons.DataBind();
            this.ButtonRemoveTopicFilter.DataBind();
        }
        protected void ButtonRemoveBrandFilter_Click(object sender, EventArgs e)
        {
            this.SupplementFilters.BrandEnabled = false;
            this.SupplementFilters.BrandName = string.Empty;

            this.SetSessionItemsFromThis();

            this.BindListViewSupplements();
            this.BindDataPagersSupplements();
            this.PlaceHolderRemoveBrandFilterButtons.DataBind();
            this.ButtonRemoveBrandFilter.DataBind();
        }
    }
}