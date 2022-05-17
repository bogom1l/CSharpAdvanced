using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace _9._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();

            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split();

                int command = int.Parse(tokens[0]);

                if (command == 1)
                {
                    stack.Push(text.ToString());

                    string textToAdd = tokens[1];
                    text.Append(textToAdd);                  
                }
                else if(command == 2)
                {
                    stack.Push(text.ToString());

                    int count = int.Parse(tokens[1]);
                    text.Remove(text.Length - count, count);
                }
                else if(command == 3)
                {
                    int index = int.Parse(tokens[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if(command == 4)
                {
                    text = new StringBuilder(stack.Pop());
                }

            }



        }
    }
}
