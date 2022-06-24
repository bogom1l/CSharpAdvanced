using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBattle
{
    public class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[][] jagged = new char[n][];
            ReadJaggedArray(jagged);

            (int row, int col) = GetPlayerCoordinates(jagged);
            bool isPlayerDead = false;
            bool isGameOver = false;

            string command = Console.ReadLine();

            while (true)
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];
                int EnemyRow = int.Parse(tokens[1]);
                int EnemyCol = int.Parse(tokens[2]);

                jagged[EnemyRow][EnemyCol] = 'O'; //Spawn Enemy    (not needed to check for valid index)

                if (action == "up")
                {
                    MoveUp(ref jagged, ref row, col, ref armor, ref isPlayerDead, ref isGameOver);
                }
                else if (action == "down")
                {
                    MoveDown(ref jagged, ref row, col, ref armor, ref isPlayerDead, ref isGameOver);
                }
                else if (action == "right")
                {
                    MoveRight(ref jagged, row, ref col, ref armor, ref isPlayerDead, ref isGameOver);
                }
                else if (action == "left")
                {
                    MoveLeft(ref jagged, row, ref col, ref armor, ref isPlayerDead, ref isGameOver);
                }

                if (isPlayerDead)
                {
                    break;
                }
                if (isGameOver)
                {
                    break;
                }

                //Console.WriteLine();
                //PrintMatrix(matrix);

                command = Console.ReadLine();
            }

            PrintJaggedArray(jagged);
        }

        static (int, int) GetPlayerCoordinates(char[][] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'A')
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

        static bool isDead(ref char[][] matrix, ref int row, ref int col, ref int armor, ref bool isPlayerDead)
        {
            if (armor <= 0) //isDead
            {
                matrix[row][col] = 'X';
                Console.WriteLine($"The army was defeated at {row};{col}.");
                isPlayerDead = true;
                return true;
            }

            return false;
        }

        static void MoveUp(ref char[][] matrix, ref int row, int col, ref int armor, ref bool isPlayerDead, ref bool isGameOver)
        {
            if (AreValidCoordinates(matrix, row - 1, col))
            {
                matrix[row][col] = '-';
                row--;
                armor--;
                if (isDead(ref matrix, ref row, ref col, ref armor, ref isPlayerDead))
                {
                    return;
                }
                if (matrix[row][col] == 'O')  //if Mario meets Enemy
                {
                    armor -= 2;
                    if (isDead(ref matrix, ref row, ref col, ref armor, ref isPlayerDead))
                    {
                        return;
                    }
                }
                else if (matrix[row][col] == 'M') //if Player meets Mordor (game ends)
                {
                    matrix[row][col] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    isGameOver = true;
                    return;
                }
                matrix[row][col] = 'A';
            }
            else
            {
                armor--;
                if (isDead(ref matrix, ref row, ref col, ref armor, ref isPlayerDead))
                {
                    return;
                }
            }
        }

        private static void MoveDown(ref char[][] matrix, ref int row, int col, ref int armor, ref bool isPlayerDead, ref bool isGameOver)
        {

            if (AreValidCoordinates(matrix, row + 1, col))
            {
                matrix[row][col] = '-';
                row++;
                armor--;
                if (isDead(ref matrix, ref row, ref col, ref armor, ref isPlayerDead))
                {
                    return;
                }
                if (matrix[row][col] == 'O')  //if Mario meets Enemy
                {
                    armor -= 2;
                    if (isDead(ref matrix, ref row, ref col, ref armor, ref isPlayerDead))
                    {
                        return;
                    }
                }
                else if (matrix[row][col] == 'M') //if Player meets Mordor (game ends)
                {
                    matrix[row][col] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    isGameOver = true;
                    return;
                }
                matrix[row][col] = 'A';
            }
            else
            {
                armor--;
                if (isDead(ref matrix, ref row, ref col, ref armor, ref isPlayerDead))
                {
                    return;
                }
            }
        }

        private static void MoveRight(ref char[][] matrix, int row, ref int col, ref int armor, ref bool isPlayerDead, ref bool isGameOver)
        {

            if (AreValidCoordinates(matrix, row, col + 1))
            {
                matrix[row][col] = '-';
                col++;
                armor--;
                if (isDead(ref matrix, ref row, ref col, ref armor, ref isPlayerDead))
                {
                    return;
                }
                if (matrix[row][col] == 'O')  //if Mario meets Enemy
                {
                    armor -= 2;
                    if (isDead(ref matrix, ref row, ref col, ref armor, ref isPlayerDead))
                    {
                        return;
                    }
                }
                else if (matrix[row][col] == 'M') //if Player meets Mordor (game ends)
                {
                    matrix[row][col] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    isGameOver = true;
                    return;
                }
                matrix[row][col] = 'A';
            }
            else
            {
                armor--;
                if (isDead(ref matrix, ref row, ref col, ref armor, ref isPlayerDead))
                {
                    return;
                }
            }
        }

        private static void MoveLeft(ref char[][] matrix, int row, ref int col, ref int armor, ref bool isPlayerDead, ref bool isGameOver)
        {
            if (AreValidCoordinates(matrix, row, col - 1))
            {
                matrix[row][col] = '-';
                col--;
                armor--;
                if (isDead(ref matrix, ref row, ref col, ref armor, ref isPlayerDead))
                {
                    return;
                }
                if (matrix[row][col] == 'O')  //if Mario meets Enemy
                {
                    armor -= 2;
                    if (isDead(ref matrix, ref row, ref col, ref armor, ref isPlayerDead))
                    {
                        return;
                    }
                }
                else if (matrix[row][col] == 'M') //if Player meets Mordor (game ends)
                {
                    matrix[row][col] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    isGameOver = true;
                    return;
                }
                matrix[row][col] = 'A';
            }
            else
            {
                armor--;
                if (isDead(ref matrix, ref row, ref col, ref armor, ref isPlayerDead))
                {
                    return;
                }
            }
        }

    }
}
