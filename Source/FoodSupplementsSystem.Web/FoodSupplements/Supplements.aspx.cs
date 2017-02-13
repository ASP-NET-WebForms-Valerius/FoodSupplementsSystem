using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FoodSupplementsSystem.Data;
using FoodSupplementsSystem.Services;
using FoodSupplementsSystem.Data.Models;
using System.Data.Entity.Infrastructure;

namespace FoodSupplementsSystem.Web.Supplements
{
    public partial class Supplements : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.DbContext = new FoodSupplementsSystemDbContext();
            this.UnitOfWork = new UnitOfWork(this.DbContext);
            this.SupplementsServices = new SupplementsServices(this.UnitOfWork.SupplementRepository);

            if (!Page.IsPostBack)
            {
                return;
            }
        }

        public FoodSupplementsSystemDbContext DbContext { get; private set; }

        public UnitOfWork UnitOfWork { get; private set; }

        protected SupplementsServices SupplementsServices { get; set; }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Supplement> GridViewSupplements_GetData()
        {
            IQueryable<Supplement> supplementsToReturn = null;
            supplementsToReturn = this.SupplementsServices.GetAll().AsQueryable();

            return supplementsToReturn;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewSupplements_UpdateItem(int id)
        {
            Supplement supplement = null;
            supplement = this.SupplementsServices.GetById(id);

            TryUpdateModel(supplement);
            if (ModelState.IsValid)
            {
                this.SupplementsServices.Update(supplement);
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewSupplements_DeleteItem(int id)
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
    }
}