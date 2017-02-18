using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using AjaxControlToolkit;

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

        protected RatingRepository RatingRepository { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            this.DbContext = new FoodSupplementsSystemDbContext();
            this.UnitOfWork = new UnitOfWork(this.DbContext);
            this.SupplementsServices = new SupplementsServices(this.UnitOfWork.SupplementRepository);
            this.RatingRepository = this.UnitOfWork.RatingRepository;

            int suppId = -1;
            if (!int.TryParse(this.Request.Params["id"], out suppId))
            {
                this.Response.Redirect("~/foodsupplements/supplements");
            }
            this.Id = suppId;
            this.Supplement = this.GetSupplement().ToList();
            this.Ratings = this.GetSupplementRatings(this.Id).ToList();

            if (this.Page.IsPostBack)
            {
                return;
            }

            // Elements Bindings
            this.PlaceHolderErrorMessage.DataBind();
            this.BindListViewSupplements();
            this.BindDropDownListRateValues();         
        }


        

        private void BindListViewSupplements()
        {
            this.ListViewSupplementDetails.DataSource = this.Supplement;
            this.ListViewSupplementDetails.DataBind();
        }
        private void BindDropDownListRateValues()
        {
            int value = this.GetCurrentUserVoteValue();
            if (value >= 1 || value <= 5)
            {
                this.DropDownListRateValues.SelectedValue = value.ToString();
            }            
            this.DropDownListRateValues.DataBind();
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
        protected void ButtonGoBack_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("supplements.aspx");
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

        protected IEnumerable<Rating> GetSupplementRatings(int supplementId)
        {           
            IQueryable<Rating> ratingsToReturn = null;

            //EXEC @RC = [dbo].[usp_GetSupplementRatingBySupplementId]
            //  @SupplementId
            //GO
            ratingsToReturn = this.RatingRepository.ExecuteStoredProcedure("usp_GetSupplementRatingBySupplementId", supplementId).Select(s => s);

            return ratingsToReturn.AsEnumerable<Rating>();
        }

        protected IEnumerable<Rating> GetUserRating(string username, int itemId)
        {
            IQueryable<Rating> userRating = null;

            //EXECUTE @RC = [dbo].[usp_GetRatingByUsernameAndSupplementId]
            //   @Username
            //  ,@SupplementId
            //GO
            userRating = this.RatingRepository.ExecuteStoredProcedure("usp_GetRatingByUsernameAndSupplementId", username, itemId).Select(s => s);

            return userRating.AsEnumerable<Rating>();
        }

        protected int GetAverageRatingValue()
        {
            int sum = 0;

            foreach(Rating rating in this.Ratings.ToArray())
            {
                sum += rating.Value;
            }

            int averageValue = sum / Ratings.Count;

            return averageValue;
        }

        protected void DropDownListRateValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.MessageAuthenticatedToVote();

            if (!this.User.Identity.IsAuthenticated)
            {
                return;
            }

            // string currentUsername = this.User.Identity.Name;
            bool userHasVoutedAllready = false;
            var uR = this.GetUserRating(this.User.Identity.Name, this.Id);
            if (uR != null)
            {
                userHasVoutedAllready = true;
            }

            if (userHasVoutedAllready)
            {
                // Update
                Rating userRatingToUpdate = uR.ToList<Rating>().FirstOrDefault(r => r.SupplementId == this.Id);
                userRatingToUpdate.Value = int.Parse(this.DropDownListRateValues.SelectedValue);

                this.RatingRepository.Update(userRatingToUpdate);
                this.RatingRepository.SaveChanges();
                this.Ratings = this.GetSupplementRatings(this.Id).ToList();
            }
            else
            {
                // Insert
            }
            

            //if (nameTextBox != null)
            //{
            //    /* Do your stuff */
            //}
            // Source:
            // http://stackoverflow.com/questions/1126517/why-cant-i-reference-a-textbox-by-id-when-its-in-a-createuserwizard-control
            // https://msdn.microsoft.com/en-us/library/ms178342.aspx
            //ContentPlaceHolder cph = (ContentPlaceHolder)this.Master.FindControl("MainContent");
            //var label = (Label)cph.FindControl("Label1");

            //var lvsd = this.ListViewSupplementDetails;
            //Label labelVotesAverageValue = (Label)lvsd.Items[0].FindControl("LabelVotesAverageValue");
            //Label labelTotalVotes = (Label)lvsd.Items[0].FindControl("LabelTotalVotes") as Label;
            //AjaxControlToolkit.Rating supplementRating = (AjaxControlToolkit.Rating)lvsd.Items[0].FindControl("SupplementRating");

            Label labelVotesAverageValue = (Label)this.ListViewSupplementDetails.Items[0].FindControl("LabelVotesAverageValue");
            Label labelTotalVotes = (Label)this.ListViewSupplementDetails.Items[0].FindControl("LabelTotalVotes") as Label;
            Label labelYourVote = (Label)this.ListViewSupplementDetails.Items[0].FindControl("LabelYourVote") as Label;
            AjaxControlToolkit.Rating supplementRating = (AjaxControlToolkit.Rating)this.ListViewSupplementDetails.Items[0].FindControl("SupplementRating");

            // Update controls
            string avg = this.GetAverageRatingValue().ToString();
            string userVote = this.GetCurrentUserVoteValue().ToString();

            this.DropDownListRateValues.SelectedValue = avg;

            if (labelVotesAverageValue != null)
            {
                labelVotesAverageValue.Text = avg;
            }
            if (labelTotalVotes != null)
            {
                labelTotalVotes.Text = this.Ratings.Count.ToString();
            }
            if (labelYourVote != null)
            {
                labelYourVote.Text = userVote;
                labelYourVote.Visible = (labelYourVote.Text != null);
            }
            if (supplementRating != null)
            {
                supplementRating.CurrentRating = int.Parse(avg);
            }

        }

        protected bool CurrentUserHasVouted()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return false;
            }

            var uR = this.GetUserRating(this.User.Identity.Name, this.Id);
            if (uR == null)
            {
                return false;
            }

            return true;
        }

        protected int GetCurrentUserVoteValue()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return -1;
            }

            IEnumerable<Rating> userRating = this.GetUserRating(this.User.Identity.Name, this.Id);

            if (userRating == null || userRating.Count() <= 0)
            {
                return -1;
            }

            int yourVote = userRating.ToList<Rating>().FirstOrDefault(r => r.SupplementId == this.Id).Value;

            return yourVote;
        }

    }
}