using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.Models;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext context = new ProductShopContext();
            //string usersJson = File.ReadAllText("../../../Datasets/users.json");
            //ImportUsers(context, usersJson);
            //string productsJson = File.ReadAllText("../../../Datasets/products.json"); string categoriesJson = File.ReadAllText("../../../Datasets/categories.json");
            //string categoriesProductsJson = File.ReadAllText("../../../Datasets/categories-products.json");

            //ImportProducts(context, productsJson);
            //ImportCategories(context, categoriesJson);
            //ImportCategoryProducts(context, categoriesProductsJson);
            Console.WriteLine(GetUsersWithProducts(context));

        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(inputJson);
            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users?.Count}";
        }
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Count}";
        }
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(inputJson);

            var filteredCategories = categories.Where(c => c.Name != null).ToList();
            context.Categories.AddRange(filteredCategories);
            context.SaveChanges();
            return $"Successfully imported {filteredCategories.Count}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoriesProducts.AddRange(categoriesProducts);
            context.SaveChanges();
            return $"Successfully imported {categoriesProducts.Count}";
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            const decimal MinPrice = 500m;
            const decimal MaxPrice = 1000m;
            var products = context.Products
                .Where(p => p.Price >= MinPrice && p.Price <= MaxPrice)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .OrderBy(p => p.price)
                .ToList();
            //JsonSerializerSettings settings = new()
            //{

            //}
            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            return json;

        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            //var users = context.Users
            //    .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
            //    .Select(u => new
            //    {
            //        u.FirstName,
            //        u.LastName,
            //        soldProducts = u.ProductsSold
            //        .Select(p => new
            //        {
            //            p.Name,
            //            p.Price,
            //            BuyerFirstName = p.Buyer.FirstName,
            //            BuyerLastName = p.Buyer.LastName
            //        }).ToList()
            //    })
            //    .OrderBy(u => u.LastName)
            //    .ThenBy(u => u.FirstName)
            //    .ToList();

            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new SellerWithProductsDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(p => new SoldProductsDto()
                    {
                        Name = p.Name,
                        Price = p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName
                    })
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToList();

            return SerializeObjectCamelCasing(users);
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var cats = context.Categories
                .Select(c => new CategoryDto()
                {
                    Category = c.Name,
                    ProductsCount = c.CategoriesProducts.Count(),
                    AveragePrice = decimal.Round(c.CategoriesProducts.Average(cp => cp.Product.Price), 2).ToString(),
                    TotalRevenue = decimal.Round(c.CategoriesProducts.Sum(cp => cp.Product.Price), 2).ToString()
                })
                .OrderByDescending(c => c.ProductsCount)
                .ToList();

            return SerializeObjectCamelCasing(cats);

        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    Products = u.ProductsSold
                    .Where(p => p.BuyerId != null)
                    .Select(p => new
                    {
                        p.Name,
                        Price = decimal.Round(p.Price, 2)
                    }).ToList()

                })
                .OrderByDescending(u => u.Products.Count())
                .ToList();


            var output = new
            {
                UsersCount = users.Count,
                Users = users.Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        Count = u.Products.Count(),
                        Products = u.Products.Select(p => new
                        {
                            p.Name,
                            Price = decimal.Round(p.Price, 2)
                        }).ToList()
                    }
                })
            };

            return SerializeObjectCamelCasing(output);
        }
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {

        }
        private static string SerializeObjectCamelCasing(object obj)
        {
            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(obj, settings);

        }
    }
}