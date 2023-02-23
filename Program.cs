// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksLinq
{
    public class Animal
  {
    public string Nombre {get;set;}
    public string Color {get;set;}
  }
  class Program
  {
    static void Main(string[] args)
    {
        LinqQueries queries = new LinqQueries();

        ImprimirValores(queries.TodaLaColeccion());
        
        ImprimirValores(queries.LibrosDespues2000());
        
        ImprimirValores(queries.LibrosMas200());

        Console.WriteLine($"Todos los libros tienen Status? {queries.TodosLibrosTienenStatus()}");
        Console.WriteLine($"Algún libro se publicó en 2005? {queries.AlgunLibroPublicado2005()}");

        ImprimirValores(queries.LibrosDePython());

        ImprimirValores(queries.LibrosOrdenadosNombreAsc(queries.LibrosDe("Java")));

        ImprimirValores(queries.LibrosOrdenadosPaginasDesc(queries.LibrosMasDe(450)));

        
    List<Animal> animales = new List<Animal>();
    animales.Add(new Animal() { Nombre = "Hormiga", Color = "Rojo" });
    animales.Add(new Animal() { Nombre = "Lobo", Color = "Gris" });
    animales.Add(new Animal() { Nombre = "Elefante", Color = "Gris" });
    animales.Add(new Animal() { Nombre = "Pantegra", Color = "Negro" });
    animales.Add(new Animal() { Nombre = "Gato", Color = "Negro" });
    animales.Add(new Animal() { Nombre = "Iguana", Color = "Verde" });
    animales.Add(new Animal() { Nombre = "Sapo", Color = "Verde" });
    animales.Add(new Animal() { Nombre = "Camaleon", Color = "Verde" });
    animales.Add(new Animal() { Nombre = "Gallina", Color = "Blanco" });

    // Escribe tu código aquí
    // Retorna los elementos de la colleción animal ordenados por nombre

    var lolos = animales.OrderBy( x => x.Nombre );

                    foreach(var item in lolos)
                {
                    Console.WriteLine("{0,60} {1, -15} ", item.Nombre, item.Color);
                }
        
        void ImprimirValores(IEnumerable<Book> listadelibros)
        {
            Console.WriteLine("{0,60} {1, -15} {2, -15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
            foreach(var item in listadelibros)
            {
                Console.WriteLine("{0,60} {1, -15} {2, -15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
            }
        }
    }

  }
}