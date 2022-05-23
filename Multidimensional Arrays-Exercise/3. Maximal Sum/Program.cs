using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = tokens[0];
            int cols = tokens[1];

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

            int[,] biggestMatrix = new int[3, 3];
            int biggestSum = -1;

            //search for 2x2 matrixes
            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    int currNum = matrix[i, j] + matrix[i + 1, j + 1] + matrix[i + 2, j + 2];
                    currNum += matrix[i + 1, j] + matrix[i, j + 1] + matrix[i, j + 2];
                    currNum += matrix[i + 1, j + 2] + matrix[i + 2, j] + matrix[i + 2, j + 1];

                    if (biggestSum < currNum)
                    {
                        biggestSum = currNum;

                        biggestMatrix[0, 0] = matrix[i, j];
                        biggestMatrix[0, 1] = matrix[i, j + 1];
                        biggestMatrix[0, 2] = matrix[i, j + 2];

                        biggestMatrix[1, 0] = matrix[i + 1, j];
                        biggestMatrix[1, 1] = matrix[i + 1, j + 1];
                        biggestMatrix[1, 2] = matrix[i + 1, j + 2];

                        biggestMatrix[2, 0] = matrix[i + 2, j];
                        biggestMatrix[2, 1] = matrix[i + 2, j + 1];
                        biggestMatrix[2, 2] = matrix[i + 2, j + 2];
                    }
                }
            }

            Console.WriteLine($"Sum = {biggestSum}");

            //printing the biggest 3x3 matrix
            for (int i = 0; i < biggestMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < biggestMatrix.GetLength(1); j++)
                {
                    Console.Write($"{biggestMatrix[i, j]} ");
                }
                Console.WriteLine();
            }

        }
    }
}
