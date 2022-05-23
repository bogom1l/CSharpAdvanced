using System;
using System.Collections.Generic;
using System.Linq;
namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];

            string[,] matrix = new string[rows, cols];
            ReadStringMatrix(matrix);

            Proccessing(matrix);
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        static bool IndexValidator(int matrixLength, int num)
        {
            if (num >= 0 && num < matrixLength)
            {
                return true;
            }
            return false;
        }
        static void ReadStringMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine().Split(" ");
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
        }
        static void Proccessing(string[,] matrix)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split();

                if (tokens[0] != "swap" || tokens.Length < 0 || tokens.Length > 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int firstRow = int.Parse(tokens[1]);
                int firstCol = int.Parse(tokens[2]);
                int secondRow = int.Parse(tokens[3]);
                int secondCol = int.Parse(tokens[4]);

                if (IndexValidator(matrix.GetLength(0), firstRow)
                    && IndexValidator(matrix.GetLength(1), firstCol)
                    && IndexValidator(matrix.GetLength(0), secondRow)
                    && IndexValidator(matrix.GetLength(1), secondCol))
                {
                    string temp = matrix[firstRow, firstCol];
                    matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                    matrix[secondRow, secondCol] = temp;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                PrintMatrix(matrix);


                input = Console.ReadLine();
            }

        }
    }

}

