using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230617
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,int> animal = new Dictionary<string,int>();

            animal.Add("cat", 1);
            animal.Add("dog", 3);
            animal.Add("mouse", 7);
            animal.Add("cow", 11);

            foreach(var item in animal.Values) 
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            foreach (var item in animal.Keys)
            {
                Console.WriteLine(item);
            }
        }
    }
}
