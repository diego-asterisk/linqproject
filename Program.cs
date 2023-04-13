// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
// medir el tiempo de ejecucion
using System.Diagnostics;
using System.Linq;

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

        // cantiad de paginas entre los libros con menos de 500 hojas
        Console.WriteLine($"Suma de las páginas = {queries.SumaPaginasLibrosConCantidadMenor()}");

        // Los libros publicados despues de 2015
        Console.WriteLine($"Titulos publicados: {queries.TitulosPublicadosLuego(2015)}");

        // el promedio de la cantidad de caracteres en titulos
        Console.WriteLine($"Promedio de caracteres de los titulos: {queries.PromedioCaracteresTitulos()}");
        // el promedio de la cantidad de paginas de los libros (formateado a dos decimales)
        Console.WriteLine($"Promedio de paginas de los libros: {queries.PromedioPaginasLibros():N2}");

        string textToEnter = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
        // centrar texto
        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
   
        // Publicaciones agrupadas por Año
        var agrupados = queries.PublicacionesAgrupadas();
        ImprimirGrupo(agrupados);

        // Diccionario de titulos por letra inicial del titulo
        var diccionario =  queries.DiccionarioPorLetraInicialTitulo();
        Console.WriteLine();
        Console.WriteLine("Titulos de libros que inician con C");
        foreach(var item in diccionario['C']){
            Console.WriteLine(item);
        }
        Console.WriteLine();
        // Diccionario de titulos por letra inicial del titulo
        var libros =  queries.DiccionarioPorLetraInicialLibro();
        ImprimirValores(libros['C']);
        Console.WriteLine();

        Stopwatch sw3 = new Stopwatch(); // Creación del Stopwatch.
        sw3.Start(); // Iniciar la medición.
        // Join de libros
        ImprimirValores(queries.JoinLibros());
        sw3.Stop(); // Detener la medición.

        Console.WriteLine();

        Stopwatch sw4 = new Stopwatch(); // Creación del Stopwatch.
        sw4.Start(); // Iniciar la medición.
        // Join de libros con query expression
        ImprimirValores(queries.JoinLibrosQuery());
        sw4.Stop(); // Detener la medición.

        var elapsed3 = sw3.Elapsed.ToString("hh\\:mm\\:ss\\.fffffff");
        Console.WriteLine("Time elapsed query expression: {0}", elapsed3); // Mostrar el tiempo transcurriodo con un formato hh:mm:ss.000

        var elapsed4 = sw4.Elapsed.ToString("hh\\:mm\\:ss\\.fffffff");
        Console.WriteLine("Time elapsed extension: {0}", elapsed4); // Mostrar el tiempo transcurriodo con un formato hh:mm:ss.000

       void ImprimirGrupo(IEnumerable<IGrouping<int,Book>> listadelibros)
        {
            foreach(var grupo in listadelibros){
                Console.WriteLine();
                Console.WriteLine($"Grupo Año: {grupo.Key}");
                Console.WriteLine("{0,60} {1, -15} {2, -15}", "Titulo", "Nro. Pag.", "Fecha publicacion");
                foreach(var item in grupo)
                {
                    Console.WriteLine("{0,60} {1, -15} {2, -15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
                }
            }
        }
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