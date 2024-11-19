using System;
using System.Linq;
using Librerias_HACB.Data.Models;
using Librerias_HACB.Data.ViewModels;
namespace Librerias_HACB.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }
        //Método que nos permite agregar un nuevo Editora en la BD
        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }
        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n=>n.Id == publisherId)
                .Select(n => new PublisherWithBooksAndAuthorsVM() 
            {
                Name=n.Name,
                BookAuthors=n.Books.Select(n=> new BookAuthorVM()
                {
                    BookName=n.Titulo,
                    BookAuthor=n.Book_Authors.Select(n=> n.Author.FullName).ToList(),
                }).ToList()
            }).FirstOrDefault();
            return _publisherData;
        }

        public void DeletePublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);
            if(_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
        }
    }
}
