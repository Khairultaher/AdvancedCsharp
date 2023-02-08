using System.Collections.Concurrent;

List<int> numbers = Enumerable.Range(1, 100).ToList();
using IEnumerator<int> enumerator = numbers.GetEnumerator();

//Parallel.ForEachAsync(numbers, async (num, CancellationToken) =>
//{
//    await Task.Delay(10);
//    Console.WriteLine(num);
//});


//int[] nums = new int[] { 1, 2, 3, 4, 5 };
//int[] slice = new int[3];
//Array.Copy(nums, 1, slice, 0, 3);

//foreach (int num in slice)
//{
//    Console.WriteLine(num);
//}

List<int> nums = new List<int> { 1, 2, 3, 4, 5 };
List<int> slice = numbers.GetRange(1, 3);
slice[0] = 6;

foreach (int num in slice)
{
    Console.WriteLine(num);
}

foreach (int num in nums)
{
    Console.WriteLine(num);
}

Console.ReadLine();
