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

        protected string ErrorMessage { get; private set; }
        protected string SuccessMessage { get; private set; }

        public int Id { get; private set; }

        protected IList<Supplement> Supplement { get; private set; }

        protected IList<Rating> Ratings { get; private set; }

        protected FoodSupplementsSystemDbContext DbContext { get; private set; }

        protected UnitOfWork UnitOfWork { get; private set; }

        protected SupplementsServices SupplementsServices { get; set; }


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
                this.Response.Redirect("~/foodsupplements/supplements");
            }
            this.Id = suppId;
            this.Supplement = this.GetSupplement().ToList();
            this.Ratings = this.GetSupplementRatings().ToList();

            this.PlaceHolderErrorMessage.DataBind();
            this.BindListViewSupplements();
            this.BindListBoxRateValues();            
        }


        protected RatingRepository RatingRepository { get; set; }


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
            List<int> rateValues = new List<int>(new int[]{ 1, 2, 3, 4, 5 });
            this.ListBoxRateValues.DataSource = rateValues;
            this.ListBoxRateValues.DataBind();

            this.ListBoxRateValues.SelectedValue = this.GetAverageRatingValue().ToString();
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
                //this.CheckIfLoggedIn();                
            }    
        }

        protected void MessageAuthenticatedToVote()
        {           
            // TODO implement real check
            bool userIsAuthenticated = this.User.Identity.IsAuthenticated;
            if (!userIsAuthenticated)
            {
                this.ErrorMessage = "You have to be logged in if you want to voute!";
                this.PlaceHolderErrorMessage.Visible = !string.IsNullOrEmpty(this.ErrorMessage);
                this.PlaceHolderErrorMessage.DataBind();
            }
            else
            {
                this.SuccessMessage = "You have voted successfully!";
                this.PlaceHolderSuccessMessage.Visible = !string.IsNullOrEmpty(this.SuccessMessage);
                this.PlaceHolderSuccessMessage.DataBind();
            }            
        }
        protected void ButtonAcknoledgeErrorMessages_Click(object sender, EventArgs e)
        {
            this.ErrorMessage = string.Empty;
            this.PlaceHolderErrorMessage.Visible = !string.IsNullOrEmpty(this.ErrorMessage);
            this.PlaceHolderErrorMessage.DataBind();
        }
        protected void ButtonAcknoledgeSuccessMessages_Click(object sender, EventArgs e)
        {
            this.SuccessMessage = string.Empty;
            this.PlaceHolderSuccessMessage.Visible = !string.IsNullOrEmpty(this.SuccessMessage);
            this.PlaceHolderSuccessMessage.DataBind();
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

        protected void ListBoxRateValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.MessageAuthenticatedToVote();

            if (!this.User.Identity.IsAuthenticated)
            {
                return;
            }

            bool userHasVoutedAllready = false;
            if (userHasVoutedAllready)
            {
                // Update
            }
            else
            {
                // Insert
            }

            
            // Get new Average value
            
        }


        protected IEnumerable<Rating> GetSupplementRatings()
        {
            string username = this.User.Identity.Name;

            IEnumerable<Rating> ratingsToReturn = null;

            ratingsToReturn = this.RatingRepository.ExecuteStoredProcedure("usp_GetSupplementRatingBySupplementId", this.Id).Select(s => s);

            return ratingsToReturn;
        }

        protected IEnumerable<Supplement> GetSupplement()
        {
            IList<Supplement> supplementsToReturn = new List<Supplement>();
            Supplement dbSupplement = this.SupplementsServices.GetById(this.Id);

            if (dbSupplement == null)
            {
                string errorMessage = string.Format("No supplements were found by Id {0}", this.Id);
                throw new ArgumentNullException(errorMessage);
            }
            supplementsToReturn.Add(dbSupplement);

            return supplementsToReturn;
        }

        protected int GetAverageRatingValue()
        {
            int sum = 0;

            foreach(var rating in Ratings)
            {
                sum += rating.Value;
            }

            int averageValue = sum / Ratings.Count;

            return averageValue;
        }

        
    }
}