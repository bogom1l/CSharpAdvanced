using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();
            Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();

            string vloggerName = string.Empty;
            string vloggerName1 = string.Empty;
            string vloggerName2 = string.Empty;

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                if (input.Contains("joined")) //"{vloggername}" joined The V-Logger 
                {
                    vloggerName = input.Split(" joined")[0];
                    
                    //if (dict.ContainsKey(vloggerName))
                    //{
                    //    break;
                    //}

                    set.Add(vloggerName);
                    
                }
                else if(input.Contains("followed")) //"{vloggername} followed {vloggername}" 
                {
                    vloggerName1 = input.Split(" followed ")[0];
                    vloggerName2 = input.Split(" followed ")[1];

                    if (!dict.ContainsKey(vloggerName1))
                    {
                        continue;
                    }
                    if (!dict.ContainsKey(vloggerName2))
                    {
                        continue;
                    }
                    if (vloggerName1 == vloggerName2)
                    {
                        continue;
                    }

                }


                input = Console.ReadLine();
            }

            Console.WriteLine($"The V - Logger has a total of {set.Count} vloggers in its logs.");
            foreach (var item in set)
            {
                Console.WriteLine(item);
            }


        }
    }
}
