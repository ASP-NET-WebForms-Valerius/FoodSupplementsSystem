using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Contracts;
using Ninject;
using System;
using System.Linq;
using System.Web.UI;

namespace FoodSupplementsSystem.Web.Admin
{
    public partial class ManageTopics : Page
    {
        [Inject]
        public ITopicsServices TopicsServices { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Topic> gvTopics_GetData()
        {
            return this.TopicsServices.GetAll().OrderBy(x => x.Id);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void gvTopics_UpdateItem(int id)
        {
            var topic = new Topic();

            TryUpdateModel(topic);

            this.TopicsServices.UpdateById(id, topic);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void gvTopics_DeleteItem(int id)
        {
            this.TopicsServices.DeleteById(id);
            //this.Response.Redirect(this.Request.RawUrl);
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Topic topicToInsert = new Topic();

            topicToInsert.Name = this.tbInsertName.Text;
            topicToInsert.Description = this.tbInsertDescription.Text;

            this.TopicsServices.Create(topicToInsert);

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