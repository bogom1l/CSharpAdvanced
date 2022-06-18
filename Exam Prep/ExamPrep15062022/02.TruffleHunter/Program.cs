using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _02.TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            //reading matrix from console
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] currRowElements = Console.ReadLine().Replace(" ", string.Empty).ToCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currRowElements[j];
                }
            }

            int countBlack = 0;
            int countWhite = 0;
            int countSummer = 0;
            int boarEatenTruffelsCount = 0;


            string command = Console.ReadLine();

            while (command != "Stop the hunt")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                if (action == "Collect")
                {
                    int currRow = int.Parse(tokens[1]);
                    int currCol = int.Parse(tokens[2]);
                    if (AreValidCoordinates(matrix, currRow, currCol))
                    {
                        //collects the truffel
                        char currTruffel = matrix[currRow, currCol];
                        if (currTruffel == 'B')
                        {
                            countBlack++;
                        }
                        else if(currTruffel == 'W')
                        {
                            countWhite++;
                        }
                        else if(currTruffel == 'S')
                        {
                            countSummer++;
                        }

                        matrix[currRow, currCol] = '-';
                    }

                }
                else if(action == "Wild_Boar")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    string direction = tokens[3];

                    switch (direction)
                    {
                        case "up":
                            while(IsValidRow(row, n))
                            {
                                if (EatBoar(matrix, row, col))
                                {
                                    boarEatenTruffelsCount++;
                                }
                                row -= 2;
                            }
                            break;

                        case "down":
                            while (IsValidRow(row, n))
                            {
                                if (EatBoar(matrix, row, col))
                                {
                                    boarEatenTruffelsCount++;
                                }
                                row += 2;
                            }
                            break;

                        case "left":
                            while (IsValidCol(col, n))
                            {
                                if (EatBoar(matrix, row, col))
                                {
                                    boarEatenTruffelsCount++;
                                }
                                col -= 2;
                            }
                            break;

                        case "right":
                            while (IsValidCol(col, n))
                            {
                                if (EatBoar(matrix, row, col))
                                {
                                    boarEatenTruffelsCount++;
                                }
                                col += 2;
                            }
                            break;
                    }

                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Peter manages to harvest {countBlack} black, {countSummer} summer, and {countWhite} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarEatenTruffelsCount} truffles.");

            //printing matrix
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        static bool AreValidCoordinates(char[,] matrix, int row, int col)
        {
            return row >= 0 && row <= matrix.GetLength(0) &&
                col >= 0 && col <= matrix.GetLength(1);
        }

        static bool IsValidRow(int row, int size)
        {
            return row >= 0 && row < size;
        }
        static bool IsValidCol(int col, int size)
        {
            return col >= 0 && col < size;
        }

        static bool EatBoar(char[,] matrix, int row, int col)
        {
            char currSymbol = matrix[row, col];
            if (currSymbol == 'S' || currSymbol == 'B' || currSymbol == 'W')
            {
                matrix[row, col] = '-';
                return true;
            }
            return false;
        }

    }
}
