using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _05.BookLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfBooks = int.Parse(Console.ReadLine());
            List<Book> books = new List<Book>();

            for (int i = 0; i < countOfBooks; i++)
            {
                books.Add(InputBook(Console.ReadLine()));
            }

            Library library = new Library
            {
                Name = "Library",
                Books = books,
            };

            Dictionary<string, decimal> authors = new Dictionary<string, decimal>();

            foreach (var book in library.Books)
            {
                if (authors.ContainsKey(book.Author))
                {
                    authors[book.Author] += book.price;
                }
                else
                {
                    authors[book.Author] = book.price;
                }
            }

            foreach (var pair in authors.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value:f2}");
            }
        }
        static Book InputBook(string input)
        {
            string[] books = input.Split(' ');
            List<string> Books = new List<string>();

            foreach (var book in books)
            {
                Books.Add(book);
            }
            return new Book
            {
                Name = Books[0],
                Author = Books[1],
                Publisher = Books[2],
                ReleaseDate = DateTime.ParseExact(Books[3], "dd.MM.yyyy", CultureInfo.InvariantCulture),
                numberISBN = ulong.Parse(Books[4]),
                price = decimal.Parse(Books[5])
            };
        }
        class Book
        {
            public string Name { get; set; }
            public string Author { get; set; }
            public string Publisher { get; set; }
            public DateTime ReleaseDate { get; set; }
            public ulong numberISBN { get; set; }
            public decimal price { get; set; }
        }
        class Library
        {
            public string Name { get; set; }
            public List<Book> Books { get; set; }
        }

    }
}
