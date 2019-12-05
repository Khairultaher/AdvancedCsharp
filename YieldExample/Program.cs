using System;
using System.Collections.Generic;

namespace YieldExample
{
    class Program
    {
        static List<int> lst;
        static void Main(string[] args)
        {
            /*
             * Custom Iteration without temp collection
             * Statefull Iteration
            */
            lst = new List<int>();
            lst.Add(1);
            lst.Add(2);
            lst.Add(3);
            lst.Add(4);
            lst.Add(5);
            Console.WriteLine("PrintDataGreaterThanInputValueWithoutYield:");
            foreach (var item in PrintDataGreaterThanInputValueWithoutYield(3))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("PrintDataGreaterThanInputValueWithYield:");
            foreach (var item in PrintDataGreaterThanInputValueWithYield(3))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("PrintDataGreaterThanInputValueWithStateFullYield:");
            foreach (var item in PrintDataGreaterThanInputValueWithStateFulYield(3))
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        private static IEnumerable<int> PrintDataGreaterThanInputValueWithStateFulYield(int inputval)
        {
            int runningTotal = 0;
            foreach (var item in lst)
            {
                if (item > inputval)
                {
                    runningTotal = runningTotal + item;
                    yield return runningTotal;
                }
            }
        }
        static IEnumerable<int> PrintDataGreaterThanInputValueWithoutYield(int inputval)
        {
            List<int> lstTemp = new List<int>();
            foreach (var item in lst)
            {
                if (item > inputval) 
                {
                    lstTemp.Add(item);
                }
            }
            return lstTemp;
        }
        static IEnumerable<int> PrintDataGreaterThanInputValueWithYield(int inputval)
        {
            foreach (var item in lst)
            {
                if (item > inputval)
                {
                    yield return item;
                }
            }
        }
    }
}
