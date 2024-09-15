using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;
using TravelAgency.Utilities;

namespace TravelAgency.DataProcessor
{
    using static Data.DataConstraints;
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            const string RootName = "Customers";
            StringBuilder sb = new();

            XmlHelper xmlHelper = new XmlHelper();

            CustomerXmlImportDto[] dtos = xmlHelper.Deserialize<CustomerXmlImportDto[]>(xmlString, RootName);

            List<Customer> customersToImport = new();
            var existingCustomersInDb = context
                .Customers
                .Select(c => new
                {
                    c.FullName,
                    c.Email,
                    c.PhoneNumber
                })
                .ToList();


            foreach (CustomerXmlImportDto dto in dtos)
            {


                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (existingCustomersInDb
                    .Any(c =>
                      c.FullName == dto.FullName
                   || c.PhoneNumber == dto.PhoneNumber
                   || c.Email == dto.Email))
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }
                if (customersToImport
                   .Any(c =>
                     c.FullName == dto.FullName
                  || c.PhoneNumber == dto.PhoneNumber
                  || c.Email == dto.Email))
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }


                Customer customer = new()
                {
                    FullName = dto.FullName,
                    Email = dto.Email,
                    PhoneNumber = dto.PhoneNumber,
                };
                customersToImport.Add(customer);
                sb.AppendLine(string.Format(SuccessfullyImportedCustomer, dto.FullName));
            }

            context.Customers.AddRange(customersToImport);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            StringBuilder sb = new();

            BookingImportDto[] dtos = JsonConvert.DeserializeObject<BookingImportDto[]>(jsonString)!;

            List<Booking> bookingsToImport = new();

            var customers = context.Customers.Select(c => new
            {
                c.FullName,
                c.Id
            })
                .ToList();

            var packages = context.TourPackages.Select(p => new
            {
                p.PackageName,
                p.Id
            })
                .ToList();

            foreach (var dto in dtos!)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!DateTime.TryParseExact(dto.BookingDate, BookingDateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validDate))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Booking booking = new()
                {
                    BookingDate = validDate,
                    CustomerId = customers.FirstOrDefault(c => c.FullName == dto.CustomerName)!.Id,
                    TourPackageId = packages.FirstOrDefault(p => p.PackageName == dto.TourPackageName)!.Id
                };
                bookingsToImport.Add(booking);
                sb.AppendLine(string.Format(SuccessfullyImportedBooking, dto.TourPackageName, validDate.ToString(BookingDateTimeFormat)));
            }

            context.Bookings.AddRange(bookingsToImport);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
