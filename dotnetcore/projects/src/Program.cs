using System;
using Library;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var calc = new Calc();
            Console.WriteLine(calc.Add(3, 5));
        }
    }
}
