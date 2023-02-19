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
            return librosCollection.Where(x=>x.PageCount > 250 && x.Title.Contains("in Action"));
            // query expresion 
            // return from l in librosCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
        }
    }
}