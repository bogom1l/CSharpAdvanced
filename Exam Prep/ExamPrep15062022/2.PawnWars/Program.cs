using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 8;
            char[,] matrix = new char[8, 8];
            ReadMatrix(matrix);
            //Console.WriteLine();
            //PrintMatrix(matrix);
            (int whiteCoordinateRow, int whiteCoordinateCol) = GetWhiteCoordinates(matrix); //Console.WriteLine($"white: {whiteCoordinateRow}, {whiteCoordinateCol}");
            (int blackCoordinateRow, int blackCoordinateCol) = GetBlackCoordinates(matrix); // Console.WriteLine($"black: {blackCoordinateRow}, {blackCoordinateCol}");

            if (Math.Abs(whiteCoordinateCol - blackCoordinateCol) == 1) //"Game over! {white/black} capture on {coordinates}."
            {
                while (true)
                {
                    //Console.WriteLine();
                    //PrintMatrix(matrix);

                    //check if White won diagonally on right
                    if (matrix[whiteCoordinateRow - 1, whiteCoordinateCol + 1] == 'b'
                        &&
                        AreValidCoordinates(matrix, whiteCoordinateRow - 1, whiteCoordinateCol + 1))
                    {
                        int ansRow = TranslateCoordinatesRow(whiteCoordinateRow - 1);
                        char ansCol = TranslateCoordinatesCol(whiteCoordinateCol + 1);
                        Console.WriteLine($"Game over! White capture on {ansCol}{ansRow}.");
                        break;
                    }
                    //check if White won diagonally on left
                    if (matrix[whiteCoordinateRow - 1, whiteCoordinateCol - 1] == 'b'
                        &&
                        AreValidCoordinates(matrix, whiteCoordinateRow - 1, whiteCoordinateCol - 1))
                    {
                        int ansRow = TranslateCoordinatesRow(whiteCoordinateRow - 1);
                        char ansCol = TranslateCoordinatesCol(whiteCoordinateCol - 1);
                        Console.WriteLine($"Game over! White capture on {ansCol}{ansRow}.");
                        break;
                    }
                    //if White didnt win -> White Move
                    if ((!WhiteMove(ref whiteCoordinateRow, whiteCoordinateCol, ref matrix))
                        && AreValidCoordinates(matrix, whiteCoordinateRow, whiteCoordinateCol))
                    {
                        break;
                    }

                    //check if Black won diagonally on right
                    if (matrix[blackCoordinateRow + 1, blackCoordinateCol + 1] == 'w'
                        &&
                        AreValidCoordinates(matrix, blackCoordinateRow + 1, blackCoordinateCol + 1))
                    {
                        int ansRow = TranslateCoordinatesRow(blackCoordinateRow + 1);
                        char ansCol = TranslateCoordinatesCol(blackCoordinateCol + 1);
                        Console.WriteLine($"Game over! Black capture on {ansCol}{ansRow}.");
                        break;
                    }
                    //check if Black won diagonally on left
                    if (matrix[blackCoordinateRow + 1, blackCoordinateCol - 1] == 'w'
                        &&
                        AreValidCoordinates(matrix, blackCoordinateRow + 1, blackCoordinateCol - 1))
                    {
                        int ansRow = TranslateCoordinatesRow(blackCoordinateRow + 1);
                        char ansCol = TranslateCoordinatesCol(blackCoordinateCol - 1);
                        Console.WriteLine($"Game over! Black capture on {ansCol}{ansRow}.");
                        break;
                    }
                    //if Black didnt win -> Black Move
                    if ((!BlackMove(ref blackCoordinateRow, blackCoordinateCol, ref matrix))
                        &&
                        AreValidCoordinates(matrix,blackCoordinateRow,blackCoordinateCol))
                    {
                        break;
                    }





                }
            }
            else //"Game over! {White/Black} pawn is promoted to a queen at {coordinates}."
            {
                while ((WhiteMove(ref whiteCoordinateRow, whiteCoordinateCol, ref matrix)
                    && (BlackMove(ref blackCoordinateRow, blackCoordinateCol, ref matrix))
                    && AreValidCoordinates(matrix, whiteCoordinateRow, whiteCoordinateCol))
                    && AreValidCoordinates(matrix, blackCoordinateRow,blackCoordinateCol))
                {
                    //Console.WriteLine();
                    //PrintMatrix(matrix);

                    if (whiteCoordinateRow == 0)
                    {
                        //Console.WriteLine();
                        //PrintMatrix(matrix);
                        int ansRow = TranslateCoordinatesRow(whiteCoordinateRow);
                        char ansCol = TranslateCoordinatesCol(whiteCoordinateCol);
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {ansCol}{ansRow}.");
                        break;
                    }
                    if (blackCoordinateRow == 7)
                    {
                        //Console.WriteLine();
                        //PrintMatrix(matrix);
                        int ansRow = TranslateCoordinatesRow(blackCoordinateRow);
                        char ansCol = TranslateCoordinatesCol(blackCoordinateCol);
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {ansCol}{ansRow}.");
                        break;
                    }
                }
            }

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

        static (int, int) GetWhiteCoordinates(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'w')
                    {
                        return (i, j);
                    }
                }
            }

            return (0, 0);
        }
        static (int, int) GetBlackCoordinates(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'b')
                    {
                        return (i, j);
                    }
                }
            }

            return (0, 0);
        }

        static bool WhiteMove(ref int row, int col, ref char[,] matrix)
        {
            matrix[row, col] = '-';
            if (row == 0)
            {
                return false;
            }
            else
            {
                row--;
                matrix[row, col] = 'w';
                return true;
            }
        }
        static bool BlackMove(ref int row, int col, ref char[,] matrix)
        {
            matrix[row, col] = '-';
            if (row == matrix.GetLength(0) - 1)
            {
                return false;
            }
            else
            {
                row++;
                matrix[row, col] = 'b';
                return true;
            }
        }

        static int TranslateCoordinatesRow(int row)
        {
            Dictionary<int, int> rows = new Dictionary<int, int>();
            rows[0] = 8;
            rows[1] = 7;
            rows[2] = 6;
            rows[3] = 5;
            rows[4] = 4;
            rows[5] = 3;
            rows[6] = 2;
            rows[7] = 1;

            return rows[row];
        }
        static char TranslateCoordinatesCol(int col)
        {
            Dictionary<int, char> cols = new Dictionary<int, char>();
            cols[0] = 'a';
            cols[1] = 'b';
            cols[2] = 'c';
            cols[3] = 'd';
            cols[4] = 'e';
            cols[5] = 'f';
            cols[6] = 'g';
            cols[7] = 'h';

            return cols[col];
        }
        static bool AreValidCoordinates(char[,] matrix, int row, int col)
        {
            return row >= 0 && row <= matrix.GetLength(0) &&
                col >= 0 && col <= matrix.GetLength(1);
        }
    }
}
