using Librerias_HACB.Data.Models;
using Librerias_HACB.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Librerias_HACB.Data.Services
{

    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }
        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                Rate = book.Rate,
                Genero = book.Genero,
                Autor = book.Autor,
                CoverUrl = book.CoverUrl,
                DateAddes = DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }
        public List<Book> GetAllBks() => _context.Books.ToList();
        public Book GetBookById(int bookid) => _context.Books.FirstOrDefault(n => n.id == bookid);
    }
}
