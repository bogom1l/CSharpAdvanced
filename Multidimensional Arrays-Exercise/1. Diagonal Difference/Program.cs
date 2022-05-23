using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int rows = N;
            int cols = N;

            int[,] matrix = new int[rows, cols];

            //reading matrix from console
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] colElements = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = colElements[j];
                }
            }

            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        sum1 += matrix[i, j];
                    }
                }
            }

            int rightDiagonal = matrix.GetLength(1) - 1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == rightDiagonal)
                    {
                        sum2 += matrix[i, j];
                    }
                }
                rightDiagonal--;
            }

            Console.WriteLine($"{Math.Abs(sum1-sum2)}");
        }
    }
}
