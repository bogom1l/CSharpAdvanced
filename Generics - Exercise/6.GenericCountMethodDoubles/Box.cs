using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Box
{
    public class Box<T> : IComparable<T> where T : IComparable<T>
    {
        public T Element { get; }

        public List<T> Elements { get; }

        public Box(List<T> list)
        {
            Elements = list;
        }


        public int CountOfGreaterElements<T>(List<T> list, T elementToBeCompared) where T : IComparable
            => list.Count(word => word.CompareTo(elementToBeCompared) > 0);


        public int CompareTo(T other)
            => Element.CompareTo(other);


        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (T item in Elements)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            return sb.ToString();
        }
    }
}
