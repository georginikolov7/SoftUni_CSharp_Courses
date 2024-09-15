using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    using static Data.DataConstraints;
    [XmlType("Creator")]
    public class CreatorImportDto
    {
        [XmlElement("FirstName")]
        [Required]
        [MinLength(CreatorFirstNameMinLength)]
        [MaxLength(CreatorFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;
        [XmlElement("LastName")]
        [Required]
        [MinLength(CreatorLastNameMinLength)]
        [MaxLength(CreatorLastNameMaxLength)]
        public string LastName { get; set; } = null!;
        [XmlArray("Boardgames")]
        public BoardgameImportDto[] Boardgames { get; set; } = null!;
    }
}
