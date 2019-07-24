using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


class Book
{
    private string title;
    private string author;
    private decimal price;

    public string Title
    {
        get { return title; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            title = value;
        }
    }

    public string Author
    {
        get { return author; }
        set
        {
            author = ValidateAuthorName(value);
        }
    }

    public virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            price = value;
        }
    }

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    private string ValidateAuthorName(string authorNames)
    {
        string[] dataNames = authorNames.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (dataNames.Length == 2 && char.IsDigit(dataNames[1].First()))
            {
                throw new ArgumentException("Author not valid!");
            }

        return $"{authorNames}";
    }

    public override string ToString()
    {
        StringBuilder outputBild = new StringBuilder();
        outputBild.AppendLine($"Type: {this.GetType().Name}");
        outputBild.AppendLine($"Title: {this.Title}");
        outputBild.AppendLine($"Author: {this.Author}");
        outputBild.AppendLine($"Price: {this.Price:f2}");
        string result = outputBild.ToString().TrimEnd();

        return result;
    }
}

