using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Staircase()
        {
            int n = 6;

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= n; i++)
            {
                var a = string.Empty.PadRight(n - i, ' ') + string.Empty.PadRight(i, '#');
                sb.Append(a);
                if (i < n)
                {
                    sb.Append(Environment.NewLine);
                }

            }
            Console.WriteLine(sb);
        }


        [Test]
        public void MiniMaxSum()
        {
            int[] arr = new int[] { 5, 5, 5, 5, 5 };
            int length = arr.Length;
            Int64 maxFinal = 0;
            Int64 minFinal = 0;
            for (int i = 0; i < length; i++)
            {
                Int64 max = 0;
                Int64 min = 0;
                for (int j = 0; j < length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    max += arr[j];
                    min += arr[j];
                }
                if (maxFinal == 0 && minFinal == 0)
                {
                    maxFinal = max;
                    minFinal = min;
                }
                if (maxFinal < max)
                {
                    maxFinal = max;
                }
                if (min < minFinal)
                {
                    minFinal = min;
                }
            }

            Console.WriteLine(minFinal.ToString() + " " + maxFinal.ToString());

            //Check before commit
            Assert.AreEqual(minFinal, 20);
            Assert.AreEqual(maxFinal, 20);
        }

        [Test]
        public void BirthdayCakeCandles()
        {
            int[] ar = new int[] { 3, 2, 1, 3 };

            var arr = ar.OrderByDescending(x => x).ToArray();

            int length = arr.Length;
            int maxGlobal = arr[0];
            int maxCount = 0;
            for (int i = 0; i < length; i++)
            {
                int maxLocal = arr[i];
                if (maxGlobal == maxLocal)
                {
                    maxGlobal = arr[i];
                    maxCount++;
                }
            }

            Console.WriteLine(maxCount);
            Assert.AreEqual(maxCount, 2);

        }

        [Test]
        public void TimeConversion()
        {
            string s = "07:05:45PM";
            s = Convert.ToDateTime(s).ToString("HH:mm:ss");
            Assert.AreEqual(s, "19:05:45");
        }

        [Test]
        public void GradingStudents()
        {
            List<int> grades = new List<int> { 4,73,67,38,33};

            for (int i = 0; i < grades.Count(); i++)
            {
                if (grades[i] >= 38)
                {
                    if (grades[i] + (5 - grades[i] % 5) - grades[i] < 3)
                    {
                        grades[i] = (grades[i] + (5 - grades[i] % 5));
                    }
                        
                }
            }

            Assert.AreEqual(1,1);
        }
    }
}