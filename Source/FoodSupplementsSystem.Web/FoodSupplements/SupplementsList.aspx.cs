using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FoodSupplementsSystem.Data;
using FoodSupplementsSystem.Services;
using FoodSupplementsSystem.Data.Models;

namespace FoodSupplementsSystem.Web.FoodSupplements
{
    public partial class SupplementsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.DbContext = new FoodSupplementsSystemDbContext();
            this.UnitOfWork = new UnitOfWork(this.DbContext);
            this.SupplementsServices = new SupplementsServices(this.UnitOfWork.SupplementRepository);

            if (this.Page.IsPostBack)
            {
                return;
            }

            this.ListViewSupplements.DataSource = this.AllSuppelments.ToList();
            this.ListViewSupplements.DataBind();
        }

        public FoodSupplementsSystemDbContext DbContext { get; private set; }

        public UnitOfWork UnitOfWork { get; private set; }

        protected SupplementsServices SupplementsServices { get; set; }

        protected  IEnumerable<Supplement> AllSuppelments
        {
            get
            {
                IEnumerable<Supplement> supplementsToReturn = null;
                supplementsToReturn = this.SupplementsServices.GetAll();

                return supplementsToReturn;
            }
        }

        protected string DetailsLink
        {
            get
            {
                string linkTo = "Details.aspx?id=" + "1";

                return linkTo;
            }
        }
        
    }
}