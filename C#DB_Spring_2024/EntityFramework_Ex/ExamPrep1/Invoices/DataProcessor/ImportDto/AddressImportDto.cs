using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto
{
    using static Data.DataConstraints;
    [XmlType("Address")]
    public class AddressImportDto
    {
        [XmlElement("StreetName")]
        [Required]
        [MinLength(StreetNameMinLength)]
        [MaxLength(StreetNameMaxLength)]
        public string StreetName { get; set; } = null!;

        [XmlElement("StreetNumber")]
        public int StreetNumber { get; set; }

        [XmlElement("PostCode")]
        [Required]
        public string PostCode { get; set; } = null!;

        [XmlElement("City")]
        [Required]
        [MinLength(CityNameMinLength)]
        [MaxLength(CityNameMaxLength)]
        public string City { get; set; } = null!;

        [XmlElement("Country")]
        [Required]
        [MinLength(CountryNameMinLength)]
        [MaxLength(CountryNameMaxLength)]
        public string Country { get; set; } = null!;
    }
}
