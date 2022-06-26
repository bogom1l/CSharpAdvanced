using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exam2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            ReadMatrix(matrix);

            int countHoles = 1;
            int countRods = 0;

            (int row, int col) = GetPlayerPosition(matrix);

            string command = string.Empty;

            while (true)
            {
                command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                if (command == "up")
                {
                    if (AreValidCoordinates(matrix, row - 1, col)) //if coordinates are valid
                    {
                        if (matrix[row - 1, col] == 'C') //if he hits a Cable 
                        {
                            matrix[row - 1, col] = 'E';
                            matrix[row, col] = '*';
                            countHoles++;
                            break;
                        }
                        else if (matrix[row - 1, col] == '*') //if he hits an already made hole
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{row - 1}, {col}]!");
                            MoveUp(matrix, ref row, col);
                        }
                        else if (matrix[row - 1, col] == 'R') //if he hits hits a rod
                        {
                            Console.WriteLine($"Vanko hit a rod!");
                            countRods++; //increase count of rods
                        }
                        else
                        {
                            MoveUp(matrix, ref row, col);
                            countHoles++; //increasing number of holes
                        }
                    }
                }
                else if (command == "down")
                {
                    if (AreValidCoordinates(matrix, row + 1, col)) //if coordinates are valid
                    {
                        if (matrix[row + 1, col] == 'C') //if he hits a Cable 
                        {
                            matrix[row + 1, col] = 'E';
                            matrix[row, col] = '*';
                            countHoles++;
                            break;
                        }
                        else if (matrix[row + 1, col] == '*') //if he hits an already made hole
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{row + 1}, {col}]!");
                            MoveDown(matrix, ref row, col);
                        }
                        else if (matrix[row + 1, col] == 'R') //if he hits hits a rod
                        {
                            Console.WriteLine($"Vanko hit a rod!");
                            countRods++; //increase count of rods
                        }
                        else
                        {
                            MoveDown(matrix, ref row, col);
                            countHoles++; //increasing number of holes
                        }
                    }
                }
                else if (command == "right")
                {
                    if (AreValidCoordinates(matrix, row, col + 1)) //if coordinates are valid
                    {
                        if (matrix[row, col + 1] == 'C') //if he hits a Cable 
                        {
                            matrix[row, col + 1] = 'E';
                            matrix[row, col] = '*';
                            countHoles++;
                            break;
                        }
                        else if (matrix[row , col + 1] == '*') //if he hits an already made hole
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{row}, {col + 1}]!");
                            MoveRight(matrix, row, ref col);
                        }
                        else if (matrix[row, col + 1] == 'R') //if he hits hits a rod
                        {
                            Console.WriteLine($"Vanko hit a rod!");
                            countRods++; //increase count of rods
                        }
                        else
                        {
                            MoveRight(matrix, row, ref col);
                            countHoles++; //increasing number of holes
                        }
                    }
                }
                else if (command == "left")
                {
                    if (AreValidCoordinates(matrix, row, col - 1)) //if coordinates are valid
                    {
                        if (matrix[row, col - 1] == 'C') //if he hits a Cable 
                        {
                            matrix[row, col - 1] = 'E';
                            matrix[row, col] = '*';
                            countHoles++;
                            break;
                        }
                        else if (matrix[row, col - 1] == '*') //if he hits an already made hole
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{row}, {col - 1}]!");
                            MoveLeft(matrix, row, ref col);
                        }
                        else if (matrix[row, col - 1] == 'R') //if he hits hits a rod
                        {
                            Console.WriteLine($"Vanko hit a rod!");
                            countRods++; //increase count of rods
                        }
                        else
                        {
                            MoveLeft(matrix, row, ref col);
                            countHoles++; //increasing number of holes
                        }

                    }
                }

               // Console.WriteLine($"~~~~~~ cnt: {countHoles}");
               // Console.WriteLine();
               // PrintMatrix(matrix);
               // Console.WriteLine();
            }

            if (command == "End")
            {
                Console.WriteLine($"Vanko managed to make {countHoles} hole(s) and he hit only {countRods} rod(s).");
            }
            else
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {countHoles} hole(s).");
            }
            PrintMatrix(matrix);
        }

        static void MoveUp(char[,] matrix, ref int row, int col)
        {
            matrix[row, col] = '*'; //makes a hole
            row--; //moves up
            matrix[row, col] = 'V';
        }

        static void MoveDown(char[,] matrix, ref int row, int col)
        {
            matrix[row, col] = '*'; //makes a hole
            row++; //moves down
            matrix[row, col] = 'V';
        }

        static void MoveRight(char[,] matrix, int row, ref int col)
        {
            matrix[row, col] = '*'; //makes a hole
            col++; //moves right
            matrix[row, col] = 'V';
        }

        static void MoveLeft(char[,] matrix, int row, ref int col)
        {
            matrix[row, col] = '*'; //makes a hole
            col--; //moves left
            matrix[row, col] = 'V';
        }

        static (int, int) GetPlayerPosition(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'V')
                    {
                        return (i, j);
                    }
                }
            }

            return (0, 0);
        }

        static bool AreValidCoordinates(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
        static void ReadMatrix(char[,] matrix)
        {
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
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }
        }

    }
}
