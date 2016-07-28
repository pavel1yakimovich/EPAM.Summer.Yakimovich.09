using System;
using System.Collections.Generic;
using NLog;

namespace Task04Logic
{
    public class BookListService
    {
        private static ILogger logger;
        private List<Book> bookList;
        private IBookListStorage storage { get; set; }
        
        public BookListService(List<Book> books, IBookListStorage storage = null, ILogger log = null)
        {
            if (ReferenceEquals(books, null))
            {
                logger.Error("NBooks contains null reference");
                throw new ArgumentNullException();
            }
            bookList = books;
            if (ReferenceEquals(log, null))
                logger = new NLogAdaptor(LogManager.GetCurrentClassLogger());
            this.storage = storage;
        }
        /// <summary>
        /// adds book in list
        /// </summary>
        /// <param name="book">book</param>
        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                logger.Error("book has null reference");
                throw new ArgumentNullException();
            }

            if (bookList.Contains(book))
            {
                logger.Info($"books already contains the book {book}");
                throw new ArgumentException();
            }

            bookList.Add(book);
            logger.Info($"book {book} has been added");
        }

        /// <summary>
        /// removes book from list
        /// </summary>
        /// <param name="book">book</param>
        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                logger.Error("book has null reference");
                throw new ArgumentNullException();
            }
            
            if (!bookList.Remove(book))
            {
                logger.Error("no such book");
                throw new ArgumentException();
            }

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
            if (author == null || title == null || pages <= 0 || published <= 0)
            {
                logger.Info("no list");
                throw new ArgumentNullException();
            }
            Book temp = new Book(author, title, pages, published);
            foreach (Book b in bookList)
            {
                if (b.Equals(temp))
                {
                    logger.Info($"book {b} was found in list");
                    return b;
                }
            }

            logger.Error("no such book");
            throw new ArgumentException();
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
                throw new ArgumentNullException();
            }
            
            bookList.Sort(comparison);
            logger.Info("Books have been sorted");
        }

        public void Save()
        {
            if (ReferenceEquals(storage, null))
            {
                logger.Error("You have no storage registered");
                throw new InvalidOperationException();
            }

            storage.SaveBooks(bookList);
            logger.Info("Books have been saved");
        }

        public void LoadBooks()
        {
            if (ReferenceEquals(storage, null))
            {
                logger.Error("You have no storage registered");
                throw new InvalidOperationException();
            }

            bookList = storage.LoadBooks();
            logger.Info("Books have been loaded");
        }
    }
}
