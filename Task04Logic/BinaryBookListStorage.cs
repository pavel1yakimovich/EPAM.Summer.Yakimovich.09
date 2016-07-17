using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04Logic
{
    public class BinaryBookListStorage : IBookListStorage
    {
        public BinaryBookListStorage(string fileName)
        {

        }

        public List<Book> LoadBooks()
        {
            List<Book> books = new List<Book>();
            return books;
        }

        public void SaveBooks(IEnumerable<Book> books)
        {

        }
    }
}
