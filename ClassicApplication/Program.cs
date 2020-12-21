using System;
using SuperFizzBuzz;

namespace ClassicApplication
{
    class Program
    {
        public static void Main(string[] args)
        {
            var fizzBuzz = new FizzBuzz();

            var results = fizzBuzz.CalculateRange();

            foreach(var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
