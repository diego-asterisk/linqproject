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