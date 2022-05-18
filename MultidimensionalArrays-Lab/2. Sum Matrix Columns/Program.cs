using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
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
                int[] colElements = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = colElements[j];
                }
            }
  
            //calculating sum of each column's elements
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int currSum = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    currSum += matrix[j, i];
                }

                Console.WriteLine(currSum);
            }
        }
    }
}
