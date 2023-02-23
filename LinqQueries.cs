using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BooksLinq
{
    public class LinqQueries
    {
        private List<Book> librosCollection = new List<Book>();

        public LinqQueries()
        {
            using(StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() {
                    PropertyNameCaseInsensitive = true
                    });
            }
        }

        public IEnumerable<Book> TodaLaColeccion()
        {
            return librosCollection;
        }
        public IEnumerable<Book> LibrosDespues2000()
        {
            // extension method
            // return librosCollection.Where(x=>x.PublishedDate.Year > 2000);
            // query expresion 
            return from l in librosCollection where l.PublishedDate.Year > 2000 select l;
        }
        public IEnumerable<Book> LibrosMas200()
        {
            // extension method
            return librosCollection.Where(x => x.PageCount > 250 && x.Title.Contains("in Action"));
            // query expresion 
            // return from l in librosCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
        }
        public IEnumerable<Book> LibrosMasDe(int paginas)
        {
            // extension method
            // return librosCollection.Where(x => x.PageCount > 450);
            // query expresion 
            return from l in librosCollection where l.PageCount > paginas select l;
        }
        public IEnumerable<Book> LibrosDePython()
        {
            // extension method
            // return librosCollection.Where(x => x.Categories.Contains("Python"));
            // query expresion 
            return from l in librosCollection where l.Categories.Contains("Python") select l;
        }
       public IEnumerable<Book> LibrosDe(string nombre)
        {
            // extension method
            // return librosCollection.Where(x => x.Categories.Contains(nombre));
            // query expresion 
            return from l in librosCollection where l.Categories.Contains(nombre) select l;
        }
        public IEnumerable<Book> LibrosOrdenadosNombreAsc(IEnumerable<Book> libros){
            return libros.OrderBy(p => p.Title);
        }
       public IEnumerable<Book> LibrosOrdenadosPaginasDesc(IEnumerable<Book> libros){
            return libros.OrderByDescending(p => p.PageCount);
        }
        // SKIP Y TAKE: UTILIZANDO EL OPERADOR SKIP SELECCIONA EL TERCER Y CUARTO LIBRO DE LOS QUE TENGAN MÁS DE 400 PÁGINAS 
        // tambien existen skipwhile y takewhile que toman o ignoran elementos mientras se cumple la condicion
        public IEnumerable<Book> Libros3eroY4toCon400Paginas()
        {
            return librosCollection
                .Where( p => p.PageCount > 400 )
                .Take(4)// los primeros 4
                .Skip(2); //omite el primero y el segundo
        }
        // usar SELECT para seleccionar los campos necesarios, eso crea un tipo dinamico: new { Title = p.Title, Count = p.PageCount }
        // o crear un objeto de la clase Book o de una clase nueva o subtipo
        public IEnumerable<Book> LibrosTop3()
        {
            return librosCollection
                .Take(3)
                .Select( p => new Book(){ Title = p.Title, PageCount = p.PageCount} );
        }

        public bool TodosLibrosTienenStatus()
        {
            return librosCollection.All(x => x.Status != string.Empty);
        }
        public bool AlgunLibroPublicado2005()
        {
            return librosCollection.Any(x => x.PublishedDate.Year == 2005);
        }
    }
}