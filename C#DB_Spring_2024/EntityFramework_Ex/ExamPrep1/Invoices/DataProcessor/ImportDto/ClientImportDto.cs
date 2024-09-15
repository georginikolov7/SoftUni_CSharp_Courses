using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto
{
    using static Data.DataConstraints;
    [XmlType("Client")]
    public class ClientImportDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(ClientNameMinLength)]
        [MaxLength(ClientNameMaxLength)]
        public string Name { get; set; } = null!;
        [XmlElement("NumberVat")]
        [Required]
        [MinLength(ClientVATMinLength)]
        [MaxLength(ClientVATMaxLength)]
        public string NumberVat { get; set; } = null!;
        [XmlArray("Addresses")]
        public AddressImportDto[] Addresses { get; set; } = null!;
    }
}
