using Saintlaw.BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saintlaw.BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
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
