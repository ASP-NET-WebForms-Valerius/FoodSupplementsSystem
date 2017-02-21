using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Models.Constants;
using FoodSupplementsSystem.Services;
using FoodSupplementsSystem.Services.Contracts;

namespace FoodSupplementsSystem.Web.FoodSupplements
{
    public class SupplementFilters : ISupplementFilters
    {
        //private bool anyEnabled;
        //private bool categoryEnabled;
        //private bool topicEnabled;
        //private bool brandEnabled;

        //private bool categoryReadyToUse;
        //private bool topicReadyToUse;
        //private bool brandReadyToUse;

        //private string categoryName;
        //private string topicName;
        //private string brandName;

        // TODO Refactore the whole class to one and use instances for 
        // Supplement Category
        // Topic Category
        // Brand Category
        // And whatever other neaded
        private readonly ISupplementsServices supplementsServices;

        public SupplementFilters(ISupplementsServices supplementsServices)
        {
            this.supplementsServices = supplementsServices;                           
        }

        public ISupplementsServices SupplementsServices
        {
            get
            {
                return this.supplementsServices;
            }
        }
        
        // Enabled filters
        public bool CategoryEnabled { get; set; }

        public bool TopicEnabled { get; set; }

        public bool BrandEnabled { get; set; }

        public bool AnyEnabled
        {
            get
            {
                bool anyEnabled = (this.CategoryEnabled || this.BrandEnabled || this.TopicEnabled);

                return anyEnabled;
            }
        }
        

        // Filter Words
        public string CategoryName { get; set; }

        public string TopicName { get; set; }

        public string BrandName { get; set; }


        // Ready To Use filters
        private bool CategoryReadyToUse()
        {
            bool readyToUse = false;

            // TODO if category name exists in the database == can be a filter parameter
            bool keyWordExistsAndNotNull = true && !(string.IsNullOrEmpty(this.CategoryName));
            if (keyWordExistsAndNotNull && this.CategoryEnabled)
            {
                readyToUse = true;
            }
            else
            {
                this.CategoryEnabled = false;
                readyToUse = false;
            }

            return readyToUse;           
        }

        private bool TopicReadyToUse()
        {
            bool readyToUse = false;

            // TODO if category name exists in the database == can be a filter parameter
            bool keyWordExistsAndNotNull = true && !(string.IsNullOrEmpty(this.TopicName));
            if (keyWordExistsAndNotNull && this.TopicEnabled)
            {
                readyToUse = true;
            }
            else
            {
                readyToUse = false;
                this.TopicEnabled = false;
            }

            return readyToUse;
        }

        private bool BrandReadyToUse()
        {
            bool readyToUse = false;

            bool keyWordExistsAndNotNull = true && !(string.IsNullOrEmpty(this.BrandName));
            if (keyWordExistsAndNotNull && this.BrandEnabled)
            {
                readyToUse = true;
            }
            else
            {
                readyToUse = false;
                this.BrandEnabled = false;
            }

            return readyToUse;
        }
        

        public IEnumerable<Supplement> GetFilteredSupplements()
        {
            List<Supplement> supplementsToReturn = null;

            if (!this.AnyEnabled)
            {
                supplementsToReturn = this.SupplementsServices.GetAll().ToList();

                return supplementsToReturn;
            }

            
            if (this.TopicEnabled && this.TopicReadyToUse())
            {
                if (supplementsToReturn == null)
                {
                    supplementsToReturn = this.SupplementsServices.GetFilteredByTopic(this.TopicName).ToList();
                }
                else
                {
                    var suppsF = this.SupplementsServices.GetFilteredByTopic(this.TopicName).ToList();
                    supplementsToReturn.AddRange(suppsF);
                }
            }
            if (this.CategoryEnabled && this.CategoryReadyToUse())
            {

                if (supplementsToReturn == null)
                {
                    supplementsToReturn = this.SupplementsServices.GetFilteredByCategory(this.CategoryName).ToList();
                }
                else
                {
                    var suppsF = this.SupplementsServices.GetFilteredByCategory(this.CategoryName).ToList();
                    supplementsToReturn.AddRange(suppsF);
                }
            }
            if (this.BrandEnabled && this.BrandReadyToUse())
            {
                if (supplementsToReturn == null)
                {
                    supplementsToReturn = this.SupplementsServices.GetFilteredByBrand(this.BrandName).ToList();
                }
                else
                {
                    var suppsF = this.SupplementsServices.GetFilteredByBrand(this.BrandName).ToList();
                    supplementsToReturn.AddRange(suppsF);
                }
            }

            return supplementsToReturn;
        }
    }
}