using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;


namespace _2.Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            ReadMatrix(matrix);

            Console.WriteLine();
            PrintMatrix(matrix);

            (int snakeRow, int snakeCol) = GetSnake(matrix);
            Console.WriteLine($"Snake is at: {snakeRow}, {snakeCol}");

            int countEatenFood = 0;

            if (AreThereBurrows(matrix))
            {
                //GetBurrow1Coordinates
                //?
            }



            while (AreValidCoordinates(matrix,ref snakeRow, ref snakeCol))
            {
                if (countEatenFood >= 10)
                {
                    break;
                }

                string command = Console.ReadLine();

                if (command == "up")
                {

                }
                else if(command == "down")
                {

                }
                else if(command == "right")
                {

                }
                else if(command == "left")
                {

                }




            }




        }

        static bool AreThereBurrows(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'B')
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static void MoveUp(char[,] matrix, ref int row, ref int col, ref int eatenFoodCount)
        {
            row--;
            if (AreValidCoordinates(matrix, ref row, ref col))
            {
                if (matrix[row, col] == '*')
                {
                    eatenFoodCount++;
                }
                matrix[row, col] = '.';
            }
        }

        static bool AreValidCoordinates(char[,] matrix,ref int row,ref int col)
        {
            return row >= 0 && row <= matrix.GetLength(0) &&
                col >= 0 && col <= matrix.GetLength(1);
        }
        static void ReadMatrix(char[,] matrix)
        {
            //reading matrix from console
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] currRowElements = Console.ReadLine().ToCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currRowElements[j];
                }
            }
        }
        static void PrintMatrix(char[,] matrix)
        {
            //printing matrix
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }
        }

        static (int, int) GetSnake(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'S')
                    {
                        return (i, j);
                    }
                }
            }
            return (0, 0);
        }

    }
}
