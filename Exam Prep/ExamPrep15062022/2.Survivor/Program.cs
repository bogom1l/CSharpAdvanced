using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace _2.Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] jagged = new char[n][];
            ReadJaggedArray(jagged);

            int countTokensCollected = 0;
            int countOpponentTokens = 0;

            string command = Console.ReadLine();

            while (command != "Gong")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                if (action == "Find")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);

                    if (AreValidCoordinates(jagged, row, col))
                    {
                        if (jagged[row][col] == 'T') //if there is token
                        {
                            countTokensCollected++;
                            jagged[row][col] = '-';
                        }
                    }
                }

                if (action == "Opponent")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    string direction = tokens[3];

                    if (AreValidCoordinates(jagged, row, col))
                    {
                        if (jagged[row][col] == 'T') //if there is token
                        {
                            countOpponentTokens++;
                            jagged[row][col] = '-';
                        }

                        if (direction == "up")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                MoveUp(jagged, ref row, col, ref countOpponentTokens);
                            }
                        }
                        if (direction == "down")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                MoveDown(jagged, ref row, col, ref countOpponentTokens);
                            }
                        }
                        if (direction == "right")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                MoveRight(jagged, row, ref col, ref countOpponentTokens);
                            }
                        }
                        if (direction == "left")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                MoveLeft(jagged, row, ref col, ref countOpponentTokens);
                            }
                        }


                    }

                }

                command = Console.ReadLine();
            }

            PrintJaggedArray(jagged);
            Console.WriteLine($"Collected tokens: {countTokensCollected}");
            Console.WriteLine($"Opponent's tokens: {countOpponentTokens}");
        }

        private static void ReadJaggedArray(char[][] jagged)
        {
            for (int i = 0; i < jagged.Length; i++)
            {
                jagged[i] = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            }
        }
        private static void PrintJaggedArray(char[][] jagged)
        {
            foreach (var row in jagged)
            {
                Console.WriteLine($"{string.Join(" ", row)}");
            }
        }

        static bool AreValidCoordinates(char[][] jagged, int row, int col)
        {
            if (row < 0 || row > jagged.Length)
            {
                return false;
            }

            //int neshto = jagged[row].Length - 1;

            if (col < 0 || col > jagged[row].Length - 1)
            {
                return false;
            }
            return true;
        }

        static void MoveUp(char[][] jagged, ref int row, int col, ref int countOpponentTokens)
        {
            if (AreValidCoordinates(jagged, row - 1, col))
            {
                row--;
                if (jagged[row][col] == 'T')  //if there is token
                {
                    countOpponentTokens++;
                    jagged[row][col] = '-';
                }
            }
        }

        static void MoveDown(char[][] jagged, ref int row, int col, ref int countOpponentTokens)
        {
            if (AreValidCoordinates(jagged, row + 1, col))
            {
                row++;
                if (jagged[row][col] == 'T')  //if there is token
                {
                    countOpponentTokens++;
                    jagged[row][col] = '-';
                }
            }
        }

        static void MoveLeft(char[][] jagged, int row, ref int col, ref int countOpponentTokens)
        {
            if (AreValidCoordinates(jagged, row, col - 1))
            {
                col--;
                if (jagged[row][col] == 'T')  //if there is token
                {
                    countOpponentTokens++;
                    jagged[row][col] = '-';
                }
            }
        }

        static void MoveRight(char[][] jagged, int row, ref int col, ref int countOpponentTokens)
        {
            if (AreValidCoordinates(jagged, row, col + 1))
            {
                col++;
                if (jagged[row][col] == 'T')  //if there is token
                {
                    countOpponentTokens++;
                    jagged[row][col] = '-';
                }
            }
        }


    }
}
