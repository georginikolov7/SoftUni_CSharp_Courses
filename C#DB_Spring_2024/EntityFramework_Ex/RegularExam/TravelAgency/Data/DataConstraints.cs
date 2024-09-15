using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Data
{
    public static class DataConstraints
    {
        //Customer:

        public const byte CustomerNameMinLength = 4;
        public const byte CustomerNameMaxLength = 60;

        public const byte CustomerEmailMinLength = 6;
        public const byte CustomerEmailMaxLength = 50;

        public const byte CustomerPhoneLength = 13;
        public const string CustomerPhoneRegex = @"\+\d{12}";


        //Guide:
        public const byte GuideNameMinLength = 4;
        public const byte GuideNameMaxLength = 60;
        public const int GuideLanguageEnumMax = 5;

        //Tour package:
        public const byte PackageNameMinLength = 2;
        public const byte PackageNameMaxLength = 40;
        public const byte TourPackageDescriptionMaxLength = 200;


        //Booking:
        public const string BookingDateTimeFormat = "yyyy-MM-dd";
    }
}
