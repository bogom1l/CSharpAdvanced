using System;
using System.Linq;
using System.Collections.Generic;


namespace _6._Reverse_and_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int numberToDevide = int.Parse(Console.ReadLine());

            Action<List<int>> removeNumbersFromList = myList => myList.RemoveAll(x => x % numberToDevide == 0);
            Action<List<int>> reverseList = myList => myList.Reverse();
            Action<List<int>> printList = myList => Console.WriteLine(string.Join(" ", myList));

            removeNumbersFromList(numbers);
            reverseList(numbers);
            printList(numbers);

        }
    }
}
