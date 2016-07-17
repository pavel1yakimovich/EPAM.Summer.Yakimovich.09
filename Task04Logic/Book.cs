using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04Logic
{
    public sealed class Book : IEquatable<Book>, IComparable<Book>, IComparable
    {
        public string Author { get; }

        public string Title { get; }

        public int Pages { get; }

        public int Published { get; }

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
            hashcode = 31*hashcode + Pages.GetHashCode();
            hashcode = 31*hashcode + Published.GetHashCode();
            return hashcode;
        }
    }
}
