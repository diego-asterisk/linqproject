﻿// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

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