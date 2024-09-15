﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto
{
    [XmlType("Invoice")]
    public class InvoiceXmlExportDto
    {
        [XmlElement("InvoiceNumber")]
        public int InvoiceNumber { get; set; }
        [XmlElement("InvoiceAmount")]
        public decimal InvoiceAmount { get; set; }
        [XmlElement("DueDate")]
        public string DueDate { get; set; } = null!;
        [XmlElement("Currency")]
        public string Currency { get; set; } = null!;
    }
}
