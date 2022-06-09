using System;
using System.Collections.Generic;
using System.Linq;

namespace Box
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split();
            string fullName = $"{personInfo[0]} {personInfo[1]}";
            string address = personInfo[2];
            string town = personInfo.Length > 4 ? $"{personInfo[3]} {personInfo[4]}" : $"{personInfo[3]}";

            string[] nameAndBeer = Console.ReadLine().Split();
            string name = nameAndBeer[0];
            int numberOfLiters = int.Parse(nameAndBeer[1]);
            string drunkOrNot = nameAndBeer[2];
            bool isDrunk = true;
            if (drunkOrNot == "not")
            {
                isDrunk = false;
            }

            string[] numbersInput = Console.ReadLine().Split();
            string nameBanker = numbersInput[0];
            double doubleNum = double.Parse(numbersInput[1]);
            string bankName = numbersInput[2];

            Threeuple<string, string, string> firstTuple = new Threeuple<string, string, string>(fullName, address, town);
            Threeuple<string, int, bool> secondTuple = new Threeuple<string, int, bool>(name, numberOfLiters, isDrunk);
            Threeuple<string, double, string> thirdTuple = new Threeuple<string, double, string>(nameBanker, doubleNum, bankName);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
