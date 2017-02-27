using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Contracts;
using FoodSupplementsSystem.Web.App_Start;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.UI;

namespace FoodSupplementsSystem.Web.Admin.FoodSupplements
{
    public partial class aSupplements : Page
    {
        public aSupplements()
        {
            this.SupplementsServices = NinjectWebCommon.Kernel.Get<ISupplementsServices>();
        }

        protected ISupplementsServices SupplementsServices { get; private set; }
        
        protected string ErrorMessage { get; private set; }
        protected string SuccessMessage { get; private set; }


        protected void Page_Load(object sender, EventArgs e)
        {

            if (this.Page.IsPostBack)
            {
                return;
            }

            // Elements Bindings
            this.BindPlaceHoldersMessages();
        }

        // ----------------------------------------------
        // Helper Functions Folowing
        //      \/
        private void BindPlaceHoldersMessages()
        {
            this.PlaceHolderErrorMessage.DataBind();
            this.PlaceHolderSuccessMessage.DataBind();
        }

        protected int GetAverageRatingValue(List<Rating> supplementrRatings)
        {
            int sum = 0;

            foreach (Rating rating in supplementrRatings.ToArray())
            {
                sum += rating.Value;
            }

            // Deviding by Zero check
            int averageValue = 0;
            // TODO Refactore magic numbers
            if (supplementrRatings.Count > 0 && supplementrRatings.Count <= 5)
            {
                averageValue = sum / supplementrRatings.Count;
            }
            else
            {
                averageValue = 0;
            }

            return averageValue;
        }

        // ----------------------------------------------
        // Events Folowing
        //      \/
        protected void ButtonAcknoledgeErrorMessages_Click(object sender, EventArgs e)
        {
            this.ErrorMessage = string.Empty;
            this.PlaceHolderErrorMessage.Visible = !string.IsNullOrEmpty(this.ErrorMessage);
        }
        protected void ButtonAcknoledgeSuccessMessages_Click(object sender, EventArgs e)
        {
            this.SuccessMessage = string.Empty;
            this.PlaceHolderSuccessMessage.Visible = !string.IsNullOrEmpty(this.SuccessMessage);
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Supplement> ListViewManageSupplements_GetData()
        {
            IQueryable<Supplement> supplementsToReturn = null;
            supplementsToReturn = this.SupplementsServices.GetAll().AsQueryable();

            return supplementsToReturn;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewManageSupplements_DeleteItem(int id)
        {
            Supplement supplementToDelete = null;
            supplementToDelete = this.SupplementsServices.GetById(id);

            TryUpdateModel(supplementToDelete);
            if (ModelState.IsValid)
            {
                try
                {
                    this.SupplementsServices.Delete(supplementToDelete);
                }
                catch (DbUpdateConcurrencyException)
                {
                    string errorMessage = string.Format("Item with id {0} no longer exists in the database.", id);
                    ModelState.AddModelError("", errorMessage);
                }
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewManageSupplements_UpdateItem(int id)
        {
            Supplement supplement = null;
            supplement = this.SupplementsServices.GetById(id);

            if (supplement == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            TryUpdateModel(supplement);
            if (ModelState.IsValid)
            {
                this.SupplementsServices.Update(supplement);
            }           
        }
    }
}