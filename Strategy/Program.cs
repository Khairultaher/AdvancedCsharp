/*
 * It is a behavioral pattern that allows an object to change its behavior at runtime by changing its strategy.
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

