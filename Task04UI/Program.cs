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
            Book book6 = new Book("q", "g", 4, 3);

            string fileName = "source";
            
            BookListStorageCreator creator = new BinaryBookListStorageCreator();
            IBookListStorage storage = creator.Create(fileName);

            List<Book> books = storage.LoadBooks();
            BookListService service = new BookListService(books);

            service.AddBook(book1);
            service.AddBook(book2);
            service.AddBook(book6);

            service.RemoveBook(book2);
            service.RemoveBook(book2);

            storage.SaveBooks(books);

            books = storage.LoadBooks();

            foreach (Book b in books)
                Console.WriteLine(b);

            Console.ReadKey();

        }
    }
}
