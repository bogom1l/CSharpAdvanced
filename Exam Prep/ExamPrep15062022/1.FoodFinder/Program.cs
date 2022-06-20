using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace _1.FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] firstInput = Console.ReadLine().Split().Select(char.Parse).ToArray();
            char[] secInput = Console.ReadLine().Split().Select(char.Parse).ToArray();

            Queue<char> queueVowels = new Queue<char>(firstInput);
            Stack<char> stackCon = new Stack<char>(secInput);

            List<char> allLettersPossible = GetAllLettersPossible(firstInput, secInput);
            List<char> allLettersFound = new List<char>();

            
            while (stackCon.Count > 0)
            {
                char currVowel = queueVowels.Peek();
                char currCon = stackCon.Peek();

                if (allLettersPossible.Contains(currVowel))
                {
                    if (!allLettersFound.Contains(currVowel))
                    {
                        allLettersFound.Add(currVowel);
                    }
                }

                if (allLettersPossible.Contains(currCon))
                {
                    if (!allLettersFound.Contains(currCon))
                    {
                        allLettersFound.Add(currCon);
                    }
                }

                queueVowels.Enqueue(currVowel);
                queueVowels.Dequeue();

                stackCon.Pop();
            }

            List<string> words = new List<string>()
            {
                "pear",
                "flour",
                "pork",
                "olive"
            };

            int cnt = 0;
            List<string> ans = new List<string>();

            bool isFound1 = false;
            foreach (char c in words[0]) //"pear"
            {
                if (allLettersFound.Contains(c))
                {
                    isFound1 = true;
                }
                else
                {
                    isFound1 = false;
                    break;
                }
            }
            if (isFound1)
            {
                cnt++;
                ans.Add(words[0]);
            }

            bool isFound2 = false;
            foreach (char c in words[1]) //"flour"
            {
                if (allLettersFound.Contains(c))
                {
                    isFound2 = true;
                }
                else
                {
                    isFound2 = false;
                    break;
                }
            }
            if (isFound2)
            {
                cnt++;
                ans.Add(words[1]);
            }
            
            bool isFound3 = false;
            foreach (char c in words[2]) //"pork"
            {
                if (allLettersFound.Contains(c))
                {
                    isFound3 = true;
                }
                else
                {
                    isFound3 = false;
                    break;
                }               
            }
            if (isFound3)
            {
                cnt++;
                ans.Add(words[2]);
            }

            bool isFound4 = false;
            foreach (char c in words[3]) //"olive"
            {
                if (allLettersFound.Contains(c))
                {
                    isFound4 = true;
                }
                else
                {
                    isFound4 = false;
                    break;
                }
            }
            if (isFound4)
            {
                cnt++;
                ans.Add(words[3]);
            }

            Console.WriteLine($"Words found: {cnt}");
            foreach (string w in ans)
            {
                Console.WriteLine(w);
            }

        }

        private static List<char> GetAllLettersPossible(char[] vowelChars, char[] conChars)
        {
            List<char> list = new List<char>();

            foreach (char c in vowelChars)
            {
                if (!list.Contains(c))
                {
                    list.Add(c);
                }
            }

            foreach (char c in conChars)
            {
                if (!list.Contains(c))
                {
                    list.Add(c);
                }
            }

            return list;
        }
    }
}
