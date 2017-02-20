using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Contracts;
using FoodSupplementsSystem.Web.App_Start;
using Ninject;
using System;
using System.Linq;
using System.Web.UI;

namespace FoodSupplementsSystem.Web.Admin
{
    public partial class ManageTopics : Page
    {
        private ITopicsServices topicsServices;

        public ManageTopics()
        {
            this.topicsServices = NinjectWebCommon.Kernel.Get<ITopicsServices>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Topic> gvTopics_GetData()
        {
            return this.topicsServices.GetAll().OrderBy(x => x.Id);
        }

        public void gvTopics_UpdateItem(int id)
        {
            var topic = new Topic();

            TryUpdateModel(topic);

            this.topicsServices.UpdateById(id, topic);
        }

        public void gvTopics_DeleteItem(int id)
        {
            this.topicsServices.DeleteById(id);
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Topic topicToInsert = new Topic();

            topicToInsert.Name = this.tbInsertName.Text;
            topicToInsert.Description = this.tbInsertDescription.Text;

            this.topicsServices.Create(topicToInsert);

            this.tbInsertName.Text = "";
            this.tbInsertDescription.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.tbInsertName.Text = "";
            this.tbInsertDescription.Text = "";
        }
    }
}