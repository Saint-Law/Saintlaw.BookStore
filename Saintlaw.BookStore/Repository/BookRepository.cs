using Microsoft.EntityFrameworkCore;
using Saintlaw.BookStore.Data;
using Saintlaw.BookStore.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Saintlaw.BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                TotalPages = model.TotalPages,
                UpdatedOn = DateTime.UtcNow
            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if (allbooks?.Any() == true)
            {
               foreach(var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        Id = book.Id,
                        Language = book.Language,
                        Title = book.Title,
                        TotalPages = book.TotalPages,
                    });
                }
                
            }
            return books;
        }
        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if(book != null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    Language = book.Language,
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                };
                return bookDetails;
            }
            return null;
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title == title && x.Author == authorName).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id =1, Title="MVC", Author="Saintlaw", Description="this is the descriptoin for MVC book", Category="Programming", Language="English", TotalPages=134},
                new BookModel(){Id =2, Title="Dot Net Core", Author="Basic", Description="this is the descriptoin for dot net core book", Category="Framework", Language="Chinese", TotalPages=567},
                new BookModel(){Id =3, Title="C#", Author="Elkay", Description="this is the descriptoin for C# book", Category="Developer", Language="Hindi", TotalPages=897},
                new BookModel(){Id =4, Title="Java", Author="Saintlaw", Description="this is the descriptoin for java book", Category="Concept", Language="English", TotalPages=564},
                new BookModel(){Id =5, Title="Php", Author="Elkay", Description="this is the descriptoin for PHP book", Category="Programming", Language="English", TotalPages=100},
                new BookModel(){Id =6, Title="Node.js", Author="Qbasic", Description="this is the descriptoin for Node.js book", Category="DevOps", Language="English", TotalPages=800},
            };
        }
    }
}
