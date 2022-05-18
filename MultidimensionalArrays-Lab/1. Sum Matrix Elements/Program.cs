using System;
using System.Linq;

namespace _1._Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = tokens[0];
            int cols = tokens[1];

            int[,] matrix = new int[rows, cols];

            //reading matrix from console
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] colElements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r,c] = colElements[c];
                }
            }

            int sum = 0;

            foreach (var el in matrix)
            {
                sum += el;
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);

        }
    }
}
