using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplementsSystem.Data.Models.Constants
{
    public static partial class Consts
    {
        public static NameValueCollection General
        {
            get
            {
                return (NameValueCollection)ConfigurationManager.GetSection("ConstantsGeneralConfig");
            }
        }

        // First General Group
        public static string MyCustomConst { get { return General.Get("MyCustomConst"); } }
    }
}
