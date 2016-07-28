using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Task04Logic
{
    class XMLBookListStorage : IBookListStorage
    {
        private static ILogger logger;
        private readonly string _fileName;

        public XMLBookListStorage(string fileName, ILogger log = null)
        {
            if (fileName == null)
                throw new ArgumentNullException();

            _fileName = fileName;

            if (ReferenceEquals(log, null))
                logger = new NLogAdaptor(LogManager.GetCurrentClassLogger());
        }

        /// <summary>
        /// Loads books from xml file
        /// </summary>
        /// <returns>List of books</returns>
        public List<Book> LoadBooks()
        {
            List<Book> books = new List<Book>();
            FileStream fs = null;
            try
            {
                fs = new FileStream(_fileName, FileMode.Open);
                XmlSerializer xmlData = new XmlSerializer(typeof(List<Book>));

                while (fs.Position < fs.Length)
                {
                    books = (List<Book>)xmlData.Deserialize(fs);
                }

                return books;
            }
            catch (Exception e)
            {
                logger.Error(e, "Cannot load books from XML file");
                throw;
            }
            finally
            {
                if (!ReferenceEquals(fs, null))
                    fs.Dispose();
            }
        }

        /// <summary>
        /// Saves books to xml file
        /// </summary>
        /// <param name="books">Books we want to save</param>
        public void SaveBooks(IEnumerable<Book> books)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(_fileName, FileMode.OpenOrCreate);

                var writer = new XmlSerializer(typeof(List<Book>));
                writer.Serialize(fs, books);

                logger.Info("Books have been saved to XML file");
            }
            catch (Exception e)
            {
                logger.Error(e, "Cannot save books to XML file");
                throw;
            }
            finally
            {
                if (!ReferenceEquals(fs, null))
                    fs.Dispose();
            }
        }
    }
}
