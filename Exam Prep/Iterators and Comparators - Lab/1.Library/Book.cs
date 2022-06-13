using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public IReadOnlyList<string> Authors { get; set; }

        public Book(string t,int y, params string[] authors)
        {
            this.Title = t;
            this.Year = y;
            this.Authors = authors;
        }
    }
}
