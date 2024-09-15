namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);
            RemoveBooks(db);
        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            Enum.TryParse(command, true, out AgeRestriction ageRestriction);
            List<string> titles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, titles);
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            List<string> titles = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5_000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, titles);
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            var resultBooks = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .ToList();
            StringBuilder sb = new();
            foreach (var book in resultBooks)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }
            return sb.ToString().Trim();
        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var resultBooks = context.Books
                .Where(book => book.ReleaseDate.Value.Year != year)
                .OrderBy(book => book.BookId)
                .Select(book => book.Title)
                .ToList();

            return String.Join(Environment.NewLine, resultBooks);
        }
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var titles = context.BooksCategories
                .Where(bc => categories.Contains(bc.Category.Name.ToLower()))
                .Select(b => b.Book.Title)
                .OrderBy(b => b)
                .ToList();
            return String.Join(Environment.NewLine, titles);
        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var resultDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var resultBooks = context.Books
                .Where(b => b.ReleaseDate < resultDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();
            StringBuilder sb = new();
            foreach (var book in resultBooks)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }
            return sb.ToString().Trim();
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => String.Concat(a.FirstName, " ", a.LastName))
                .OrderBy(a => a)
                .ToList();
            return String.Join(Environment.NewLine, authors);
        }
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            input = input.ToLower();
            var resultBooks = context.Books
                .Where(b => b.Title.ToLower().Contains(input))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();
            return string.Join(Environment.NewLine, resultBooks);

        }
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            input = input.ToLower();

            var resultBooks = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorName = string.Concat(b.Author.FirstName, " ", b.Author.LastName)
                })
                .ToList();

            StringBuilder sb = new();
            foreach (var book in resultBooks)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorName})");
            }
            return sb.ToString().Trim();
        }
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books.Count(b => b.Title.Length > lengthCheck);
        }
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var result = context.Authors
                .Select(a => new
                {
                    Name = string.Concat(a.FirstName, " ", a.LastName),
                    CopiesCount = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.CopiesCount)
                 .ToList();

            StringBuilder sb = new();
            foreach (var a in result)
            {
                sb.AppendLine($"{a.Name} - {a.CopiesCount}");
            }
            return sb.ToString().Trim();
        }
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var profitsPerCategory = context.Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.Name)
                .ToList();

            StringBuilder sb = new();
            foreach (var a in profitsPerCategory)
            {
                sb.AppendLine($"{a.Name} ${a.TotalProfit:f2}");
            }
            return sb.ToString().Trim();
        }
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var result = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks.OrderByDescending(b => b.Book.ReleaseDate)
                    .Take(3)
                    .Select(b => new
                    {
                        b.Book.Title,
                        b.Book.ReleaseDate.Value.Year
                    })
                    .ToList()
                })
                .OrderBy(c => c.Name)
                .ToList();

            StringBuilder sb = new();
            foreach (var cat in result)
            {
                sb.AppendLine($"--{cat.Name}");
                foreach (var book in cat.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.Year})");
                }
            }
            return sb.ToString().Trim();
        }
        public static void IncreasePrices(BookShopContext context)
        {
            var refDate = new DateTime(2010, 1, 1);
            var books = context.Books
                .Where(b => b.ReleaseDate < refDate)
                .AsEnumerable().ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }
            context.SaveChanges();
        }
        public static int RemoveBooks(BookShopContext context)
        {
            const int MinCopiesCount = 4200;
            var booksToRemove = context.Books
                .Where(b => b.Copies < MinCopiesCount)
                .ToList();

            foreach (var book in booksToRemove)
            {
                context.Remove(book);
            }
            context.SaveChanges();
            return booksToRemove.Count;
        }
    }
}


