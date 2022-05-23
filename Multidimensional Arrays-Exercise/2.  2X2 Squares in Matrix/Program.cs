using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.__2X2_Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = tokens[0];
            int cols = tokens[1];

            string[,] matrix = new string[rows, cols];

            //reading matrix from console
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] colElements = Console.ReadLine().Split();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = colElements[j];
                }
            }

            int cnt = 0;
            //search for 2x2 matrixes
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    string currChar = matrix[i, j];
                    if (currChar == matrix[i, j] && currChar == matrix[i, j + 1]
                        && currChar == matrix[i + 1, j] && currChar == matrix[i + 1, j + 1])
                    {
                        cnt++;
                    }
                }
            }

            Console.WriteLine(cnt);
        }

    }
}
