using System;
using System.Collections.Specialized;
using System.Configuration;

namespace FoodSupplementsSystem.Data.Models.Constants
{
    public static partial class Consts
    {

        public static NameValueCollection General
        {
            get
            {
                string sectionName = "ConstantsGeneralConfig";
                NameValueCollection nvc = (NameValueCollection)ConfigurationManager.GetSection(sectionName);

                return nvc; 
            }
        }

        // First General Group
        public static string MyCustomConst
        {
            get
            {
                return General.Get("MyCustomConst");
            }
        }

        public static string AnySecondFromTheConfig
        {
            get
            {
                return General.Get("Any");
            }
        }

        public static int ItemsPerPage {
            get
            {
                int itemsPerPage;
                bool isErrorByParsing = int.TryParse(General["ItemsPerPage"], out itemsPerPage);
                if (!isErrorByParsing)
                {
                    string errorMessage = "Items Per Page value in not in the expected format int";
                    throw new FormatException(errorMessage);
                }

                return itemsPerPage;
            }
        }
    }
}
