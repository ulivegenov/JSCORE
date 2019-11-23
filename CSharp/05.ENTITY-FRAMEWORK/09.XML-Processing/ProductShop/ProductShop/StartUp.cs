namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using AutoMapper;
    using ProductShop.Data;
    using ProductShop.Dtos.Export;
    using ProductShop.Dtos.Import;
    using ProductShop.Interfaces;
    using ProductShop.Models;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class StartUp
    {
        public static void Main()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<ProductShopProfile>());

            using (var db = new ProductShopContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                //var xmlString = File.ReadAllText("./../../../Datasets/categories-products.xml");

                var result = ImportProducts(db);
                Console.WriteLine(result);
            }
        }


        //01. Import Users 
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));

            var usersDto = (ImportUserDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var users = Mapper.Map<User[]>(usersDto);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {context.Users.Count()}";
        }


        //02. Import Products 
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));

            var productsDto = (ImportProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var products = Mapper.Map<Product[]>(productsDto);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {context.Products.Count()}";
        }


        //03. Import Categories 
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoriesDto[]), new XmlRootAttribute("Categories"));

            var categoriesDto = (ImportCategoriesDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categories = Mapper.Map<Category[]>(categoriesDto)
                                   .Where(c => c.Name != null)
                                   .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {context.Categories.Count()}";
        }


        //04. Import Categories and Products 
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var validProductIds = context.Products
                                         .Select(p => p.Id)
                                         .ToArray();

            var validCategoryIds = context.Categories
                                          .Select(c => c.Id)
                                          .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));

            var categoryProductsDto = (ImportCategoryProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categoryProducts = Mapper.Map<CategoryProduct[]>(categoryProductsDto)
                                         .Where(cp => validProductIds.Contains(cp.ProductId) &&
                                                      validCategoryIds.Contains(cp.CategoryId))
                                         .ToArray();

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {context.CategoryProducts.Count()}";
        }


        //05. Export Products In Range 
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productInRangeDto = context.Products
                                  .Where(p => p.Price >= 500 &&
                                              p.Price <= 1000)
                                  .OrderBy(p => p.Price)
                                  .Select(p => new ExportProductInRangeDto
                                  {
                                      Name = p.Name,
                                      Price = p.Price,
                                      Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                                  })
                                  .Take(10)
                                  .ToArray();


            //Extract next code into a generic method ResultFormater<T>(T[] selection, string rootAttributeName)

            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProductInRangeDto[]), new XmlRootAttribute("Products"));

            //var sb = new StringBuilder();

            //var namespaces = new XmlSerializerNamespaces(new[]
            //{
            //    new XmlQualifiedName("","")
            //});

            //xmlSerializer.Serialize(new StringWriter(sb), productInRangeDto, namespaces);

            //return sb.ToString().Trim();

            return ResultFormater<ExportProductInRangeDto[]>(productInRangeDto, "Products");
        }


        //06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersSoldProducts = context.Users
                                           .Where(u => u.ProductsSold.Any())
                                           .OrderBy(u => u.LastName)
                                           .ThenBy(u => u.FirstName)
                                           .Select(u => new ExportUserSoldProductDto
                                           {
                                               FirstName = u.FirstName,
                                               LastName = u.LastName,
                                               SoldProducts = u.ProductsSold
                                                               .Select(ps => new ExportSoldProductsDto
                                                               {
                                                                   Name = ps.Name,
                                                                   Price = ps.Price
                                                               })
                                                               .ToArray()
                                           })
                                           .Take(5)
                                           .ToArray();

            return ResultFormater<ExportUserSoldProductDto[]>(usersSoldProducts, "Users");
        }


        //07. Export Categories By Products Count 
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                                    .Select(c => new ExportCategoriesByProductsCountDto()
                                    {
                                        Name = c.Name,
                                        Count = c.CategoryProducts.Count,
                                        AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                                        TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                                    })
                                    .OrderByDescending(c => c.Count)
                                    .ThenBy(c => c.TotalRevenue)
                                    .ToArray();

            return ResultFormater<ExportCategoriesByProductsCountDto[]>(categories, "Categories");
        }


        //08. Export Users and Products 
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = new ExportUsersDto()
            {
                Count = context.Users
                               .Where(us => us.ProductsSold.Any())
                               .Count(),
                Users = context.Users
                               .Where(us => us.ProductsSold.Any())
                               .Select(us => new ExportUsersAgeDto()
                               {
                                   FirstName = us.FirstName,
                                   LastName = us.LastName,
                                   Age = us.Age,
                                   SoldProducts = new ExportSoldProductsElementDto()
                                   {
                                       Count = us.ProductsSold.Count(),
                                       Products = us.ProductsSold.Select(p => new ExportSoldProductsDto()
                                       {
                                           Name = p.Name,
                                           Price = p.Price
                                       })
                                       .OrderByDescending(p => p.Price)
                                       .ToArray()
                                   }
                               })
                               .OrderByDescending(us => us.SoldProducts.Count)
                               .Take(10)
                               .ToArray()
            };

            return ResultFormater<ExportUsersDto>(users, null);
        }


        //Helper method
        private static string ResultFormater<T>(T selection, string rootAttributeName)
        {

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootAttributeName));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), selection, namespaces);

            return sb.ToString().Trim();
        }
    }
}