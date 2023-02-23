using System;
namespace BooksLinq
{
    public class Book
    {
        public string Title {get;set;}
        public int PageCount {get;set;}
        public string Status {get;set;}
        public DateTime PublishedDate {get;set;}
        public string[] Authors {get;set;}
        public string[] Categories {get;set;}
    }
    public class Booky
    {
        public string Title {get;set;}
        public int PageCount {get;set;}
    }

}
