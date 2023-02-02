/*
 * The Observer pattern is a design pattern used in software development to provide a way for objects to be notified of changes in other objects. The Observer pattern defines a one-to-many relationship between objects, where one object (the subject) is observed by many other objects (the observers). The subject maintains a list of its observers, and notifies them of changes to its state.
 * 
 * Useful when you are interested in the state of an object and want to get notified whenever there is any change.
*/

Stock googleStock = new Stock("GOOG", 100.0);
Trader trader1 = new Trader("Trader 1");
Trader trader2 = new Trader("Trader 2");
Investor investor1 = new Investor("Investor 1");
Investor investor2 = new Investor("Investor 2");
googleStock.Attach(trader1);
googleStock.Attach(trader2);
googleStock.Attach(investor1);
googleStock.Attach(investor2);
googleStock.Price = 101.0;

interface IObserver
{
    void Update(Stock stock);
}
class Trader : IObserver
{
    private string _name;
    public Trader(string name)
    {
        _name = name;
    }
    public void Update(Stock stock)
    {
        Console.WriteLine("Notified " + _name + " of " + stock.Symbol + "'s change to " + stock.Price);
    }
}
class Investor : IObserver
{
    private string _name;
    public Investor(string name)
    {
        _name = name;
    }
    public void Update(Stock stock)
    {
        Console.WriteLine("Notified " + _name + " of " + stock.Symbol + "'s change to " + stock.Price);
    }
}
class Stock
{
    private string _symbol;
    private double _price;
    private List<IObserver> _observers;
    public Stock(string symbol, double price)
    {
        _symbol = symbol;
        _price = price;
        _observers = new List<IObserver>();
    }
    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }
    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }
    public void Notify()
    {
        foreach (IObserver observer in _observers)
        {
            observer.Update(this);
        }
    }
    public double Price
    {
        get { return _price; }
        set
        {
            if (_price != value)
            {
                _price = value;
                Notify();
            }
        }
    }
    public string Symbol
    {
        get { return _symbol; }
    }
}


