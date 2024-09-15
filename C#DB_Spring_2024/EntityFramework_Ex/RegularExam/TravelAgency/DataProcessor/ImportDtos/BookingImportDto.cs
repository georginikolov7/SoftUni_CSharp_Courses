using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.DataProcessor.ImportDtos
{
    using static Data.DataConstraints;
    public class BookingImportDto
    {
        [Required]
        public string BookingDate { get; set; } = null!;
        [Required]
        [MinLength(CustomerNameMinLength)]
        [MaxLength(CustomerNameMaxLength)]
        public string CustomerName { get; set; } = null!;
        [Required]
        [MinLength(PackageNameMinLength)]
        [MaxLength(PackageNameMaxLength)]
        public string TourPackageName { get; set; } = null!;

    }
}
