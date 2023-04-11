// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
// medir el tiempo de ejecucion
using System.Diagnostics;

namespace BooksLinq
{
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

        ImprimirValores(queries.Libros3eroY4toCon400Paginas());

        ImprimirValores(queries.LibrosTop3());
        ImprimirValorcitos(queries.LibrosTop5());

        // medir el tiempo de ejecucion
        // using System.Diagnostics;
        Stopwatch sw = new Stopwatch(); // Creación del Stopwatch.
        sw.Start(); // Iniciar la medición.

        var librosMenos500 = queries.LibrosMas200Menos500();

        sw.Stop(); // Detener la medición.
        var elapsed = sw.Elapsed.ToString("hh\\:mm\\:ss\\.fffffff");
        Console.WriteLine("Time elapsed: {0}", elapsed); // Mostrar el tiempo transcurriodo con un formato hh:mm:ss.000

        sw.Start(); // Iniciar la medición.

        // esta forma tarda el doble que la forma anterior llamada 'buena practica'
        var librosMenos500count = queries.LibrosMas200Menos500paginas2();

        sw.Stop(); // Detener la medición.
        var elapsed2 = sw.Elapsed.ToString("hh\\:mm\\:ss\\.fffffff");
        Console.WriteLine("Time elapsed: {0}", elapsed2); // Mostrar el tiempo transcurriodo con un formato hh:mm:ss.000

        Console.WriteLine("Cantidad de libros con mas de 200 hojas y menos de 500: {0}", librosMenos500);
        Console.WriteLine("Cantidad de libros con mas de 200 hojas y menos de 500: {0}", librosMenos500count);

        // fecha de publicacion menor de todos los libros
        Console.WriteLine("Fecha de publicacion menor de todos los libros es {0}",queries.FechaDePublicacionMenor().ToShortDateString());

        // cantidad maxima de paginas en el conjunto de libros
        Console.WriteLine($"Maxima cantidad de hojas: {queries.NumeroDePaginasMayor()}");

        // libro con menor cantidad de paginas (que no sea cero)
        Console.WriteLine($"El libro se llama {queries.LibroConNumeroDePaginasMenor().Title} con menos paginas.");

        // libro con la fecha mas reciente
        Console.WriteLine($"El libro mas reciente se llama {queries.LibroConFechaMayor().Title}.");


        void ImprimirValores(IEnumerable<Book> listadelibros)
        {
            Console.WriteLine("{0,60} {1, -15} {2, -15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
            foreach(var item in listadelibros)
            {
                Console.WriteLine("{0,60} {1, -15} {2, -15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
            }
        }
        void ImprimirValorcitos(IEnumerable<Booky> listadelibros)
        {
            Console.WriteLine("{0,60} {1, -15} \n", "Titulo", "N. Paginas");
            foreach(var item in listadelibros)
            {
                Console.WriteLine("{0,60} {1, -15} ", item.Title, item.PageCount);
            }
        }
    }

  }
}