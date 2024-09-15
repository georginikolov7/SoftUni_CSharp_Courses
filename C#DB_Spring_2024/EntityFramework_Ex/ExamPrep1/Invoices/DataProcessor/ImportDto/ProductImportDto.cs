using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.DataProcessor.ImportDto
{
    using static Data.DataConstraints;
    public class ProductImportDto
    {
        [Required]
        [MinLength(ProductNameMinLength)]
        [MaxLength(ProductNameMaxLength)]
        public string Name { get; set; } = null!;
        [Range(typeof(decimal), ProductMinPrice, ProductMaxPrice)]
        public decimal Price { get; set; }
        [Range(ProductCategoryTypeMinValue, ProductCategoryTypeMaxValue)]
        public int CategoryType { get; set; }
        [Required]
        public int[] Clients { get; set; } = null!;
    }
}
