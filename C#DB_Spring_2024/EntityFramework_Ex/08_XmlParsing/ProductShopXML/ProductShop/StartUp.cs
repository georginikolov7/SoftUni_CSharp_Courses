using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using ProductShop.Data;
using ProductShop.Models;
using ProductShop.DTOs.Import;
using ProductShop.DTOs.Export;
using System.Runtime.CompilerServices;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {

            using ProductShopContext context = new ProductShopContext();
            string usersXML = File.ReadAllText("../../../Datasets/users.xml");
            string productsXml = File.ReadAllText("../../../Datasets/products.xml");
            string catXML = File.ReadAllText("../../../Datasets/categories.xml");
            string catProductsXML = File.ReadAllText("../../../Datasets/categories-products.xml");

            //Console.WriteLine(ImportUsers(context, usersXML));
            //Console.WriteLine(ImportProducts(context, productsXml));
            //Console.WriteLine(ImportCategories(context, catXML));
            // Console.WriteLine(ImportCategoryProducts(context, catProductsXML));

            Console.WriteLine(GetProductsInRange(context));
        }
        //Imports:
        //01:
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new(typeof(UserImportDto[]), new XmlRootAttribute("Users"));

            UserImportDto[] dtos;

            using (StringReader reader = new StringReader(inputXml))
            {
                dtos = serializer.Deserialize(reader) as UserImportDto[];
            }




            User[] users = dtos.Select(u => new User()
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Age = u.Age,
            })
                .ToArray();


            context.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Length}";

        }
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new(typeof(ProductImportDto[]), new XmlRootAttribute("Products"));

            ProductImportDto[] dtos;

            using (StringReader reader = new StringReader(inputXml))
            {
                dtos = serializer.Deserialize(reader) as ProductImportDto[];
            }

            var validIds = context.Users.Select(u => u.Id).ToList();

            Product[] products = dtos.Select(p => new Product()
            {
                Name = p.Name,
                Price = p.Price,
                SellerId = p.SellerId,
                BuyerId = p.BuyerId,
            })
                //.Where(p => validIds.Contains((int)p.BuyerId) && validIds.Contains(p.SellerId))
                .ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Length}";
        }
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {

            XmlSerializer serializer = new(typeof(CategoryImportDto[]), new XmlRootAttribute("Categories"));

            CategoryImportDto[] dtos;

            using (StringReader reader = new StringReader(inputXml))
            {
                dtos = serializer.Deserialize(reader) as CategoryImportDto[];
            }

            Category[] categories = dtos.Select(p => new Category()
            {
                Name = p.Name,
            })
                .Where(c => c.Name is not null)
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new(typeof(CategoryProductImportDto[]), new XmlRootAttribute("CategoryProducts"));

            CategoryProductImportDto[] dtos;

            using (StringReader reader = new StringReader(inputXml))
            {
                dtos = serializer.Deserialize(reader) as CategoryProductImportDto[];
            }


            var validCategoryIds = context.Categories.Select(c => c.Id).ToList();

            var validProductIds = context.Products.Select(p => p.Id).ToList();

            CategoryProduct[] categoriesProducts = dtos.Select(cp => new CategoryProduct()
            {
                CategoryId = cp.CategoryId,
                ProductId = cp.ProductId
            })
                .Where(cp => validCategoryIds.Contains(cp.CategoryId) && validProductIds.Contains(cp.ProductId))
                .ToArray();

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Length}";
        }

        //Emports:
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductExportDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = string.Concat(p.Buyer.FirstName, " ", p.Buyer.LastName).Trim()
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToArray();

            
            

            return SerializeToXML<ProductExportDto[]>(productsInRange, "Products");
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new UserExportDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(ps => new ProductsForUsersExportDto()
                    {
                        Name = ps.Name,
                        Price = ps.Price,
                    })
                    .ToArray()
                })
                .ToArray();


            return SerializeToXML<UserExportDto[]>(users, "Users");
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new CategoryExportDto()
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();


            return SerializeToXML<CategoryExportDto[]>(categories, "Categories");
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    ProductsCount = u.ProductsSold.Count,
                    Products = u.ProductsSold.Select(p => new
                    {
                        p.Name,
                        p.Price
                    })
                    .ToArray(),
                })
                .OrderByDescending(u => u.ProductsCount)
                .Take(10)
                .ToArray();

            int totalCount = context.Users.Count(u => u.ProductsSold.Any());

            var structuredUsers = new UserWithProductsExportDto()
            {
                Count = totalCount,
                Users = users.Select(u => new UserP8ExportDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsExportDto()
                    {
                        Count = u.ProductsCount,
                        Products = u.Products.Select(p => new ProductsForUsersExportDto()
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .ToArray()
            };

            return SerializeToXML<UserWithProductsExportDto>(structuredUsers, "Users", true);
        }



        //<Summary>: Method for serializing dtos to XML</Summary>
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