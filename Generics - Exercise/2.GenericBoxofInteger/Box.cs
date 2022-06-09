using System;
using System.Collections.Generic;
using System.Text;

namespace Box
{
    public class Box<T>
    {
        public T Element { get; }

        public Box(T el)
        {
            Element = el;
        }

        public override string ToString()
        {
            return $"{typeof(T)}: {Element}";
        }
    }
}
