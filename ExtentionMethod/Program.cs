using System;

namespace ExtentionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any to exit....");
        }
    }

    public class Calculator
    {
        public float Add(int a, int b) 
        {
            return a + b;
        }

        public float Subtract(int a, int b)
        {
            return a - b;
        }


    }
}
