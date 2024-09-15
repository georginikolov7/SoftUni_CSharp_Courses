using Invoices.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Data
{
    public static class DataConstraints
    {
        public const byte ProductNameMinLength = 9;
        public const byte ProductNameMaxLength = 30;
        public const byte StreetNameMinLength = 10;
        public const byte StreetNameMaxLength = 20;
        public const string ProductMinPrice = "5.00";
        public const string ProductMaxPrice = "1000.00";
        public const byte CityNameMinLength = 5;
        public const byte CityNameMaxLength = 15;
        public const byte CountryNameMinLength = 5;
        public const byte CountryNameMaxLength = 15;

        public const int InvoiceNumberMinValue = 1_000_000_000;
        public const int InvoiceNumberMaxValue = 1_500_000_000;

        public const int ClientNameMinLength = 10;
        public const int ClientNameMaxLength = 25;
        public const int ClientVATMinLength = 10;
        public const int ClientVATMaxLength = 15;

        public const int InvoiceCurrencyTypeMinValue = (int)CurrencyType.BGN;
        public const int InvoiceCurrencyTypeMaxValue = (int)CurrencyType.USD;

        public const int ProductCategoryTypeMinValue = (int)CategoryType.ADR;
        public const int ProductCategoryTypeMaxValue = (int)CategoryType.Tyres;
    }
}
