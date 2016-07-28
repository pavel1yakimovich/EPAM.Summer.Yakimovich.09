using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task04Logic
{
    [Serializable]
    public sealed class Book : IEquatable<Book>, IComparable<Book>, IComparable
    {
        private string _author, _title;
        private int _pages, _published;

        public string Author
        {
            get { return _author; }
            set
            {
                if (ReferenceEquals(value, null))
                    throw new ArgumentNullException();
                _author = value;
            }
        }

        public string Title {
            get { return _title; }
            set
            {
                if (ReferenceEquals(value, null))
                    throw new ArgumentNullException();
                _title = value;
            }
        }

        public int Pages
        {
            get { return _pages; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException();
                _pages = value;
            }
            
        }

        public int Published
        {
            get { return _published; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException();
                _published = value;
            }

        }

        public Book() { }

        public Book(string author, string title, int pages, int published)
        {
            this.Author = author;
            this.Title = title;
            this.Pages = pages;
            this.Published = published;
        }

        public int CompareTo(Book other)
        {
            return this.Pages.CompareTo(other.Pages);
        }


        public int CompareTo(object obj)
        {
            try
            {
                Book book = (Book)obj;
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }
            return this.Pages.CompareTo(obj);
        }

        public bool Equals(Book other)
        {
            if (other == null) return false;
            return (this.Author == other.Author && this.Title == other.Title && this.Pages == other.Pages
                    && this.Published == other.Published);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Book)) return false;
            return this.Equals((Book) obj);
        }

        public override string ToString()
        {
            return
                $"Author: {this.Author}; Title: {this.Title}; Number of pages: {this.Pages}; Year of publishing: {this.Published}";
        }

        public override int GetHashCode()
        {
            int hashcode = Author.GetHashCode();
            hashcode = 31*hashcode + Title.GetHashCode();
            hashcode = 31*hashcode + Pages;
            hashcode = 31*hashcode + Published;
            return hashcode;
        }
    }
}
