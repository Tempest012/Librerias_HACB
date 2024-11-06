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
        //Método que nos permite agregar un nuevo libro en la BD
        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genero = book.Genero,
                Autor = book.Autor,
                CoverUrl = book.CoverUrl,
                DateAddes = DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }
        //Método que nos permite obtener una lista de todos los libros de la DB
        public List<Book> GetAllBks() => _context.Books.ToList();
        //Método que nos permite obtener el libro que estamos pidiendo de la BD
        public Book GetBookById(int bookid) => _context.Books.FirstOrDefault(n => n.id == bookid);
        //Método que nos permite modificar un libro que se encuentra en la BD
        public Book UpdateBookByID(int bookid, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id == bookid);
            if (_book != null)
            {
                _book.Titulo = book.Titulo;
                _book.Descripcion = book.Descripcion;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead;
                _book.Rate = book.Rate;
                _book.Genero = book.Genero;
                _book.Autor = book.Autor;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();
            }
            return _book;
        }
        //Método que nos permite eliminar un libro de la BD
        public void DeleteBookById(int bookid)
        {
            var _book= _context.Books.FirstOrDefault(n=>n.id == bookid);
            if(_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
