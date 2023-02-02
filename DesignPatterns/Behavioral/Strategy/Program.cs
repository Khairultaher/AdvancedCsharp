/*
 * It is a behavioral pattern that allows an object to change its behavior at runtime by changing its strategy.
 * 
 * The Strategy pattern is a design pattern used in software development to provide a way for different algorithms or behaviors to be used interchangeably. The Strategy pattern allows an object to change its behavior at runtime by delegating the behavior to a separate object. This allows the behavior of an object to be modified without changing its class.
 * 
 * Strategy pattern is used when we have multiple algorithm for a specific task and client decides the actual 
 * implementation to be used at runtime.
*/

List<int> list = new List<int> { 4, 2, 9, 6, 23, 12, 34, 0, 1 };
Sorter sorter = new Sorter();

sorter.SetSortStrategy(new mergeSort());
sorter.Sort(list);

sorter.SetSortStrategy(new quickSort());
sorter.Sort(list);



interface ISortStrategy
{
    void Sort(List<int> list);
}

class BubbleSort : ISortStrategy
{
    public void Sort(List<int> list)
    {
        Console.WriteLine("Bubble sort");
        // implementation of bubble sort algorithm
    }
}

class quickSort : ISortStrategy
{
    public void Sort(List<int> list)
    {
        Console.WriteLine("Quick sort");
        // implementation of quick sort algorithm
    }
}

class mergeSort : ISortStrategy
{
    public void Sort(List<int> list)
    {
        Console.WriteLine("Merge sort");
        // implementation of merge sort algorithm
    }
}

class Sorter
{
    private ISortStrategy _sortstrategy = null!;
    public void SetSortStrategy(ISortStrategy sortstrategy)
    {
        _sortstrategy = sortstrategy;
    }
    public void Sort(List<int> list)
    {
        _sortstrategy.Sort(list);
    }
}

