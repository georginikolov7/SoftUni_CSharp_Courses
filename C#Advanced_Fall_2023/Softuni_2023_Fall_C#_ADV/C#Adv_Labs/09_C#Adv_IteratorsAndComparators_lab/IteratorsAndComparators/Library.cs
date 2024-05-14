using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            Books = new(books,BookComparator );
        }
        private comparer=new BookComparator<Book>();
        public SortedSet<Book> Books { get; set; }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(Books.ToList());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private int index = -1;
            private List<Book> books;
            public LibraryIterator(List<Book> books)
            {
                this.books = books;
            }
            public Book Current => this.books[index];

            object IEnumerator.Current => Current;



            public bool MoveNext()
            {
                index++;
                return index < books.Count;
            }

            public void Reset()
            {
                index = -1;
            }
            public void Dispose() { }
        }
    }
}
