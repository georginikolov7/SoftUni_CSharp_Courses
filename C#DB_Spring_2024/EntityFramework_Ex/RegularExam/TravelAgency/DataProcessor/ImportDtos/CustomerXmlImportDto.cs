using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TravelAgency.DataProcessor.ImportDtos
{
    using static Data.DataConstraints;
    [XmlType("Customer")]
    public class CustomerXmlImportDto
    {
        [XmlAttribute("phoneNumber")]
        [MinLength(CustomerPhoneLength)]
        [MaxLength(CustomerPhoneLength)]
        [RegularExpression(CustomerPhoneRegex)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [MinLength(CustomerNameMinLength)]
        [MaxLength(CustomerNameMaxLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [MinLength(CustomerEmailMinLength)]
        [MaxLength(CustomerEmailMaxLength)]
        public string Email { get; set; } = null!;
    }
}
