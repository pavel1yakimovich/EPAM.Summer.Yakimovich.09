using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task04Logic;

namespace Task04UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("q", "w", 6, 2);
            Book book2 = new Book("q", "e", 3, 2);
            Book book3 = new Book("q", "r", 1, 2);
            Book book4 = new Book("q", "t", 4, 2);
            Book book5 = new Book("q", "t", 4, 3);

            string fileName = "source.txt";
            
            BookListStorageCreator creator = new BinaryBookListStorageCreator();
            BookListService service = new BookListService(creator, fileName);

            service.AddBook(book1);
            service.AddBook(book2);
            service.AddBook(book3);
            service.AddBook(book4);

            service.RemoveBook(book2);

            Console.WriteLine(service.FindBookByTag(book3.Author, book3.Title, 
                book3.Pages, book3.Published).ToString());
            service.RemoveBook(book5);

            Console.ReadKey();

        }
    }
}
