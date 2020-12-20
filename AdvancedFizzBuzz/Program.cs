using System;
using System.Collections.Generic;
using SuperFizzBuzz;

namespace AdvancedFizzBuzz
{
    class Program
    {
        public static void Main(string[] args)
        {
            var fizzBuzz = new FizzBuzz();

            var from = -12;
            var to = 145;
            var replacementValues = new Dictionary<int, string>
            {
                {3, "Fizz"},
                {7, "Buzz"},
                {38, "Bazz"}
            };

            var results = fizzBuzz.CalculateRange(from, to, replacementValues);

            foreach(var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
