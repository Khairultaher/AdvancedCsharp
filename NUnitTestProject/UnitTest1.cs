using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int find_it(int[] seq)
            {
                var myDict = new Dictionary<string, int>();
                foreach (var item in seq)
                {
                    if (myDict.ContainsKey(item.ToString()))
                    {
                        myDict[item.ToString()] += 1;
                    }
                    else
                    {
                        myDict.Add(item.ToString(), 1);
                    }
                }
                foreach (var item in myDict)
                {
                    if (item.Value % 2 != 0)
                    {
                        return int.Parse(item.Key);
                    }
                }
                return -1;
            }
            Assert.AreEqual(5, find_it(new[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 }));
        }

        [Test]
        public void DiagonalDifference()
        {
            List<List<int>> arr = new List<List<int>>
            {
                new List<int>(){11, 2, 4 },
                new List<int>(){ 4 ,5, 6},
                new List<int>(){ 10, 8, - 12 }
            };

            int left = 0;
            int right = 0;
            int itemCount = arr.Count - 1;
            int j = itemCount;
            for (int i = 0; i <= itemCount; i++)
            {
                left += arr[i][i];
                right += arr[i][j - i];
            }

            Assert.AreEqual(15, Math.Abs(((left - right))));
        }

        // Complete the plusMinus function below.
        [Test]
        public void PlusMinus()
        {
            int[] arr = new int[] { -4, 3, -9, 0, 4, 1 };

            decimal positives = 0;
            decimal negatives = 0;
            decimal zeros = 0;

            int arrLength = arr.Length;
            foreach (var item in arr)
            {
                if (item > 0)
                {
                    positives++;
                }
                else if (item < 0)
                {
                    negatives++;
                }
                else
                {
                    zeros++;
                }
            }

            var p = (positives / arrLength).ToString("0.######");
            var n = (negatives / arrLength).ToString("0.######");
            var z = (zeros / arrLength).ToString("0.######");

            Console.WriteLine(p);
            Console.WriteLine(n);
            Console.WriteLine(z);

            Assert.AreEqual("0.500000", p);
            Assert.AreEqual("0.333333", n);
            Assert.AreEqual("0.166667", z);

        }

        // Complete the staircase function below.
        [Test]
        public void staircase()
        {
            int n = 6;

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= n; i++)
            {
                var a = string.Empty.PadRight(n-i, ' ') + string.Empty.PadRight(i, '#');
                sb.Append(a);
                if (i<n)
                {
                    sb.Append(Environment.NewLine);
                }
                
            }
            Console.WriteLine(sb);
        }



    }
}