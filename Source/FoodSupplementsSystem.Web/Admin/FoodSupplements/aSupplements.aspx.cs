using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Infrastructure;

using FoodSupplementsSystem.Data;
using FoodSupplementsSystem.Services;
using FoodSupplementsSystem.Data.Models;

namespace FoodSupplementsSystem.Web.Admin.FoodSupplements
{
    public partial class aSupplements : Page
    {

        protected string ErrorMessage { get; private set; }
        protected string SuccessMessage { get; private set; }

        public FoodSupplementsSystemDbContext DbContext { get; private set; }
        public UnitOfWork UnitOfWork { get; private set; }
        protected SupplementsServices SupplementsServices { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DbContext = new FoodSupplementsSystemDbContext();
            this.UnitOfWork = new UnitOfWork(this.DbContext);
            this.SupplementsServices = new SupplementsServices(this.UnitOfWork.SupplementRepository);

            this.SuccessMessage = "Succsess Succsess Succsess Succsess Succsess Succsess Succsess Succsess Succsess Succsess ";

            if (!Page.IsPostBack)
            {
                return;
            }

            // Elements Bindings
            this.BindPlaceHoldersMessages();
        }

        private void BindPlaceHoldersMessages()
        {
            this.PlaceHolderErrorMessage.DataBind();
            this.PlaceHolderSuccessMessage.DataBind();
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


        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewSupplements_UpdateItem(int id)
        {
            
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