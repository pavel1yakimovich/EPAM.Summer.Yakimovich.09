using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Task04Logic
{
    public class BinaryBookListStorage : IBookListStorage
    {
        private static ILogger logger;
        private readonly string _fileName;
        private BinaryFormatter formatter;

        public BinaryBookListStorage(string fileName, ILogger log = null, BinaryFormatter formatter = null)
        {
            if (fileName == null)
                throw new ArgumentNullException();

            _fileName = fileName;
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            fs.Close();

            this.formatter = formatter;

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

                if (ReferenceEquals(formatter, null))
                {

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

                while (fs.Position < fs.Length)
                {
                    var book = (Book) formatter.Deserialize(fs);
                    books.Add(book);
                }

                return books;
            }
            catch (Exception e)
            {
                logger.Error(e, "cannot load books");
                throw e;
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

                if (ReferenceEquals(formatter, null))
                {
                    foreach (Book b in books)
                    {
                        w.Write(b.Author);
                        w.Write(b.Title);
                        w.Write(b.Pages);
                        w.Write(b.Published);
                    }
                }
                else
                {
                    foreach (var book in books)
                    {
                        formatter.Serialize(fs, book);
                    }
                }
                w.Close();

                logger.Info("list has been saved to file");
            }
            catch (Exception e)
            {
                logger.Error(e, "cannot save books to file");
                throw e;
            }
        }
    }
}
