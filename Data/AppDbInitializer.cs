using Librerias_HACB.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Librerias_HACB.Data
{
    public class AppDbInitializer
    {
        //Metodo que agrega datos a nuestra BD
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Titulo = "1rs Book Titlr",
                        Descripcion="1rs Book Description",
                        IsRead=true,
                        DateRead=DateTime.Now.AddDays(-10),
                        Rate=4,
                        Genero="Biography",
                        Autor="1st Author",
                        CoverUrl="https...",
                        DateAddes=DateTime.Now,
                    },
                    new Book()
                    {
                        Titulo = "2nd Book Titlr",
                        Descripcion = "2nd Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genero = "Biography",
                        Autor = "2nd Author",
                        CoverUrl = "https...",
                        DateAddes = DateTime.Now,
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
