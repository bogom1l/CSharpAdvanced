using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int rows = N;
            int cols = N;

            char[,] matrix = new char[rows, cols];

            //reading matrix from console
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] colElements = Console.ReadLine().ToCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = colElements[j];
                }
            }

            char symbolToSearchFor = char.Parse(Console.ReadLine());

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (symbolToSearchFor == matrix[i, j])
                    {
                        Console.WriteLine($"({i}, {j})");
                        Environment.Exit(0);
                    }
                }
            }

            Console.WriteLine($"{symbolToSearchFor} does not occur in the matrix");

        }
    }
}
