using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplementsSystem.Data.Models.Constants
{
    public static partial class Consts
    {
        public struct Texts
        {
            public const string Any = "Any";

            public struct Exceptions
            {
                public const string CouldNotEnableEmptyCategoryFilter = "Could not enable empty Category filter!";
            }
        };
    }
}
