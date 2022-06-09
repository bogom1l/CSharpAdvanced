using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Box
{
    public class Box<T>
    {
        public Box(List<T> list)
        {
            Elements = list;
        }

        public List<T> Elements { get; }

        public void Swap(List<T> list, int index1, int index2)
        {
            T elementAtIndex1 = list.ElementAt(index1);
            T elementAtIndex2 = list.ElementAt(index2);

            list[index1] = elementAtIndex2;
            list[index2] = elementAtIndex1;
        }

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
