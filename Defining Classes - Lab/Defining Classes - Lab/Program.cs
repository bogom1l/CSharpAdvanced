using System;
using System.Linq;
using System.Collections.Generic;

namespace Defining_Classes___Lab
{
    class Dice
    {
        int sides; //field
        public int Sides //property
        {
            get { return sides; } //getter
            set { sides = value; } //setter
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //sample

            Dice d6 = new Dice();
            Dice d8 = new Dice();

            d6.Sides = 6;

            Console.WriteLine(d6.Sides);
            Console.WriteLine(d6);
        }

    }
}
