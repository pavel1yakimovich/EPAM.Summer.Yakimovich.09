using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04Logic
{
    public class BookListService
    {
        private readonly IBookListStorage _storage;

        public BookListService(BookListStorageCreator creator, string fileName)
        {
            _storage = creator.Create(fileName);
        }

        public BookListService(IBookListStorage storage)
        {
            _storage = storage;
        }
        /// <summary>
        /// adds book in storage
        /// </summary>
        /// <param name="book">book</param>
        public void AddBook(Book book)
        {
            List<Book> books = _storage.LoadBooks();
            books.Add(book);
            _storage.SaveBooks(books);
        }
  
        /// <summary>
        /// removes book from storage
        /// </summary>
        /// <param name="book">book</param>
        public void RemoveBook(Book book)
        {
            List<Book> books = _storage.LoadBooks();
            books.Remove(book);
            _storage.SaveBooks(books);
        }

        /// <summary>
        /// finds book in storage by tags
        /// </summary>
        /// <param name="author">author</param>
        /// <param name="title">title</param>
        /// <param name="pages">pages</param>
        /// <param name="published">year of publishing</param>
        /// <returns></returns>
        public Book FindBookByTag(string author, string title, int pages, int published)
        {
            List<Book> books = _storage.LoadBooks();
            Book temp = new Book(author, title, pages, published);
            foreach (Book b in books)
            {
                if (b.Equals(temp)) return b;
            }

            throw new ArgumentException("No such book");
        }

        /// <summary>
        /// sorts books in storage 
        /// </summary>
        /// <param name="comparison">methos of comparison</param>
        public void SortBooksByTag(Comparison<Book> comparison)
        {
            List<Book> books = _storage.LoadBooks();
            books.Sort(comparison);
            _storage.SaveBooks(books);
        }
    }
}
