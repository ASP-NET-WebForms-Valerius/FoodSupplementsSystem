using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Contracts;
using FoodSupplementsSystem.Web.App_Start;
using Ninject;
using System;
using System.Web.ModelBinding;
using System.Web.UI;

namespace FoodSupplementsSystem.Web.Private
{
    public partial class ViewComment : Page
    {
        private ICommentsServices commentsServices;

        public ViewComment()
        {
            this.commentsServices = NinjectWebCommon.Kernel.Get<ICommentsServices>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Comment fvCommentDetails_GetItem([QueryString]string id)
        {
            return this.commentsServices.GetById(int.Parse(id));
        }
    }
}