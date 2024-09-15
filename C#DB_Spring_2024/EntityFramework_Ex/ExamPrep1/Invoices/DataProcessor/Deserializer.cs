namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using System.Xml;
    using Invoices.Data;
    using Invoices.Utilities;
    using Invoices.Data.Models;
    using Invoices.DataProcessor.ImportDto;
    using System.Runtime.CompilerServices;
    using Newtonsoft.Json;
    using Invoices.Data.Models.Enums;
    using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {

            StringBuilder sb = new();
            const string XmlRoot = "Clients";
            XmlHelper xmlHelper = new();
            var deserializedDtos = xmlHelper.Deserialize<ClientImportDto[]>(xmlString, XmlRoot);

            ICollection<Client> clientsToImport = new HashSet<Client>();

            foreach (var dto in deserializedDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                ICollection<Address> addressesToImport = new List<Address>();
                foreach (var addressDto in dto.Addresses)
                {
                    if (!IsValid(addressDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Address address = new Address()
                    {
                        StreetName = addressDto.StreetName,
                        StreetNumber = addressDto.StreetNumber,
                        PostCode = addressDto.PostCode,
                        City = addressDto.City,
                        Country = addressDto.Country,
                    };
                    addressesToImport.Add(address);
                }
                Client client = new Client()
                {
                    Name = dto.Name,
                    NumberVat = dto.NumberVat,
                    Addresses = addressesToImport
                };

                clientsToImport.Add(client);
                sb.AppendLine(String.Format(SuccessfullyImportedClients, dto.Name));

            }
            context.Clients.AddRange(clientsToImport);
            context.SaveChanges();

            return sb.ToString().Trim();
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ICollection<Invoice> invoicesToImport = new List<Invoice>();
            var deserializedDtos = JsonConvert.DeserializeObject<InvoiceImportDto[]>(jsonString)!;

            List<int> validClientIds = context.Clients.Select(c => c.Id).ToList();

            foreach (var dto in deserializedDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                //Date validations:
                bool isIssueDateValid = DateTime.TryParse(dto.IssueDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime issueDate);

                bool isDueDateValid = DateTime.TryParse(dto.DueDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDate);

                if (!isIssueDateValid || !isDueDateValid || dueDate < issueDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!validClientIds.Any(i => i == dto.ClientId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Invoice invoice = new Invoice()
                {
                    Number = dto.Number,
                    IssueDate = issueDate,
                    DueDate = dueDate,
                    Amount = dto.Amount,
                    CurrencyType = (CurrencyType)dto.CurrencyType,
                    ClientId = dto.ClientId,
                };

                invoicesToImport.Add(invoice);

                sb.AppendLine(String.Format(SuccessfullyImportedInvoices, dto.Number));
            }

            context.Invoices.AddRange(invoicesToImport);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            StringBuilder sb = new();
            ICollection<Product> productsToImport = new List<Product>();
            var deserializedDtos = JsonConvert.DeserializeObject<ProductImportDto[]>(jsonString);

            int[] validClientIds = context.Clients.Select(c => c.Id).ToArray();
            foreach (var dto in deserializedDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newProduct = new Product()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    CategoryType = (CategoryType)dto.CategoryType
                };

                ICollection<ProductClient> productsClientsToImport = new List<ProductClient>();
                foreach (var clientId in dto.Clients.Distinct())
                {
                    if (!validClientIds.Any(id => id == clientId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    productsClientsToImport.Add(new ProductClient()
                    {
                        Product = newProduct,
                        ClientId = clientId
                    });

                }
                newProduct.ProductsClients = productsClientsToImport;
                productsToImport.Add(newProduct);
                sb.AppendLine(String.Format(SuccessfullyImportedProducts, dto.Name, productsClientsToImport.Count));
            }

            context.Products.AddRange(productsToImport);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
