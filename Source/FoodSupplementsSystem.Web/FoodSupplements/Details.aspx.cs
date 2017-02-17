using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FoodSupplementsSystem.Data;
using FoodSupplementsSystem.Services;
using FoodSupplementsSystem.Data.Models;
using System.Threading;
using FoodSupplementsSystem.Data.Repositories;

namespace FoodSupplementsSystem.Web.FoodSupplements
{
    public partial class Details : Page
    {
        // private field added for the workaround with AjaxToolkitBug
        // https://bytes.com/topic/net/answers/737309-event-getting-called-2-times-indside-update-panel
        private bool isFired = false;

        protected string ErrorMessage
        {
            get;
            private set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (this.Page.IsPostBack)
            {
                return;
            }

            this.DbContext = new FoodSupplementsSystemDbContext();
            this.UnitOfWork = new UnitOfWork(this.DbContext);
            this.SupplementsServices = new SupplementsServices(this.UnitOfWork.SupplementRepository);
            this.RatingRepository = new RatingRepository(this.DbContext);

            int suppId = -1;
            if (!int.TryParse(this.Request.Params["id"], out suppId))
            {
                this.Response.Redirect("~/supplements");
            }
            this.Id = suppId;

            this.PlaceHolderErrorMessage.DataBind();
            this.BindListViewSupplements();
            //this.BindListBoxRateValues();

            this.GetRating();
        }

        public FoodSupplementsSystemDbContext DbContext { get; private set; }

        public UnitOfWork UnitOfWork { get; private set; }

        protected SupplementsServices SupplementsServices { get; set; }

        //protected RatingService RatingService { get; set; }

        protected RatingRepository RatingRepository { get; set; }

        public int Id { get; private set; }

        //protected Rating Rating { get; private set; }

        protected IList<Supplement> Supplement
        {
            get
            {
                IList<Supplement> supplementsToReturn= new List<Supplement>();
                supplementsToReturn.Add(this.SupplementsServices.GetById(this.Id));

                return supplementsToReturn;
            }
        }

        protected void ButtonGoBack_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("supplements.aspx");
        }

        private void BindListViewSupplements()
        {
            this.ListViewSupplementDetails.DataSource = this.Supplement;
            this.ListViewSupplementDetails.DataBind();
        }

        private void BindListBoxRateValues()
        {
            List<int> rateValues = new List<int>(new int[]{ 1, 2, 3, 4, 5 }) ;
            this.ListBoxRateValues.DataSource = rateValues;
            this.ListBoxRateValues.DataBind();
        }

        protected void SupplementRating_Changed(object sender, AjaxControlToolkit.RatingEventArgs e)
        {
            // Needed for the workaround with AjaxToolkit bug 
            if (this.isFired)
            {
                return;
            }
            else
            {
                isFired = true;
                this.CheckIfLoggedIn();                
            }    
        }

        protected void CheckIfLoggedIn()
        {           
            // TODO implement real check
            bool userIsLoggedIn = false;
            if (!userIsLoggedIn)
            {
                this.ErrorMessage = "You have to be logged in if you want to voute!";

                // Form.Action = ResolveUrl("~/details?id=" + this.Id);
                this.PlaceHolderErrorMessage.Visible = !string.IsNullOrEmpty(this.ErrorMessage);
                this.PlaceHolderErrorMessage.DataBind();

                return;
            }

            //this.ErrorMessage = string.Empty;
        }

        private bool UserHasVoutedAllready()
        {
            bool userHasVoutedAllready = false;
            if (userHasVoutedAllready)
            {
                return true;
            }

            return false; ;
        }

        protected void ListBoxRateValues_DataBinding(object sender, EventArgs e)
        {
            string vav = string.Empty;
            if (this.ViewState["Country"] != null)
            {
                vav = ViewState["VotesAverageValue"].ToString();
                this.ListBoxRateValues.SelectedIndex = int.Parse(vav);

                return;
            }

            this.ListBoxRateValues.SelectedIndex = 1;
        }

        protected void ListBoxRateValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CheckIfLoggedIn();

            var newValue = this.ListBoxRateValues.SelectedValue;

            //if (this.UserHasVoutedAllready())
            //{
            //    // Update
            //}
            //else
            //{
            //    // Insert
            //}
        }

        protected void LabelVotesAverageValueHelper_DataBinding(object sender, EventArgs e)
        {
            string vav = string.Empty;
            if (this.ViewState["VotesAverageValue"] != null)
            {
                vav = ViewState["VotesAverageValue"].ToString();
                this.ListBoxRateValues.SelectedIndex = int.Parse(vav);

                return;
            }

            this.ListBoxRateValues.SelectedIndex = 1;
        }

        protected void LabelVotesAverageValueHelper_Load(object sender, EventArgs e)
        {
            string vav = string.Empty;
            if (this.ViewState["VotesAverageValue"] != null)
            {
                vav = ViewState["VotesAverageValue"].ToString();
                this.ListBoxRateValues.SelectedIndex = int.Parse(vav);

                return;
            }

            this.ListBoxRateValues.SelectedIndex = 1;
        }

        protected void GetRating()
        {
            string username = this.User.Identity.Name;

            IEnumerable<Rating> ratingToReturn = null;

            var ratingTest = this.RatingRepository.ExecuteStoredProcedure("[dbo].[usp_GetSupplementRatingBySupplementId]", this.Id).Select(s => s);
        }
    }
}