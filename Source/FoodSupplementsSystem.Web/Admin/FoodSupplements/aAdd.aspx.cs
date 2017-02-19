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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DbContext = new FoodSupplementsSystemDbContext();
            this.UnitOfWork = new UnitOfWork(this.DbContext);
            this.SupplementsServices = new SupplementsServices(this.UnitOfWork.SupplementRepository);
            this.CategoriesServices = new CategoriesServices(this.UnitOfWork.CategoryRepository);

            this.SuccessMessage = "Succsess Succsess Succsess Succsess Succsess Succsess Succsess Succsess Succsess Succsess ";
            

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
        }

        private void GetSessionItemsToProperties()
        {
            Supplement supplement = (Supplement)Session["NewSupplement"];
            Dictionary<string, int> categories = (Dictionary<string, int>)Session["Categories"];

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

            //List<Category> categories = this.GetAllCategories().ToList<Category>();

            foreach (var category in this.Categories)
            {
                ListItem listItem = new ListItem(category.Key, category.Value.ToString());
                dropDownListCategories.Items.Add(listItem);
            }

            if (this.NewSupplement.CategoryId > 0)
            {
                dropDownListCategories.SelectedIndex = this.NewSupplement.CategoryId;
            }    
            
            //dropDownListCategories.DataBind();
        }

        protected string GetSelectedCategoryName()
        {
            string selectedCategoryName = string.Empty;

            if (this.NewSupplement.CategoryId > 0)
            {
                selectedCategoryName = this.Categories
                    .FirstOrDefault(category => category.Value == this.NewSupplement.CategoryId)
                    .Key
                    .ToString();
            }

            return selectedCategoryName;
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
            newSupplement.Name = string.Empty;
            newSupplement.ImageUrl = string.Empty;
            newSupplement.Ingredients = string.Empty;
            newSupplement.Use = string.Empty;
            newSupplement.Description = string.Empty;
            newSupplement.CreationDate = DateTime.Now;

            newSupplement.AuthorId = this.User.Identity.GetUserId();
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
            Supplement item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with was not found"));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.NewSupplement = item;
                Session["NewSupplement"] = item;
            }
        }

        public void FormViewAddSupplement_InsertItem()
        {
            Supplement item = this.NewSupplement;

            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save to db
            }
        }

        private void PreserverMainFormState()
        {
            TextBox textBoxName = (TextBox)this.FormViewAddSupplement.FindControl("TextBoxName");
            TextBox textBoxImageUrl = (TextBox)this.FormViewAddSupplement.FindControl("TextBoxImageUrl");
            TextBox textBoxIngredients = (TextBox)this.FormViewAddSupplement.FindControl("TextBoxIngredients");
            TextBox textBoxUse = (TextBox)this.FormViewAddSupplement.FindControl("TextBoxUse");
            TextBox textBoxDescription = (TextBox)this.FormViewAddSupplement.FindControl("TextBoxDescription");

            bool allBoxesAreNull = (textBoxName == null) && 
                (textBoxImageUrl == null) && 
                (textBoxIngredients == null) && 
                (textBoxUse == null) && 
                (textBoxDescription == null);

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

            

            //Supplement tempCategories = (Supplement)Session["Categories"];

            DropDownList dropDownListCategories = (DropDownList)this.FormViewAddSupplement.FindControl("DropDownListCategories");

            if (dropDownListCategories != null)
            {
                tempSupplement.CategoryId = int.Parse(dropDownListCategories.SelectedValue);
            }

            Session["NewSupplement"] = tempSupplement;
        }

        protected void FormViewAddSupplement_ModeChanging(object sender, FormViewModeEventArgs e)
        {
            this.PreserverMainFormState();
        }

        protected void Page_Unoad(object sender, EventArgs e)
        {
            this.PreserverMainFormState();
        }

        protected void DropDownListCategories_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownListTopics_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownListBrands_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownListCategories_DataBinding(object sender, EventArgs e)
        {
            this.BindDropDownListCategories();
        }
    }
}