using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Contracts;
using Ninject;
using System;
using System.Web.ModelBinding;
using System.Web.UI;

namespace FoodSupplementsSystem.Web.Private
{
    public partial class ViewComment : Page
    {
        [Inject]
        public ICommentsServices CommentsServices { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Comment fvCommentDetails_GetItem([QueryString]string id)
        {
            // TODO: validate id

            return this.CommentsServices.GetById(int.Parse(id));
        }
    }
}