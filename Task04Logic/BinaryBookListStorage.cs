using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04Logic
{
    public class BinaryBookListStorage : IBookListStorage
    {
        private readonly string _fileName;

        public BinaryBookListStorage(string fileName)
        {
            _fileName = fileName;
        }
        /// <summary>
        /// loads books from file
        /// </summary>
        /// <returns>List of books</returns>
        public List<Book> LoadBooks()
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

            fs.Close();
            return books;
        }

        /// <summary>
        /// saves list of books in file
        /// </summary>
        /// <param name="books">list of books</param>
        public void SaveBooks(IEnumerable<Book> books)
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

            w.Flush();
            
            fs.Close();
        }
    }
}
