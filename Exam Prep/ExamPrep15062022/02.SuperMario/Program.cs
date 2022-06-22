using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.SuperMario
{
    public class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());

            char[][] jagged = new char[n][];
            ReadJaggedArray(jagged);

            (int row, int col) = GetMarioCoordinates(jagged);
            bool isMarioDead = false;
            bool isPrincessSaved = false;

            string command = Console.ReadLine(); 

            while (true)
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                char action = char.Parse(tokens[0]);
                int EnemyRow = int.Parse(tokens[1]);
                int EnemyCol = int.Parse(tokens[2]);

                jagged[EnemyRow][EnemyCol] = 'B'; //Spawn Enemy   (check for valid index (not needed))

                if (action == 'W')
                {
                    MoveUp(ref jagged, ref row, col, ref lives, ref isMarioDead, ref isPrincessSaved);
                }
                else if (action == 'S')
                {
                    MoveDown(ref jagged, ref row, col, ref lives, ref isMarioDead, ref isPrincessSaved);
                }
                else if (action == 'D')
                {
                    MoveRight(ref jagged, row, ref col, ref lives, ref isMarioDead, ref isPrincessSaved);
                }
                else if (action == 'A')
                {
                    MoveLeft(ref jagged, row, ref col, ref lives, ref isMarioDead, ref isPrincessSaved);
                }

                if (isMarioDead)
                {
                    break;
                }
                if (isPrincessSaved)
                {
                    break;
                }

                 //Console.WriteLine();
                 //PrintMatrix(matrix);

                command = Console.ReadLine();
            }

            PrintJaggedArray(jagged);
        }

        static (int, int) GetMarioCoordinates(char[][] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'M')
                    {
                        return (i, j);
                    }
                }
            }
            return (0, 0);
        }
        private static void ReadJaggedArray(char[][] jagged)
        {
            for (int i = 0; i < jagged.Length; i++)
            {
                jagged[i] = Console.ReadLine().Replace(" ", string.Empty).ToCharArray();
            }
        }
        private static void PrintJaggedArray(char[][] jagged)
        {
            foreach (var row in jagged)
            {
                Console.WriteLine($"{string.Join($"{string.Empty}", row)}");
            }
        }

        static bool AreValidCoordinates(char[][] jagged, int row, int col)
        {
            if (row < 0 || row > jagged.Length - 1)
            {
                return false;
            }

            if (col < 0 || col > jagged[row].Length - 1)
            {
                return false;
            }
            return true;
        }

        static void MoveUp(ref char[][] matrix, ref int row, int col, ref int lives, ref bool isMarioDead, ref bool isPrincessSaved)
        {
            if (AreValidCoordinates(matrix, row - 1, col))
            {   
                matrix[row][col] = '-';
                row--;
                lives--;
                if (lives <= 0)
                {
                    matrix[row][col] = 'X';
                    Console.WriteLine($"Mario died at {row};{col}.");
                    isMarioDead = true;
                    return;
                }
                if (matrix[row][col] == 'B')  //if Mario meets Enemy
                {
                    lives -= 2;
                    if (lives <= 0)
                    {
                        matrix[row][col] = 'X';
                        Console.WriteLine($"Mario died at {row};{col}.");
                        isMarioDead = true;
                        return;
                    }
                }
                else if (matrix[row][col] == 'P') //if Mario saves the Princess
                {
                    matrix[row][col] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    isPrincessSaved = true;
                    return;
                }
                matrix[row][col] = 'M';
            }
            else
            {
                lives--;
                if (lives <= 0)
                {
                    matrix[row][col] = 'X';
                    Console.WriteLine($"Mario died at {row};{col}.");
                    isMarioDead = true;
                    return;
                }
            }
        }

        private static void MoveDown(ref char[][] matrix, ref int row, int col, ref int lives, ref bool isMarioDead, ref bool isPrincessSaved)
        {

            if (AreValidCoordinates(matrix, row + 1, col))
            {
                matrix[row][col] = '-';
                row++;
                lives--;
                if (lives <= 0)
                {
                    matrix[row][col] = 'X';
                    Console.WriteLine($"Mario died at {row};{col}.");
                    isMarioDead = true;
                    return;
                }
                if (matrix[row][col] == 'B')  //if Mario meets Enemy
                {
                    lives -= 2;
                    if (lives <= 0)
                    {
                        matrix[row][col] = 'X';
                        Console.WriteLine($"Mario died at {row};{col}.");
                        isMarioDead = true;
                        return;
                    }
                }
                else if (matrix[row][col] == 'P') //if Mario saves the Princess
                {
                    matrix[row][col] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    isPrincessSaved = true;
                    return;
                }
                matrix[row][col] = 'M';
            }
            else
            {
                lives--;
                if (lives <= 0)
                {
                    matrix[row][col] = 'X';
                    Console.WriteLine($"Mario died at {row};{col}.");
                    isMarioDead = true;
                    return;
                }
            }
        }

        private static void MoveRight(ref char[][] matrix, int row, ref int col, ref int lives, ref bool isMarioDead, ref bool isPrincessSaved)
        {

            if (AreValidCoordinates(matrix, row, col + 1))
            {
                matrix[row][col] = '-';
                col++;
                lives--;
                if (lives <= 0)
                {
                    matrix[row][col] = 'X';
                    Console.WriteLine($"Mario died at {row};{col}.");
                    isMarioDead = true;
                    return;
                }
                if (matrix[row][col] == 'B')  //if Mario meets Enemy
                {
                    lives -= 2;
                    if (lives <= 0)
                    {
                        matrix[row][col] = 'X';
                        Console.WriteLine($"Mario died at {row};{col}.");
                        isMarioDead = true;
                        return;
                    }
                }
                else if (matrix[row][col] == 'P') //if Mario saves the Princess
                {
                    matrix[row][col] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    isPrincessSaved = true;
                    return;
                }
                matrix[row][col] = 'M';
            }
            else
            {
                lives--;
                if (lives <= 0)
                {
                    matrix[row][col] = 'X';
                    Console.WriteLine($"Mario died at {row};{col}.");
                    isMarioDead = true;
                    return;
                }
            }
        }

        private static void MoveLeft(ref char[][] matrix, int row, ref int col, ref int lives, ref bool isMarioDead, ref bool isPrincessSaved)
        {
            if (AreValidCoordinates(matrix, row, col - 1))
            {
                matrix[row][col] = '-';
                col--;
                lives--;
                if (lives <= 0)
                {
                    matrix[row][col] = 'X';
                    Console.WriteLine($"Mario died at {row};{col}.");
                    isMarioDead = true;
                    return;
                }
                if (matrix[row][col] == 'B')  //if Mario meets Enemy
                {
                    lives -= 2;
                    if (lives <= 0)
                    {
                        matrix[row][col] = 'X';
                        Console.WriteLine($"Mario died at {row};{col}.");
                        isMarioDead = true;
                        return;
                    }
                }
                else if (matrix[row][col] == 'P') //if Mario saves the Princess
                {
                    matrix[row][col] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    isPrincessSaved = true;
                    return;
                }
                matrix[row][col] = 'M';
            }
            else
            {
                lives--;
                if (lives <= 0)
                {
                    matrix[row][col] = 'X';
                    Console.WriteLine($"Mario died at {row};{col}.");
                    isMarioDead = true;
                    return;
                }
            }
        }

    }
}
