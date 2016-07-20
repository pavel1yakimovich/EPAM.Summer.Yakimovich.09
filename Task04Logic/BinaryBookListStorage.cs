using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Task04Logic
{
    public class BinaryBookListStorage : IBookListStorage
    {
        private static ILogger logger;
        private readonly string _fileName;

        public BinaryBookListStorage(string fileName, ILogger log = null)
        {
            _fileName = fileName;
            FileStream fs = File.Open(fileName, FileMode.OpenOrCreate);
            fs.Close();
            if (ReferenceEquals(log, null))
                logger = new NLogAdaptor(LogManager.GetCurrentClassLogger());
        }
        /// <summary>
        /// loads books from file
        /// </summary>
        /// <returns>List of books</returns>
        public List<Book> LoadBooks()
        {
            try
            {
                List<Book> books = new List<Book>();
                FileStream fs = File.OpenRead(_fileName);
                var r = new BinaryReader(fs);

                while (r.PeekChar() > -1)
                {
                    string author = r.ReadString();
                    string title = r.ReadString();
                    int pages = r.ReadInt32();
                    int published = r.ReadInt32();

                    books.Add(new Book(author, title, pages, published));
                }

                r.Close();
                logger.Info("list has been loaded from file");
                return books;
            }
            catch (Exception e)
            {
                logger.Error(e, "cannot load books");
                return null;
            }
        }

        /// <summary>
        /// saves list of books in file
        /// </summary>
        /// <param name="books">list of books</param>
        public void SaveBooks(IEnumerable<Book> books)
        {
            try
            {
                FileStream fs = File.OpenWrite(_fileName);
                BinaryWriter w = new BinaryWriter(fs);

                foreach (Book b in books)
                {
                    w.Write(b.Author);
                    w.Write(b.Title);
                    w.Write(b.Pages);
                    w.Write(b.Published);
                }

                w.Close();

                logger.Info("list has been saved to file");
            }
            catch (Exception e)
            {
                logger.Info(e, "cannot save books to file");
            }
        }
    }
}
