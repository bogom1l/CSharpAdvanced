﻿using System;
using System.Linq;

namespace _4._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine().Split(", ").Select(double.Parse).Select(x => x + x * 0.2).ToArray();

            foreach (var item in nums)
            {
                Console.WriteLine($"{item:f2}");
            }

        }
    }
}
