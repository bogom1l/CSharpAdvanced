using System;
using System.Collections.Generic;
using System.Linq;


namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jagged = new int[rows][];
            //ReadJaggedArray(jagged);
            for (int row = 0; row < rows; row++)
            {
                jagged[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            //analyze
            for (int row = 0; row < rows - 1; row++)
            {
                if (jagged[row].Length == jagged[row + 1].Length)
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] *= 2;
                        jagged[row + 1][col] *= 2;
                    }
                }
                else
                {
                    jagged[row] = jagged[row].Select(el => el / 2).ToArray();
                    jagged[row + 1] = jagged[row + 1].Select(el => el / 2).ToArray();
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split();
                string command = tokens[0];

                if (command == "Add")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    int value = int.Parse(tokens[3]);

                    if (IndexValidator(row, jagged.Length) && IndexValidator(col, jagged[row].Length))
                    {
                        jagged[row][col] += value;
                    }

                }
                else if(command == "Subtract")
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    int value = int.Parse(tokens[3]);

                    if (IndexValidator(row, jagged.Length) && IndexValidator(col, jagged[row].Length))
                    {
                        jagged[row][col] -= value;
                    }
                }

                input = Console.ReadLine();
            }

            //PrintJaggedArray(jagged);
            foreach (int[] row in jagged)
            {
                Console.WriteLine(String.Join(' ', row));
            }
        }

        static void ReadJaggedArray(int[][] jagged)
        {
            for (int i = 0; i < jagged.Length; i++)
            {
                int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jagged[i] = new int[numbers.Length];
                for (int j = 0; j < numbers.Length; j++)
                {
                    jagged[i][j] = numbers[j];
                }
            }
        }
        static void PrintJaggedArray(int[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
        static bool IndexValidator(int index, int jaggedArrayLength)
        {
            if (index >= 0 && index < jaggedArrayLength)
            {
                return true;
            }
            return false;
        }

    }
}
