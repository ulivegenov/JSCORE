namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.ImportDtos;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
            StringBuilder result = new StringBuilder();
            List<Game> games = new List<Game>();
            List<Developer> developers = new List<Developer>();
            List<Genre> genres = new List<Genre>();
            List<Tag> tags = new List<Tag>();

            var gamesDto = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            foreach (var gameDto in gamesDto)
            {
                if (!IsValid(gameDto) || !gameDto.Tags.All(IsValid))
                {
                    result.AppendLine("Invalid Data");
                    continue;
                }

                //Developer config
                var developer = developers.FirstOrDefault(d => d.Name == gameDto.Developer);
                if (developer == null)
                {
                    developer = new Developer()
                    {
                        Name = gameDto.Developer
                    };

                    developers.Add(developer);
                }

                //Genre config
                var genre = genres.FirstOrDefault(g => g.Name == gameDto.Genre);
                if (genre == null)
                {
                    genre = new Genre()
                    {
                        Name = gameDto.Genre
                    };

                    genres.Add(genre);
                }

                //Tag config
                List<Tag> gameTags = new List<Tag>();
                foreach (var tagName in gameDto.Tags)
                {
                    var newTag = tags.FirstOrDefault(t => t.Name == tagName);
                    if (newTag == null)
                    {
                        newTag = new Tag() 
                        {
                            Name = tagName
                        };

                        tags.Add(newTag);
                    }

                    gameTags.Add(newTag);
                }

                var game = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = DateTime.Parse(gameDto.ReleaseDate, CultureInfo.InvariantCulture),
                    Developer = developer,
                    Genre = genre,
                    GameTags = gameTags.Select(t => new GameTag { Tag = t }).ToArray()
                };

                games.Add(game);

                result.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            context.Developers.AddRange(developers);
            context.Genres.AddRange(genres);
            context.Tags.AddRange(tags);
            context.Games.AddRange(games);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
            StringBuilder result = new StringBuilder();
            List<User> users = new List<User>();
            List<Card> cards = new List<Card>();


            var usersDto = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            foreach (var userDto in usersDto)
            {
                if (!IsValid(userDto) || !userDto.Cards.All(IsValid))
                {
                    result.AppendLine("Invalid Data");
                    continue;
                }

                List<Card> currentUserCards = new List<Card>();

                foreach (var cardDto in userDto.Cards)
                {
                    CardType cardType; 
                    var iscardTypeValid = Enum.TryParse(cardDto.Type, out cardType);
                    if (!iscardTypeValid)
                    {
                        result.AppendLine("Invalid Data");
                        continue;
                    }

                    var card = new Card()
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.Cvc,
                        Type = cardType
                    };

                    currentUserCards.Add(card);
                    cards.Add(card);
                }

                var user = new User()
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age,
                    Cards = currentUserCards
                };

                users.Add(user);

                result.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.Cards.AddRange(cards);
            context.Users.AddRange(users);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
            StringBuilder result = new StringBuilder();
            List<Purchase> purchases = new List<Purchase>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPuchaseDto[]), new XmlRootAttribute("Purchases"));
            var purchasesDto = (ImportPuchaseDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            foreach (var purchaseDto in purchasesDto)
            {
                if (!IsValid(purchaseDto))
                {
                    result.AppendLine("Invalid Data");
                    continue;
                }

                PurchaseType purchaseType;
                var isTypeValid = Enum.TryParse(purchaseDto.Type, out purchaseType);
                if (!isTypeValid)
                {
                    result.AppendLine("Invalid Data");
                    continue;
                }
                var game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.Title);
                var card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.Card);
                var date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                var purchase = new Purchase()
                {
                    Type = purchaseType,
                    ProductKey = purchaseDto.ProductKey,
                    Card = card,
                    Date = date,
                    Game = game
                };

                purchases.Add(purchase);

                result.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }

            context.AddRange(purchases);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static bool IsValid(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}