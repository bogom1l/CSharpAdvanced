using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _2._Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            ReadMatrix(matrix);
            int countSwords = 0;

            (int row, int col) = GetPlayerPosition(matrix); //Console.WriteLine($"row:{row}, col:{col}");
            (int Tp1row, int Tp1col) = GetTeleport1(matrix); //Console.WriteLine($"Tp1row:{Tp1row}, Tp1col:{Tp1col}");
            (int Tp2row, int Tp2col) = GetTeleport2(matrix, Tp1row, Tp1col); //Console.WriteLine($"Tp2row:{Tp2row}, Tp2col:{Tp2col}");

            bool areThereTeleports = true;

            if (Tp1row == -1 && Tp1col == -1 && Tp2row == -1 && Tp2col == -1) //there are no Teleports
            {
                areThereTeleports = false;
            }


            while (true)
            {
                if (countSwords >= 65)
                {
                    Console.WriteLine("Very nice swords, I will come back for more!");
                    break;
                }

                string command = Console.ReadLine();

                if (command == "up")
                {
                    if (AreValidCoordinates(matrix, row - 1, col))
                    {
                        if (areThereTeleports && matrix[row - 1, col] == 'M') //ako ima teleport na sledvashtata poziciq
                        {
                            MoveUp(matrix, ref row, col, ref countSwords); //pyrvo se mestq
                            Teleport(matrix, ref row, ref col, ref countSwords, Tp1row, Tp1col, Tp2row, Tp2col); //posle se teleportvam
                            areThereTeleports = false; //poveche nqma da se teleportvam (po uslovie)
                        }
                        else
                        {
                            MoveUp(matrix, ref row, col, ref countSwords);
                        }
                    }
                    else //Cordinates are NOT Valid => program ends
                    {
                        matrix[row, col] = '-';
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }
                }
                else if (command == "down")
                {
                    if (AreValidCoordinates(matrix, row + 1, col))
                    {
                        if (areThereTeleports && matrix[row + 1, col] == 'M') //ako ima teleport na sledvashtata poziciq
                        {
                            MoveDown(matrix, ref row, col, ref countSwords);
                            Teleport(matrix, ref row, ref col, ref countSwords, Tp1row, Tp1col, Tp2row, Tp2col);
                            areThereTeleports = false;
                        }
                        else
                        {
                            MoveDown(matrix, ref row, col, ref countSwords);
                        }
                    }
                    else //Cordinates are NOT Valid => program ends
                    {
                        matrix[row, col] = '-';
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }
                }
                else if (command == "right")
                {
                    if (AreValidCoordinates(matrix, row, col + 1))
                    {
                        if (areThereTeleports && matrix[row, col + 1] == 'M') //ako ima teleport na sledvashtata poziciq
                        {
                            MoveRight(matrix, row, ref col, ref countSwords);
                            Teleport(matrix, ref row, ref col, ref countSwords, Tp1row, Tp1col, Tp2row, Tp2col);
                            areThereTeleports = false;
                        }
                        else
                        {
                            MoveRight(matrix, row, ref col, ref countSwords);
                        }
                    }
                    else //Cordinates are NOT Valid => program ends
                    {
                        matrix[row, col] = '-';
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }
                }
                else if (command == "left")
                {
                    if (AreValidCoordinates(matrix, row, col - 1))
                    {
                        if (areThereTeleports && matrix[row, col - 1] == 'M') //ako ima teleport na sledvashtata poziciq
                        {
                            MoveLeft(matrix, row, ref col, ref countSwords);
                            Teleport(matrix, ref row, ref col, ref countSwords, Tp1row, Tp1col, Tp2row, Tp2col);
                            areThereTeleports = false;
                        }
                        else
                        {
                            MoveLeft(matrix, row, ref col, ref countSwords);
                        }
                    }
                    else //Cordinates are NOT Valid => program ends
                    {
                        matrix[row, col] = '-';
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }
                }

                // Console.WriteLine();
                // PrintMatrix(matrix);
                // Console.WriteLine($"countSwords: {countSwords}");

            }

            //Console.WriteLine();
            //Console.WriteLine();
            Console.WriteLine($"The king paid {countSwords} gold coins.");
            //Console.WriteLine();
            PrintMatrix(matrix);
        }

        static void Teleport(char[,] matrix, ref int row, ref int col, ref int countMoney, int Tp1row, int Tp1col, int Tp2row, int Tp2col)
        {
            if (row == Tp1row && col == Tp1col) //we are on Tp1
            {
                matrix[row, col] = '-';
                row = Tp2row;
                col = Tp2col;
            }
            else if (row == Tp2row && col == Tp2col) //we are on Tp2
            {
                matrix[row, col] = '-';
                row = Tp1row;
                col = Tp1col;
            }
            matrix[row, col] = 'A';
        }
        static void MoveUp(char[,] matrix, ref int row, int col, ref int countMoney)
        {
            matrix[row, col] = '-';
            row--;
            if (Char.IsDigit(matrix[row, col]))  //add the number
            {
                countMoney += (matrix[row, col] - '0');
            }
            matrix[row, col] = 'A';
        }

        static void MoveDown(char[,] matrix, ref int row, int col, ref int countMoney)
        {
            matrix[row, col] = '-';
            row++;
            if (Char.IsDigit(matrix[row, col]))  //add the number
            {
                countMoney += (matrix[row, col] - '0');
            }
            matrix[row, col] = 'A';
        }

        static void MoveRight(char[,] matrix, int row, ref int col, ref int countMoney)
        {
            matrix[row, col] = '-';
            col++;
            if (Char.IsDigit(matrix[row, col]))  //add the number
            {
                countMoney += (matrix[row, col] - '0');
            }
            matrix[row, col] = 'A';
        }

        static void MoveLeft(char[,] matrix, int row, ref int col, ref int countMoney)
        {
            matrix[row, col] = '-';
            col--;
            if (Char.IsDigit(matrix[row, col]))  //add the number
            {
                countMoney += (matrix[row, col] - '0');
            }
            matrix[row, col] = 'A';
        }
        static (int, int) GetTeleport1(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'M')
                    {
                        return (i, j);
                    }
                }
            }

            return (-1, -1);
        }

        static (int, int) GetTeleport2(char[,] matrix, int tp1row, int tp1col)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'M' && i != tp1row && j != tp1col)
                    {
                        return (i, j);
                    }
                }
            }

            return (-1, -1);
        }

        static (int, int) GetPlayerPosition(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'A')
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
