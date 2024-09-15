using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext context = new();
            //string suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");
            //Console.WriteLine(ImportSuppliers(context, suppliersJson));

            //string partsJson = File.ReadAllText("../../../Datasets/parts.json");
            //ImportParts(context, partsJson);

            //string carsJson = File.ReadAllText("../../../Datasets/cars.json");
            //ImportCars(context, carsJson);

            //string customersJson = File.ReadAllText("../../../Datasets/customers.json");
            //Console.WriteLine(ImportCustomers(context, customersJson));

            //string salesJson = File.ReadAllText("../../../Datasets/sales.json");
            //Console.WriteLine(ImportSales(context, salesJson));
           // Console.WriteLine(GetSalesWithAppliedDiscount(context));


        }
        //public static string ImportSuppliers(CarDealerContext context, string inputJson)
        //{
        //    List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);
        //    context.Suppliers.AddRange(suppliers);
        //    context.SaveChanges();
        //    return $"Successfully imported {suppliers.Count}.";
        //}
        //public static string ImportParts(CarDealerContext context, string inputJson)
        //{
        //    List<int> validSupplierIds = context.Suppliers.Select(s => s.Id).ToList();
        //    List<Part> parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
        //        .Where(p => validSupplierIds.Contains(p.SupplierId))
        //        .ToList();

        //    context.Parts.AddRange(parts);
        //    context.SaveChanges();

        //    return $"Successfully imported {parts.Count}.";
        //}
        //public static string ImportCars(CarDealerContext context, string inputJson)
        //{
        //    List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(inputJson);
        //    context.Cars.AddRange(cars);
        //    context.SaveChanges();
        //    return $"Successfully imported {cars.Count}.";
        //}
        //public static string ImportCustomers(CarDealerContext context, string inputJson)
        //{
        //    List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);
        //    context.Customers.AddRange(customers);
        //    context.SaveChanges();
        //    return $"Successfully imported {customers.Count}.";
        //}
        //public static string ImportSales(CarDealerContext context, string inputJson)
        //{
        //    List<Sale> sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);
        //    context.Sales.AddRange(sales);
        //    context.SaveChanges();
        //    return $"Successfully imported {sales.Count}.";
        //}
        //public static string GetOrderedCustomers(CarDealerContext context)
        //{
        //    var customers = context.Customers
        //        .Select(c => new
        //        {
        //            c.Name,
        //            c.BirthDate,
        //            c.IsYoungDriver
        //        })
        //        .OrderBy(c => c.BirthDate)
        //        .ThenBy(c => c.IsYoungDriver)
        //        .ToList();

        //    var customersFormatted = customers
        //        .Select(c => new
        //        {
        //            c.Name,
        //            BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
        //            c.IsYoungDriver
        //        }).ToList();
        //    return SerializeObject(customersFormatted);
        //}
        //public static string GetCarsFromMakeToyota(CarDealerContext context)
        //{
        //    var toyotas = context.Cars
        //        .Where(c => c.Make == "Toyota")
        //        .Select(c => new
        //        {
        //            c.Id,
        //            c.Make,
        //            c.Model,
        //            c.TraveledDistance
        //        })
        //        .OrderBy(c => c.Model)
        //        .ThenByDescending(c => c.TraveledDistance)
        //        .ToList();

        //    return SerializeObject(toyotas);
        //}

        //public static string GetLocalSuppliers(CarDealerContext context)
        //{
        //    var locals = context.Suppliers
        //        .Where(s => !s.IsImporter)
        //        .Select(s => new
        //        {
        //            s.Id,
        //            s.Name,
        //            PartsCount = s.Parts.Count
        //        })
        //        .ToList();

        //    return SerializeObject(locals);
        //}
        //public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        //{
        //    var cars = context.Cars
        //        .Include(c => c.PartsCars)
        //        .ThenInclude(pc => pc.Part)
        //        .Select(c => new
        //        {
        //            car = new CarDto()
        //            {
        //                Make = c.Make,
        //                Model = c.Model,
        //                TraveledDistance = c.TraveledDistance,
        //            },
        //            parts = c.PartsCars.Select(pc => new CarPartDto()
        //            {
        //                Name = pc.Part.Name,
        //                Price = pc.Part.Price.ToString("f2")
        //            })
        //        }
        //        )
        //        .ToList();


        //    return SerializeObject(cars);

        //}
        //public static string GetTotalSalesByCustomer(CarDealerContext context)
        //{
        //    var customers = context.Customers
        //        .Where(c => c.Sales.Any())
        //        .Select(c => new
        //        {
        //            FullName = c.Name,
        //            BoughtCars = c.Sales.Count,
        //            SpentMoney = decimal.Round(c.Sales.Sum(s => s.Car.PartsCars.Sum(pc => pc.Part.Price)), 2)
        //        })
        //        .OrderByDescending(c => c.SpentMoney)
        //        .ThenByDescending(c => c.BoughtCars)
        //        .ToList();

        //    return SerializeObjectCamelCasing(customers);
        //}

        //public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        //{
        //    var sales = context.Sales
        //        .Take(10)
        //        .Select(s => new
        //        {
        //            car = new
        //            {
        //                s.Car.Make,
        //                s.Car.Model,
        //                s.Car.TraveledDistance
        //            },
        //            customerName = s.Customer.Name,
        //            discount = s.Discount.ToString("f2"),
        //            price = s.Car.PartsCars.Sum(pc => pc.Part.Price).ToString("f2"),
        //            priceWithDiscount = (s.Car.PartsCars.Sum(pc => pc.Part.Price) - s.Discount).ToString("f2")
        //        })
        //        .ToList();

        //    return SerializeObject(sales);
        //}
        



        //-----------------------------------------------------------------------------
        //XML METHODS:
        private static string SerializeObjectCamelCasing(object obj, bool nullsIncluded = false)
        {
            JsonSerializerSettings settings;
            if (nullsIncluded)
            {
                settings = new JsonSerializerSettings()
                {
                    //NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Formatting = Formatting.Indented
                };
            }
            else
            {
                settings = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Formatting = Formatting.Indented
                };
            }

            return JsonConvert.SerializeObject(obj, settings);

        }
        private static string SerializeObject(object obj, bool nullsIncluded = false)
        {
            JsonSerializerSettings settings;
            if (nullsIncluded)
            {
                settings = new JsonSerializerSettings()
                {
                    //NullValueHandling = NullValueHandling.Ignore,
                    //ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Formatting = Formatting.Indented
                };
            }
            else
            {
                settings = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    //ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Formatting = Formatting.Indented
                };
            }

            return JsonConvert.SerializeObject(obj, settings);

        }
    }
}