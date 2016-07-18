using System;
using System.Collections.Generic;
using NLog;

namespace Task04Logic
{
    public class BookListService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private List<Book> bookList;
        
        public BookListService(List<Book> books)
        {
            bookList = books;
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
                return;
            }

            if (ReferenceEquals(bookList, null))
            {
                logger.Info("no list");
                return;
            }

            if (bookList.Contains(book))
            {
                logger.Info($"books already contains the book {book}");
                return;
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
                return;
            }

            if (ReferenceEquals(bookList, null))
            {
                logger.Info("no list");
                return;
            }

            if (!bookList.Remove(book))
            {
                logger.Error("no such book");
                return;
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
            if (ReferenceEquals(bookList, null))
            {
                logger.Info("no list");
                return null;
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

            if (ReferenceEquals(bookList, null))
            {
                logger.Info("no list");
                return;
            }

            bookList.Sort(comparison);
            logger.Info("Books have been sorted");
        }
    }
}
