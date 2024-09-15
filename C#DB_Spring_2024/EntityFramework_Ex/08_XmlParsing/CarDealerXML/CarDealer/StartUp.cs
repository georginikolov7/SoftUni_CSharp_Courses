using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext context = new CarDealerContext();

            //string suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //Console.WriteLine(ImportSuppliers(context, suppliersXml));

            //string partsXML = File.ReadAllText("../../../Datasets/parts.xml");
            //Console.WriteLine(ImportParts(context, partsXML));

            //string carsXML = File.ReadAllText("../../../Datasets/cars.xml");
            //Console.WriteLine(ImportCars(context, carsXML));
            //string customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            //Console.WriteLine(ImportCustomers(context,customersXml));

            //string salesXML = File.ReadAllText("../../../Datasets/sales.xml");
            //Console.WriteLine(ImportSales(context, salesXML));

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        //09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new(typeof(SupplierImportDto[]), new XmlRootAttribute("Suppliers"));

            SupplierImportDto[] importDtos;
            using (var reader = new StringReader(inputXml))
            {
                importDtos = (SupplierImportDto[])xmlSerializer.Deserialize(reader);
            }

            Supplier[] suppliers = importDtos
                .Select(dto => new Supplier()
                {
                    Name = dto.Name,
                    IsImporter = dto.IsImporter
                })
                .ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {importDtos.Count()}";
        }
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new(typeof(PartImportDto[]), new XmlRootAttribute("Parts"));

            PartImportDto[] partImportDtos;
            using var reader = new StringReader(inputXml);
            partImportDtos = xmlSerializer.Deserialize(reader) as PartImportDto[];

            var validSupplierIds = context.Suppliers
                .Select(s => s.Id)
                .ToList();
            Part[] filteredParts = partImportDtos
               .Where(x => validSupplierIds.Contains(x.SupplierId))
               .Select(x => new Part()
               {
                   Name = x.Name,
                   Price = x.Price,
                   Quantity = x.Quantity,
                   SupplierId = x.SupplierId
               })
               .ToArray();
            context.Parts.AddRange(filteredParts);
            context.SaveChanges();

            return $"Successfully imported {filteredParts.Count()}";
        }
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new(typeof(CarImportDto[]), new XmlRootAttribute("Cars"));

            CarImportDto[] carDtos;
            using var reader = new StringReader(inputXml);
            carDtos = xmlSerializer.Deserialize(reader) as CarImportDto[];

            List<Car> filteredCars = new();

            foreach (var dto in carDtos)
            {
                Car car = new Car()
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TraveledDistance = dto.TraveledDistance,

                };
                int[] carPartsId = dto.PartIds.Select(p => p.Id).Distinct().ToArray();

                var carParts = new List<PartCar>();
                foreach (var partId in carPartsId)
                {
                    carParts.Add(new PartCar()
                    {
                        Car = car,
                        PartId = partId
                    });
                }
                car.PartsCars = carParts;
                filteredCars.Add(car);
            }
            context.Cars.AddRange(filteredCars);
            context.SaveChanges();

            return $"Successfully imported {filteredCars.Count()}";
        }
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new(typeof(CustomerImportDto[]), new XmlRootAttribute("Customers"));

            CustomerImportDto[] importDtos;
            using (var reader = new StringReader(inputXml))
            {
                importDtos = (CustomerImportDto[])xmlSerializer.Deserialize(reader);
            }

            Customer[] customers = importDtos
                .Select(dto => new Customer()
                {
                    Name = dto.Name,
                    BirthDate = dto.BirthDate,
                    IsYoungDriver = dto.IsYoungDriver,
                })
                .ToArray();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {importDtos.Count()}";
        }
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new(typeof(SaleImportDto[]), new XmlRootAttribute("Sales"));

            SaleImportDto[] dtos;
            using var reader = new StringReader(inputXml);
            dtos = xmlSerializer.Deserialize(reader) as SaleImportDto[];

            var validCarIds = context.Cars
                .Select(c => c.Id)
                .ToList();

            Sale[] filteredSales = dtos
               .Where(s => validCarIds.Contains(s.CarId))
               .Select(s => new Sale()
               {
                   Discount = s.Discount,
                   CarId = s.CarId,
                   CustomerId = s.CustomerId,
               })
               .ToArray();
            context.Sales.AddRange(filteredSales);
            context.SaveChanges();

            return $"Successfully imported {filteredSales.Count()}";
        }
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TraveledDistance > 2_000_000)
                .Select(c => new CarExportDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();


            return SerializeToXML<CarExportDto[]>(cars, "cars");
        }


        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var shits = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new BMWExporDto()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ToArray();

            return SerializeToXML<BMWExporDto[]>(shits, "cars", true);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSupplierDtos = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new LocalSupplierExportDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            return SerializeToXML<LocalSupplierExportDto[]>(localSupplierDtos, "suppliers");
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .Select(c => new CarWithPartsExportDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                    Parts = c.PartsCars.OrderByDescending(pc => pc.Part.Price)
                    .Select(pc => new PartExportDto()
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })

                    .ToArray()
                })
                .ToArray();

            return SerializeToXML<CarWithPartsExportDto[]>(cars, "cars");
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {


            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BougthCars = c.Sales.Count,
                    SalesInfo = c.Sales.Select(s => c.IsYoungDriver
                    ? s.Car.PartsCars.Sum(pc => Math.Round((double)pc.Part.Price * 0.95, 2))
                    : s.Car.PartsCars.Sum(pc => (double)pc.Part.Price)
                ).ToArray()
                })
                .ToArray();


            var dtos = customers.Select(c => new CustomerExportDto()
            {
                FullName = c.FullName,
                BougthCars = c.BougthCars,
                SpentMoney = c.SalesInfo.Sum(i => (decimal)i)
            }).
                OrderByDescending(c => c.SpentMoney)
                .ToArray();
            return SerializeToXML<CustomerExportDto[]>(dtos, "customers");
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                //.Include(s => s.Car)
                //.ThenInclude(c => c.PartsCars)
                //.ThenInclude(pc => pc.Part)
                .Select(s => new SaleExportDto
                {
                    Car = new CarExportDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Discount = (int)s.Discount,
                    Price = (decimal)s.Car.PartsCars.Sum(pc => (double)pc.Part.Price),
                    PriceWithDiscount =
                        Math.Round((double)(s.Car.PartsCars
                            .Sum(p => p.Part.Price) * (1 - (s.Discount / 100))), 4)
                })
                .ToArray();


            return SerializeToXML<SaleExportDto[]>(sales, "sales");
        }

        private static string SerializeToXML<T>(T dto, string xmlRootAttribute, bool omitDeclarations = false)
        {
            XmlSerializer serializer = new(typeof(T), new XmlRootAttribute(xmlRootAttribute));

            StringBuilder sb = new();

            //Settings:
            XmlWriterSettings settings = new()
            {
                OmitXmlDeclaration = omitDeclarations,
                Encoding = new UTF8Encoding(false),
                Indent = true
            };

            using StringWriter stringWriter = new StringWriter(sb, CultureInfo.InvariantCulture);
            using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings))
            {
                XmlSerializerNamespaces namespaces = new();
                namespaces.Add(string.Empty, string.Empty);

                try
                {
                    serializer.Serialize(xmlWriter, dto, namespaces);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return sb.ToString();

        }
    }
}