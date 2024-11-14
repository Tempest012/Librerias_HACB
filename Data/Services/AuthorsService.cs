using System;
using System.Linq;
using Librerias_HACB.Data.Models;
using Librerias_HACB.Data.ViewModels;
namespace Librerias_HACB.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }
        //Método que nos permite agregar un nuevo Autor en la BD
        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName= author.FullName
            };
            _context.Author.Add(_author);
            _context.SaveChanges();
        }
        public AuthorWithBooksVM GetAuthorWithBooks(int authorId)
        {
             var _author = _context.Author.Where(n=> n.Id == authorId).Select(n=> new AuthorWithBooksVM()
             {
                 FullName=n.FullName,
                 BookTitles=n.Book_Authors.Select(n=> n.Book.Titulo).ToList()
             }).FirstOrDefault();
            return _author;
        }
    }
}
