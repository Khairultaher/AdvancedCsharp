using System;

namespace ExtentionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();           
            Console.WriteLine(calculator.Add(7, 3));
            Console.WriteLine(calculator.Multiply(7, 3));

            Console.WriteLine("Press any to exit....");
            Console.ReadLine();
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

    public static class ExtendCalculator
    {
        public static float Multiply(this Calculator calculator, int a, int b)
        {
            return a - b;
        }
    }
}
