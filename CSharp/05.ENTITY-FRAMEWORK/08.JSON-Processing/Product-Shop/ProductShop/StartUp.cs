namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using ProductShop.Data;
    using ProductShop.Models;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new ProductShopContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                //var inputJson = File.ReadAllText("./../../../Datasets/categories-products.json");

                var result = GetUsersWithProducts(db);

                Console.WriteLine(result);
            }
        }


        //01. Import Users 
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {context.Users.Count()}";
        }


        //02. Import Products 
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {context.Products.Count()}";
        }


        //03. Import Categories 
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                                        .Where(c => c.Name != null)
                                        .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {context.Categories.Count()}";
        }


        //04. Import Categories and Products 
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {context.CategoryProducts.Count()}";
        }


        //05. Export Products In Range 
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                                   .Where(p => p.Price >= 500 && p.Price <= 1000)
                                   .OrderBy(p => p.Price)
                                   .Select(p => new
                                   {
                                       p.Name,
                                       p.Price,
                                       Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                                   })
                                   .ToList();

            return JsonConvert.SerializeObject(products, Resolver());
        }


        //06. Export Sold Products 
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                               .Where(u => u.ProductsSold.Count() >= 1 && u.ProductsSold.Any(ps => ps.BuyerId != null))
                               .OrderBy(u => u.LastName)
                               .ThenBy(u => u.FirstName)
                               .Select(u => new
                               {
                                   u.FirstName,
                                   u.LastName,
                                   SoldProducts = u.ProductsSold
                                                   .Select(ps => new
                                                   {
                                                       ps.Name,
                                                       ps.Price,
                                                       BuyerFirstName = ps.Buyer.FirstName,
                                                       BuyerLastName = ps.Buyer.LastName
                                                   })
                                                   .ToList()
                               })
                               .ToList();

            return JsonConvert.SerializeObject(users, Resolver());
        }


        //07. Export Categories By Products Count 
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                                    .OrderByDescending(c => c.CategoryProducts.Count())
                                    .Select(c => new
                                    {
                                        Category = c.Name,
                                        ProductsCount = c.CategoryProducts.Count,
                                        AveragePrice = $"{c.CategoryProducts.Select(cp => cp.Product.Price).Average():F2}",
                                        TotalRevenue = $"{c.CategoryProducts.Select(cp => cp.Product.Price).Sum():F2}"
                                    })
                                    .ToList();

            return JsonConvert.SerializeObject(categories, Resolver());
        }


        //08. Export Users and Products 
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = new
            {
                UsersCount = context.Users.Where(us => us.ProductsSold.Any(ps => ps.BuyerId != null)).Count(),
                Users = context.Users
                               .Where(u => u.ProductsSold.Any(ps => ps.BuyerId != null))
                               .Select(usr => new
                               {
                                   usr.FirstName,
                                   usr.LastName,
                                   usr.Age,
                                   SoldProducts = new
                                   {
                                       Count = usr.ProductsSold.Where(p => p.BuyerId != null).Count(),
                                       Products = usr.ProductsSold
                                                     .Where(p => p.BuyerId != null)
                                                     .Select(p => new
                                                     {
                                                         p.Name,
                                                         p.Price
                                                     })
                                                     .ToList()
                                   }
                               })
                               .OrderByDescending(u => u.SoldProducts.Count)
                               .ToList()
            };
                               

            var resolver = Resolver();
            resolver.NullValueHandling = NullValueHandling.Ignore;

            return JsonConvert.SerializeObject(users, resolver);
        }


        private static JsonSerializerSettings Resolver()
        {
            var resolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            return new JsonSerializerSettings
            {
                ContractResolver = resolver,
                Formatting = Formatting.Indented
            };
        }
    }
}