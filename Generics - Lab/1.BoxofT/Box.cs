using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BoxOfT
{
    public class Box<T>
    {
        public List<T> data { get; set; }

        public Box()
        {
            data = new List<T>();
        }

        public int Count { get { return this.data.Count; } }

        public void Add(T element)
        {
            this.data.Add(element);
        }

        public T Remove()
        {
            var rem = this.data.Last();
            this.data.RemoveAt(this.data.Count - 1);
            return rem;
        }
    }
}
