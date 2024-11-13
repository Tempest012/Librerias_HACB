using System;
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
    }
}
