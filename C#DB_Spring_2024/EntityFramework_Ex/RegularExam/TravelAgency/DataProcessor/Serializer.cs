using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TravelAgency.Data;
using TravelAgency.Data.Models.Enums;
using TravelAgency.DataProcessor.ExportDtos;
using TravelAgency.Utilities;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            GuideXmlExportDto[] guideDtos = context
                .Guides
                .Where(g => g.Language == Language.Spanish)
                .Select(g => new GuideXmlExportDto()
                {
                    FullName = g.FullName,
                    TourPackages = g.TourPackagesGuides
                        .Select(tg => new TourPackageExportDto()
                        {
                            Name = tg.TourPackage.PackageName,
                            Description = tg.TourPackage.Description,
                            Price = tg.TourPackage.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ThenBy(p => p.Name)
                        .ToArray()
                })
                .OrderByDescending(g => g.TourPackages.Length)
                .ThenBy(g => g.FullName)
                .ToArray();

            return xmlHelper.Serialize<GuideXmlExportDto[]>(guideDtos, "Guides");
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            const string PackageName = "Horse Riding Tour";

            var output = context.Customers
                .Where(c => c.Bookings.Any(b => b.TourPackage.PackageName == PackageName))
                .Include(c=>c.Bookings)
                .ThenInclude(b=>b.TourPackage)
                .ToList()
                .Select(c => new
                {
                    c.FullName,
                    c.PhoneNumber,
                    Bookings = c.Bookings
                    .Where(b=>b.TourPackage.PackageName == PackageName)
                    .Select(b => new
                    {
                        TourPackageName = b.TourPackage.PackageName,
                        Date = b.BookingDate.ToString("yyyy-MM-dd")
                    })
                    .OrderBy(b => b.Date)
                    .ToList()
                })
                .OrderByDescending(c => c.Bookings.Count)
                .ThenBy(c => c.FullName)
                .ToList();

            return JsonConvert.SerializeObject(output, Formatting.Indented);
        }
    }
}
