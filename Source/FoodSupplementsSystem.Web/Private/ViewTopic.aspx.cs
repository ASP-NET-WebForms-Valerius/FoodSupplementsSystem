using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Contracts;
using Ninject;
using System;
using System.Web.ModelBinding;
using System.Web.UI;

namespace FoodSupplementsSystem.Web.Private
{
    public partial class ViewTopic : Page
    {
        [Inject]
        public ITopicsServices TopicsServices { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Topic fvDetails_GetItem([QueryString]string id)
        {
            // TODO: validate id

            return this.TopicsServices.GetById(int.Parse(id));
        }
    }
}