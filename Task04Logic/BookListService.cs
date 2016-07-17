using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Task04Logic
{
    public sealed class BookListService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IBookListStorage _storage;

        public BookListService(BookListStorageCreator creator, string fileName)
        {
            _storage = creator.Create(fileName);
            FileStream fs = File.Open(fileName, FileMode.OpenOrCreate);
            fs.Close();
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
            if (ReferenceEquals(book, null))
            {
                logger.Error("book has null reference");
                return;
            }
            List<Book> books = _storage.LoadBooks();
            if (ReferenceEquals(books, null))
            {
                logger.Info("no books in storage");
                return;
            }
            if (books.Contains(book))
            {
                logger.Info($"books already contains the book {book}");
                return;
            }
            books.Add(book);
            _storage.SaveBooks(books);
            logger.Info($"book {book} has been added");
        }
  
        /// <summary>
        /// removes book from storage
        /// </summary>
        /// <param name="book">book</param>
        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                logger.Error("book has null reference");
                return;
            }
            List<Book> books = _storage.LoadBooks();
            if (ReferenceEquals(books, null))
            {
                logger.Info("no books in storage");
                return;
            }
            if (!books.Remove(book))
            {
                logger.Error("no such book");
                return;
            }
            _storage.SaveBooks(books);
            logger.Info($"book {book} has been deleted");
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
            if (ReferenceEquals(books, null))
            {
                logger.Info("no books in storage");
                return null;
            }
            Book temp = new Book(author, title, pages, published);
            foreach (Book b in books)
            {
                if (b.Equals(temp))
                {
                    logger.Info($"book {b} was found in storage");
                    return b;
                }
            }

            logger.Error("no such book");
            return null;
        }

        /// <summary>
        /// sorts books in storage 
        /// </summary>
        /// <param name="comparison">methos of comparison</param>
        public void SortBooksByTag(Comparison<Book> comparison)
        {
            if (ReferenceEquals(comparison, null))
            {
                logger.Error("comparison reference is null");
                return;
            }
            List<Book> books = _storage.LoadBooks();
            if (ReferenceEquals(books, null))
            {
                logger.Info("no books in storage");
                return;
            }
            books.Sort(comparison);
            _storage.SaveBooks(books);
            logger.Info("Books have been sorted");
        }
    }
}
