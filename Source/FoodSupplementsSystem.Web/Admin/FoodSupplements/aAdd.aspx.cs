using FoodSupplementsSystem.Data;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodSupplementsSystem.Web.Admin.FoodSupplements
{
    public partial class aAdd : Page
    {
        protected string ErrorMessage { get; private set; }
        protected string SuccessMessage { get; private set; }

        public FoodSupplementsSystemDbContext DbContext { get; private set; }
        public UnitOfWork UnitOfWork { get; private set; }
        protected SupplementsServices SupplementsServices { get; set; }
        protected CategoriesServices CategoriesServices { get; set; }
        protected TopicsServices TopicsServices { get; set; }
        protected BrandsServices BrandsServices { get; set; }

        protected Supplement NewSupplement { get; private set; }
        protected Dictionary<string, int> Categories { get; private set; }
        protected Dictionary<string, int> Topics { get; private set; }
        protected Dictionary<string, int> Brands { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DbContext = new FoodSupplementsSystemDbContext();
            this.UnitOfWork = new UnitOfWork(this.DbContext);
            this.SupplementsServices = new SupplementsServices(this.UnitOfWork.SupplementRepository);
            this.CategoriesServices = new CategoriesServices(this.UnitOfWork.CategoryRepository);
            this.TopicsServices = new TopicsServices(this.UnitOfWork.TopicRepository);
            this.BrandsServices = new BrandsServices(this.UnitOfWork.BrandRepository);

            if (this.Page.IsPostBack)
            {
                this.GetSessionItemsToProperties();

                return;
            }

            this.SetSessionItems();

            // Elements Bindings
            this.BindPlaceHoldersMessages();
            // Binded first in edit mode
            //this.BindDropDownListCategories();
        }

        private Supplement CreateNewEmptySupplement()
        {
            //,[Name]
            //,[ImageUrl]
            //,[Ingredients]
            //,[Use]
            //,[Description]
            //,[CreationDate]
            //,[AuthorId]
            //,[CategoryId]
            //,[TopicId]
            //,[BrandId]
            Supplement newSupplement = new Supplement();
            newSupplement.Id = null;
            newSupplement.Name = string.Empty;
            newSupplement.ImageUrl = string.Empty;
            newSupplement.Ingredients = string.Empty;
            newSupplement.Use = string.Empty;
            newSupplement.Description = string.Empty;
            newSupplement.CreationDate = DateTime.Now;

            //newSupplement.AuthorId = Guid.Parse(this.User.Identity.GetUserId());
            //newSupplement.AuthorId = (this.User.Identity.GetUserId());
            newSupplement.AuthorId = null;
            newSupplement.CategoryId = -1;
            newSupplement.TopicId = -1;
            newSupplement.BrandId = -1;

            return newSupplement;
        }
        protected IEnumerable<Category> GetAllCategories()
        {
            IEnumerable<Category> categoriesToReturn = null;
            categoriesToReturn = this.CategoriesServices.GetAll();

            return categoriesToReturn;
        }
        protected IEnumerable<Topic> GetAllTopics()
        {
            IEnumerable<Topic> topicsToReturn = null;
            topicsToReturn = this.TopicsServices.GetAll();

            return topicsToReturn;
        }
        protected IEnumerable<Brand> GetAllBrands()
        {
            IEnumerable<Brand> brandsToReturn = null;
            brandsToReturn = this.BrandsServices.GetAll();

            return brandsToReturn;
        }
        protected bool ItemIsReadyToBeInserted()
        {
            if (this.NewSupplement != null)
            {
                if(this.NewSupplement.Name.Length <= 2)
                {
                    return false;
                }
                if (this.NewSupplement.CategoryId <= 0)
                {
                    return false;
                }
                if (this.NewSupplement.TopicId <= 0)
                {
                    return false;
                }
                if (this.NewSupplement.BrandId <= 0)
                {
                    return false;
                }
            }

            return true;
        }

        private void SetSessionItems()
        {
            if (this.NewSupplement == null)
            {
                Supplement supplement = this.CreateNewEmptySupplement();
                Session["NewSupplement"] = supplement;
                this.NewSupplement = supplement;
            }

            if (this.Categories == null)
            {
                List<Category> categories = this.GetAllCategories().ToList<Category>();
                Dictionary<string, int> categoriesLight = new Dictionary<string, int>();

                foreach(Category category in categories)
                {
                    categoriesLight.Add(category.Name, category.Id);
                }

                Session["Categories"] = categoriesLight;
                this.Categories = categoriesLight;
            }

            if (this.Topics == null)
            {
                List<Topic> topics = this.GetAllTopics().ToList<Topic>();
                Dictionary<string, int> topicsLight = new Dictionary<string, int>();

                foreach (Topic topic in topics)
                {
                    topicsLight.Add(topic.Name, topic.Id);
                }

                Session["Topics"] = topicsLight;
                this.Topics = topicsLight;
            }

            if (this.Brands == null)
            {
                List<Brand> brands = this.GetAllBrands().ToList<Brand>();
                Dictionary<string, int> brandsLight = new Dictionary<string, int>();

                foreach (Brand brand in brands)
                {
                    brandsLight.Add(brand.Name, brand.Id);
                }

                Session["Brands"] = brandsLight;
                this.Brands = brandsLight;
            }
        }
        private void GetSessionItemsToProperties()
        {
            Supplement supplement = (Supplement)Session["NewSupplement"];
            Dictionary<string, int> categories = (Dictionary<string, int>)Session["Categories"];
            Dictionary<string, int> topics = (Dictionary<string, int>)Session["Topics"];
            Dictionary<string, int> brands = (Dictionary<string, int>)Session["Brands"];

            if (supplement == null)
            {
                string errorMessage = string.Format("Session item Supplement is null and can not be edited further.");
                throw new ArgumentException(errorMessage);
            }
            this.NewSupplement = supplement;

            if (categories == null)
            {
                string errorMessage = string.Format("Session item Categories is null and can not be edited further.");
                throw new ArgumentException(errorMessage);
            }
            this.Categories = categories;

            if (topics == null)
            {
                string errorMessage = string.Format("Session item Topics is null and can not be edited further.");
                throw new ArgumentException(errorMessage);
            }
            this.Topics = topics;

            if (brands == null)
            {
                string errorMessage = string.Format("Session item Brands is null and can not be edited further.");
                throw new ArgumentException(errorMessage);
            }
            this.Brands = brands;
        }

        private void BindPlaceHoldersMessages()
        {
            this.PlaceHolderErrorMessage.Visible = !string.IsNullOrEmpty(this.ErrorMessage);
            this.PlaceHolderSuccessMessage.Visible = !string.IsNullOrEmpty(this.SuccessMessage);
            this.PlaceHolderErrorMessage.DataBind();
            this.PlaceHolderSuccessMessage.DataBind();
        }
        private void BindDropDownListCategories()
        {            
            DropDownList dropDownListCategories = (DropDownList)this.FormViewAddSupplement.FindControl("DropDownListCategories");
            if (dropDownListCategories == null)
            {
                string errorMessage = string.Format("DropDownList from Categoies is null and can not be edited further.");
                throw new ArgumentException(errorMessage);
            }

            foreach (var category in this.Categories)
            {
                ListItem listItem = new ListItem(category.Key, category.Value.ToString());
                dropDownListCategories.Items.Add(listItem);
            }

            if (this.NewSupplement.CategoryId > 0)
            {
                dropDownListCategories.SelectedIndex = this.NewSupplement.CategoryId;
            }    
        }
        private void BindDropDownListTopics()
        {
            DropDownList dsropDownListTopics = (DropDownList)this.FormViewAddSupplement.FindControl("DropDownListTopics");
            if (dsropDownListTopics == null)
            {
                string errorMessage = string.Format("DropDownList from Topics is null and can not be edited further.");
                throw new ArgumentException(errorMessage);
            }

            foreach (var topic in this.Topics)
            {
                ListItem listItem = new ListItem(topic.Key, topic.Value.ToString());
                dsropDownListTopics.Items.Add(listItem);
            }

            if (this.NewSupplement.TopicId > 0)
            {
                dsropDownListTopics.SelectedIndex = this.NewSupplement.TopicId;
            }
        }
        private void BindDropDownListBrands()
        {
            DropDownList dropDownListBrands = (DropDownList)this.FormViewAddSupplement.FindControl("DropDownListBrands");
            if (dropDownListBrands == null)
            {
                string errorMessage = string.Format("DropDownList from Brands is null and can not be edited further.");
                throw new ArgumentException(errorMessage);
            }

            foreach (var brand in this.Brands)
            {
                ListItem listItem = new ListItem(brand.Key, brand.Value.ToString());
                dropDownListBrands.Items.Add(listItem);
            }

            if (this.NewSupplement.BrandId > 0)
            {
                dropDownListBrands.SelectedIndex = this.NewSupplement.BrandId;
            }
        }

        protected string GetSelectedCategoryName()
        {
            string selectedCategoryName = string.Empty;

            if (this.NewSupplement.CategoryId > 0)
            {
                selectedCategoryName = this.Categories.FirstOrDefault(c => c.Value == this.NewSupplement.CategoryId).Key.ToString();
            }

            return selectedCategoryName;
        }
        protected string GetSelectedTopicName()
        {
            string selectedTopicName = string.Empty;

            if (this.NewSupplement.TopicId > 0)
            {
                selectedTopicName = this.Topics.FirstOrDefault(t => t.Value == this.NewSupplement.TopicId).Key.ToString();
            }

            return selectedTopicName;
        }
        protected string GetSelectedBrandName()
        {
            string selectedBrandName = string.Empty;

            if (this.NewSupplement.BrandId > 0)
            {
                selectedBrandName = this.Brands.FirstOrDefault(b => b.Value == this.NewSupplement.BrandId).Key.ToString();
            }

            return selectedBrandName;
        }

        
        protected void ShowErrorMessage(string message)
        {
            this.ErrorMessage = message;
            this.PlaceHolderErrorMessage.Visible = !string.IsNullOrEmpty(this.ErrorMessage);
            //this.PlaceHolderErrorMessage.DataBind();
        }
        protected void ShowSuccessMessage(string message)
        {
            this.SuccessMessage = message;
            this.PlaceHolderSuccessMessage.Visible = !string.IsNullOrEmpty(this.SuccessMessage);
            //this.PlaceHolderErrorMessage.DataBind();
        }
        protected void ButtonAcknoledgeErrorMessages_Click(object sender, EventArgs e)
        {
            this.ErrorMessage = string.Empty;
            this.PlaceHolderErrorMessage.Visible = !string.IsNullOrEmpty(this.ErrorMessage);
            // this.PlaceHolderErrorMessage.DataBind();
        }
        protected void ButtonAcknoledgeSuccessMessages_Click(object sender, EventArgs e)
        {
            this.SuccessMessage = string.Empty;
            this.PlaceHolderSuccessMessage.Visible = !string.IsNullOrEmpty(this.SuccessMessage);
            // this.PlaceHolderSuccessMessage.DataBind();
        }

        

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Supplement FormViewAddSupplement_GetItem()
        {
            this.GetSessionItemsToProperties();

            return this.NewSupplement;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void FormViewAddSupplement_UpdateItem()
        {
            //this.FormViewAddSupplement.ChangeMode(FormViewMode.Insert);

            Supplement item = this.NewSupplement;

            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.SupplementsServices.Add(item);
            }

            this.Response.Redirect("~/admin/foodsupplements/asupplements");
        }

        //public void FormViewAddSupplement_InsertItem()
        //{
        //    Supplement item = this.NewSupplement;

        //    TryUpdateModel(item);
        //    if (ModelState.IsValid)
        //    {
        //        // Save to db
        //    }
        //}



        private void PreserverMainFormState()
        {
            TextBox textBoxName = (TextBox)this.FormViewAddSupplement.FindControl("TextBoxName");
            TextBox textBoxImageUrl = (TextBox)this.FormViewAddSupplement.FindControl("TextBoxImageUrl");
            TextBox textBoxIngredients = (TextBox)this.FormViewAddSupplement.FindControl("TextBoxIngredients");
            TextBox textBoxUse = (TextBox)this.FormViewAddSupplement.FindControl("TextBoxUse");
            TextBox textBoxDescription = (TextBox)this.FormViewAddSupplement.FindControl("TextBoxDescription");
            DropDownList dropDownListCategories = (DropDownList)this.FormViewAddSupplement.FindControl("DropDownListCategories");
            DropDownList dropDownListTopics = (DropDownList)this.FormViewAddSupplement.FindControl("DropDownListTopics");
            DropDownList dropDownListBrands = (DropDownList)this.FormViewAddSupplement.FindControl("DropDownListBrands");


            bool allBoxesAreNull = (textBoxName == null) && 
                (textBoxImageUrl == null) && 
                (textBoxIngredients == null) && 
                (textBoxUse == null) && 
                (textBoxDescription == null) &&
                (dropDownListCategories == null);

            if (allBoxesAreNull)
            {
                return;
            }

            Supplement tempSupplement = (Supplement)Session["NewSupplement"];
            

            if (textBoxName != null)
            {
                tempSupplement.Name = textBoxName.Text;
            }
            if (textBoxImageUrl != null)
            {
                tempSupplement.ImageUrl = textBoxImageUrl.Text;
            }
            if (textBoxIngredients != null)
            {
                tempSupplement.Ingredients = textBoxIngredients.Text;
            }
            if (textBoxUse != null)
            {
                tempSupplement.Use = textBoxUse.Text;
            }
            if (textBoxDescription != null)
            {
                tempSupplement.Description = textBoxDescription.Text;
            }          

            if (dropDownListCategories != null)
            {
                tempSupplement.CategoryId = int.Parse(dropDownListCategories.SelectedValue);
            }
            if (dropDownListTopics != null)
            {
                tempSupplement.TopicId = int.Parse(dropDownListTopics.SelectedValue);
            }
            if (dropDownListBrands != null)
            {
                tempSupplement.BrandId = int.Parse(dropDownListBrands.SelectedValue);
            }

            Session["NewSupplement"] = tempSupplement;
        }
        protected void FormViewAddSupplement_ModeChanging(object sender, FormViewModeEventArgs e)
        {
            this.PreserverMainFormState();
        }

        
        protected void DropDownListCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PreserverMainFormState();
            this.IsReadyMessage();
            this.ToggleReadyInsertButtons();
        }
        protected void DropDownListTopics_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PreserverMainFormState();
            this.IsReadyMessage();
            this.ToggleReadyInsertButtons();
        }
        protected void DropDownListBrands_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PreserverMainFormState();
            this.IsReadyMessage();
            this.ToggleReadyInsertButtons();
        }
        protected void DropDownListCategories_DataBinding(object sender, EventArgs e)
        {
            this.BindDropDownListCategories();
        }
        protected void DropDownListTopics_DataBinding(object sender, EventArgs e)
        {
            this.BindDropDownListTopics();
        }
        protected void DropDownListBrands_DataBinding(object sender, EventArgs e)
        {
            this.BindDropDownListBrands();
        }

        protected void ButtonCheckIfReady_Click(object sender, EventArgs e)
        {
            this.PreserverMainFormState();
            this.IsReadyMessage();
            this.ToggleReadyInsertButtons();
        }

        private void ToggleReadyInsertButtons()
        {
            LinkButton linkButtonEdit = (LinkButton)this.FormViewAddSupplement.FindControl("LinkButtonEdit");
            Button buttonCheckIfReady = (Button)this.FormViewAddSupplement.FindControl("ButtonCheckIfReady");

            if (linkButtonEdit != null && buttonCheckIfReady != null) 
            {
                bool isReady = this.ItemIsReadyToBeInserted();
                linkButtonEdit.Visible = isReady;
                buttonCheckIfReady.Visible = !isReady;
            }
        }

        private void IsReadyMessage()
        {
            if (this.ItemIsReadyToBeInserted())
            {
                this.ShowSuccessMessage("Supplement item is ready to be inserted!");
            }
            else
            {
                this.ShowErrorMessage("Supplement item is not ready to be inserted yet. Please, fill out the required fields!");
            }
        }
            

    }
}