using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
            IBookListStorage storage = creator.Create(fileName, formatter: new BinaryFormatter());

            List<Book> books = new List<Book>();
            BookListService service = new BookListService(books, storage);

            service.AddBook(book1);
            service.AddBook(book2);

            service.Save();

            books = storage.LoadBooks();

            foreach (Book b in books)
                Console.WriteLine(b);

            Console.ReadKey();

        }
    }
}
