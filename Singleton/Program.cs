/*
 * It is a creational pattern that ensures a class has only one instance, 
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

