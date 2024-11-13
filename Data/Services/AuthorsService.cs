using System;
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
    }
}
