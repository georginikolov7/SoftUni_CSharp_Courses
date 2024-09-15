using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    using static Data.DataConstraints;
    [XmlType("Boardgame")]
    public class BoardgameImportDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(GameNameMinLength)]
        [MaxLength(GameNameMaxLength)]
        public string Name { get; set; } = null!;

        [XmlElement("Rating")]

        [Range(GameMinRating, GameMaxRating)]
        public double Rating { get; set; }
        [XmlElement("YearPublished")]
        [Range(GameMinYear,GameMaxYear)]
        public int YearPublished { get; set; }
        [XmlElement("CategoryType")]
        [Range(0,GameMaxCategory)]
        public int CategoryType { get; set; }
        [XmlElement("Mechanics")]
        [Required]
        public string Mechanics { get; set; } = null!;
    }
}
