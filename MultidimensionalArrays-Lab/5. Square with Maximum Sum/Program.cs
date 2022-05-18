using System;
using System.Linq;

namespace _5._Square_with_Maximum_Sum
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
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] colElements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = colElements[j];
                }
            }

            long maxSum = long.MinValue;
            int bestRow = 0;
            int bestCol = 0;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    long sum =
                        matrix[i, j] +
                        matrix[i, j + 1] +
                        matrix[i + 1, j] +
                        matrix[i + 1, j + 1];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        bestRow = i;
                        bestCol = j;
                    }
                }
            }

            for (int i = bestRow; i <= bestRow + 1; i++)
            {
                for (int j = bestCol; j <= bestCol + 1; j++)
                {
                    Console.Write($"{matrix[i,j]} "); 
                }
                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}
