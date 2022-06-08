using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T>
    {
        public T left { get; set; }

        public T right { get; set; }

        public EqualityScale(T leftEl, T rightEl)
        {
            this.left = leftEl;
            this.right = rightEl;
        }

        public bool AreEqual()
        {
            if (left.Equals(right))
            {
                return true;
            }

            return false;
        }

    }
}
