using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplementsSystem.Data.Models.Constants
{
    public static partial class Consts
    {
        public struct Brand
        {
            public struct NameMaxLength
            {
                public const int Value = 30;
                public const string ErrorMessage = "Brand name length should be less than 30 symbols.";
            }

            public struct NameMinLength
            {
                public const int Value = 2;
                public const string ErrorMessage = "Brand name length should be more than 2 symbols.";
            }
        };

        public struct Category
        {
            public struct NameMaxLength
            {
                public const int Value = 30;
                public const string ErrorMessage = "Category name length should be less than 30 symbols.";
            }

            public struct NameMinLength
            {
                public const int Value = 2;
                public const string ErrorMessage = "Category name length should be more than 2 symbols.";
            }
        };

        public struct Rating
        {
            public struct Value
            {
                public const int Min = 1;
                public const int Max = 5;
                public const string ErrorMessage = "Rating value cannot be less than 1 or more than 5 inclusive.";
            }
        };

        public struct Supplement
        {
            public struct NameMaxLength
            {
                public const int Value = 30;
                public const string ErrorMessage = "Supplement name length should be less than 30 symbols.";
            }

            public struct NameMinLength
            {
                public const int Value = 2;
                public const string ErrorMessage = "Supplement name length should be more than 2 symbols.";
            }
        };

        public struct Topic
        {
            public struct NameMaxLength
            {
                public const int Value = 30;
                public const string ErrorMessage = "Topic name length should be less than 20 symbols.";
            }

            public struct NameMinLength
            {
                public const int Value = 2;
                public const string ErrorMessage = "Topic name length should be more than 2 symbols.";
            }
        };
    }
}
