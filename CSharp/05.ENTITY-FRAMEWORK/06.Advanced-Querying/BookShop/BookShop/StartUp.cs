namespace BookShop
{
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);

                //int input = int.Parse(Console.ReadLine());

                var result = RemoveBooks(db);
                //Console.WriteLine(result);
            }
        }

        //1. Age Restriction 
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var books = context.Books
                               .Where(b => b.AgeRestriction.ToString().ToUpper() == command.ToUpper())
                               .Select(b => b.Title)
                               .OrderBy(b => b)
                               .ToList();

            return string.Join(Environment.NewLine, books);
        }


        //2. Golden Books 
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                               .Where(b => b.EditionType.ToString() == "Gold" &&
                                      b.Copies < 5000)
                               .OrderBy(b => b.BookId)
                               .Select(b => b.Title)
                               .ToList();


            return string.Join(Environment.NewLine, books);
        }


        //3. Books by Price 
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                               .Where(b => b.Price > 40)
                               .OrderByDescending(b => b.Price)
                               .Select(b => $"{b.Title} - ${b.Price:F2}")
                               .ToList();


            return string.Join(Environment.NewLine, books);
        }


        //4. Not Released In 
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                               .Where(b => b.ReleaseDate.Value.Year != year)
                               .OrderBy(b => b.BookId)
                               .Select(b => b.Title)
                               .ToList();

            return string.Join(Environment.NewLine, books);
        }


        //5. Book Titles by Category 
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                  .Select(c => c.ToUpper())
                                  .ToList();


            var books = context.Books
                              .Where(b => b.BookCategories
                                                .Select(bc => bc.Category.Name.ToUpper())
                                                .Intersect(categories)
                                                .Any())
                              .OrderBy(b => b.Title)
                              .Select(b => b.Title)
                              .ToList();

            return string.Join(Environment.NewLine, books);
        }


        //6. Released Before Date 
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var dateAsDateTime = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var books = context.Books
                               .Where(b => b.ReleaseDate < dateAsDateTime)
                               .OrderByDescending(b => b.ReleaseDate)
                               .Select(b => $"{b.Title} - {b.EditionType.ToString()} - ${b.Price:F2}")
                               .ToList();

            return string.Join(Environment.NewLine, books);
        }


        //7. Author Search 
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                                 .Where(a => a.FirstName.EndsWith(input))
                                 .OrderBy(a => a.FirstName)
                                 .ThenBy(a => a.LastName)
                                 .Select(a => $"{a.FirstName} {a.LastName}")
                                 .ToList();

            return string.Join(Environment.NewLine, authors);
        }


        //8. Book Search 
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                               .Where(b => b.Title.ToUpper().Contains(input.ToUpper()))
                               .OrderBy(b => b.Title)
                               .Select(b => b.Title)
                               .ToList();

            return string.Join(Environment.NewLine, books);
        }


        //9. Book Search by Author 
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                               .Where(b => b.Author.LastName.ToUpper().StartsWith(input.ToUpper()))
                               .OrderBy(b => b.BookId)
                               .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                               .ToList();

            return string.Join(Environment.NewLine, books);
        }


        //10. Count Books 
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context.Books
                               .Count(b => b.Title.Length > lengthCheck);

            return booksCount;                
        }


        //11. Total Book Copies 
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var bookCopies = context.Authors
                                    .OrderByDescending(a => a.Books.Sum(b => b.Copies))
                                    .Select(a => $"{a.FirstName} {a.LastName} - {a.Books.Sum(b => b.Copies)}")
                                    .ToList();

            return string.Join(Environment.NewLine, bookCopies);
        }


        //12. Profit by Category 
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                                  .OrderByDescending(c => c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price))
                                  .Select(c => $"{c.Name} ${c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price):F2}")
                                  .ToList();

            return string.Join(Environment.NewLine, categories);
        }

        //13. Most Recent Books 
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                                    .OrderBy(c => c.Name)
                                    .Select(c => new
                                    {
                                        c.Name,
                                        CategoryBooks = c.CategoryBooks
                                                            .OrderByDescending(cb => cb.Book.ReleaseDate)
                                                            .Select(cb => $"{cb.Book.Title} ({cb.Book.ReleaseDate.Value.Year})")
                                                            .Take(3)
                                    })
                                    .Select(r => $"--{r.Name}{Environment.NewLine}{string.Join(Environment.NewLine, r.CategoryBooks)}")
                                    .ToList();

            return string.Join(Environment.NewLine, categories);
        }


        //14. Increase Prices 
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                               .Where(b => b.ReleaseDate.Value.Year < 2010)
                               .ToList();

            foreach (var book in books)
            {
                book.Price += 5m;
            }

            context.SaveChanges();
        }


        //15. Remove Books 
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                               .Where(b => b.Copies < 4200)
                               .ToList();

            context.Books.RemoveRange(books);
            context.SaveChanges();

            return books.Count;
        }
    }
}
