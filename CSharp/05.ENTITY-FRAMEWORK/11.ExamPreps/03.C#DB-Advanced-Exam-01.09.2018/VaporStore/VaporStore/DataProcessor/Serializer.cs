namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.ExportDtos;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
            var genres = context.Genres.Where(g => genreNames.Contains(g.Name))
                                       .OrderByDescending(g => g.Games.Sum(gm => gm.Purchases.Count))
                                       .ThenBy(g => g.Id)
                                       .Select(g => new
                                       {
                                           Id = g.Id,
                                           Genre = g.Name,
                                           Games = g.Games.Where(gm => gm.Purchases.Any())
                                                          .OrderByDescending(gm => gm.Purchases.Count)
                                                          .ThenBy(gm => gm.Id)
                                                          .Select(gm => new
                                                          {
                                                              Id = gm.Id,
                                                              Title = gm.Name,
                                                              Developer = gm.Developer.Name,
                                                              Tags = string.Join(", ", gm.GameTags.Select(gt => gt.Tag.Name)),
                                                              Players = gm.Purchases.Count
                                                          }),
                                            TotalPlayers = g.Games.Sum(gm => gm.Purchases.Count)
                                       })
                                       .ToArray();

            return JsonConvert.SerializeObject(genres, Resolver());
        }

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
            var storeTypeValue = Enum.Parse<PurchaseType>(storeType);

            var users = context.Users
                               .Select(u => new ExportUserDto
                               {
                                   username = u.Username,
                                   Purchases = u.Cards
                                                .SelectMany(c => c.Purchases)
                                                .Where(p => p.Type == storeTypeValue)
                                                .Select(p => new ExportPurchaseDto
                                                {
                                                    Card = p.Card.Number,
                                                    Cvc = p.Card.Cvc,
                                                    Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                                                    Game = new ExportGameDto
                                                    {
                                                        title = p.Game.Name,
                                                        Genre = p.Game.Genre.Name,
                                                        Price = p.Game.Price
                                                    }
                                                })
                                                .OrderBy(p => p.Date)
                                                .ToArray(),
                                   TotalSpent = u.Cards
                                                 .SelectMany(c => c.Purchases)
                                                 .Where(p => p.Type == storeTypeValue)
                                                 .Sum(p => p.Game.Price)
                               })
                               .Where(u => u.Purchases.Any())
                               .OrderByDescending(u => u.TotalSpent)
                               .ThenBy(u => u.username)
                               .ToArray();

            return ResultFormater<ExportUserDto[]>(users, "Users");
		}


        // Helper method
        private static JsonSerializerSettings Resolver()
        {
            return new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented
            };
        }

        // Helper method
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