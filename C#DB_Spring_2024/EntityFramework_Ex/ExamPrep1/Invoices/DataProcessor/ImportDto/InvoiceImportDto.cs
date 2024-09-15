using Invoices.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.DataProcessor.ImportDto
{
    using static Data.DataConstraints;
    public class InvoiceImportDto
    {
        [Required]
        [Range(InvoiceNumberMinValue, InvoiceNumberMaxValue)]
        public int Number { get; set; }
        [Required]
        public string IssueDate { get; set; } = null!;
        [Required]
        public string DueDate { get; set; } = null!;
        public decimal Amount { get; set; }
        [Range(InvoiceCurrencyTypeMinValue,InvoiceCurrencyTypeMaxValue)]
        public int CurrencyType { get; set; }
        public int ClientId { get; set; }
    }
}
