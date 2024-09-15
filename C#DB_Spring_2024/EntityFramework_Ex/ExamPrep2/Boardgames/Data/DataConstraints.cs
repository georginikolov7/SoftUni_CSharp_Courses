using Boardgames.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data
{
    public static class DataConstraints
    {
        //Creator:
        public const byte CreatorFirstNameMinLength = 2;
        public const byte CreatorFirstNameMaxLength = 7;

        public const byte CreatorLastNameMinLength = 2;
        public const byte CreatorLastNameMaxLength = 7;

        //Game:
        public const byte GameNameMinLength = 10;
        public const byte GameNameMaxLength = 20;

        public const double GameMinRating = 1.00;
        public const double GameMaxRating = 10.00;

        public const int GameMinYear = 2018;
        public const int GameMaxYear = 2023;

        public const int GameMaxCategory = (int)CategoryType.Strategy;
        //Seller:
        public const byte SellerNameMinLength = 5;
        public const byte SellerNameMaxLength = 20;

        public const byte SellerAddressMinLength = 2;
        public const byte SellerAddressMaxLength = 30;

        public const string WebsiteRegexPattern = @"www\.[0-9a-zA-Z-]+\.com";

    }
}
