using System;
using System.Threading;

namespace DelegetActionFunc
{
    class Program
    {
        delegate int LambdaTest(int i, int y);

        static void Main(string[] args)
        {
            LambdaTest sqr = (x, y) => x * y;
            //Console.WriteLine(sqr(2,4)); // 100

            Action<int> action = a => Console.WriteLine(a * a);
            //action(10); // 100

            Predicate<int> predicate = (a) =>
            {
                return a == 2;
            };
            //Console.WriteLine(predicate(4));

            Func<int, int, int> func = (a, b) => a * b;
            //Console.WriteLine(func(4,4));

            Calculator calculator = new Calculator();
            calculator.Minus(2, 1);

            int i = 10;
            Console.WriteLine(i.IsGreaterThan(100));

            DelelegateTesting delelegateTesting = new DelelegateTesting();
            delelegateTesting.LongRunningFunction(CallBack);

            Console.ReadLine();

            void CallBack()
            {
                Console.WriteLine("I am Finished now !");
            }
        }

        static int Squire(int num)
        {
            return num * num;
        }
    }
    public static class MoreMethod
    {
        public static int Minus(this Calculator claculator, int a, int b)
        {
            return a - b;
        }

        public static bool IsGreaterThan(this int i, int value)
        {
            return i > value;
        }
    }
    public sealed class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }

    public class DelelegateTesting
    {
        public delegate void CallBackMe(); 
        public void LongRunningFunction(CallBackMe callBackMe)
        {
            // Wait here ......
            Console.WriteLine("I am Started just now !");
            Thread.Sleep(500);
            callBackMe();

        }
    }
}
