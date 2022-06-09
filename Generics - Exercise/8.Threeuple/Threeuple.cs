using System;
using System.Collections.Generic;
using System.Text;

namespace Box
{
    public class Threeuple<TFirst, TSecond, TThird>
    {
        public Threeuple(TFirst firstEl, TSecond secondEl, TThird thirdEl)
        {
            this.FirstElement = firstEl;
            this.SecondElement = secondEl;
            this.ThirdElement = thirdEl;
        }

        public TFirst FirstElement { get; private set; }
        public TSecond SecondElement { get; private set; }
        public TThird ThirdElement { get; set; }

        public override string ToString()
        {
            return $"{this.FirstElement} -> {this.SecondElement} -> {this.ThirdElement}";
        }

    }
}
