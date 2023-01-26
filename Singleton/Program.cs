/*
 * The Singleton pattern is a creational design pattern that ensures a class has only one instance, 
 * while providing a global access point to this instance. It is used to ensure that a class only has one instance, 
 * while providing a global access point to this instance.
 * 
 * The singleton pattern restricts the initialization of a class to ensure that only one instance of the class can be created.
 */

Singleton singleton = Singleton.Instance;
singleton.DoSomething();


class Singleton
{
    private static Singleton? _instance;
    private static readonly object _lock = new object();

    private Singleton()
    {
        // private constructor to prevent external instantiation
    }

    public static Singleton Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }
    }

    public void DoSomething()
    {
        Console.WriteLine("Singleton is doing something...");
    }
}


public sealed class LazySingleton
{
    private static readonly Lazy<LazySingleton> lazy = new Lazy<LazySingleton>(() => new LazySingleton());
    public static LazySingleton Instance { get { return lazy.Value; } }

    private LazySingleton(){}
}


