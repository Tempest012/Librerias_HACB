using System.Collections.Generic;

namespace Librerias_HACB.Data.Models
{
    public class Publisher
    {
        public int Id {  get; set; }
        public string Name { get; set; }

        //Propiedades de navegación
        public List<Book> Books { get; set; }
    }
}
