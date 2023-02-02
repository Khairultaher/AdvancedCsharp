/*
The decorator pattern and the visitor pattern are both design patterns that can be used to add new functionality to existing objects, but they have different purposes and approaches.

The decorator pattern is used to add or modify the behavior of an object dynamically, without affecting the behavior of other objects from the same class. As mentioned in my previous answer, a coffee shop example can illustrate this pattern.

On the other hand, the visitor pattern is used to separate an algorithm from an object structure on which it operates. This pattern allows you to add a new operation to the objects of an existing object structure, without changing the structure itself. A real-life example of this pattern can be found in a tax calculation system, where the tax amount depends on the type of goods being purchased. The object structure represents the different types of goods, and the visitor represents the tax calculation algorithm. The visitor can be applied to each item in the object structure to calculate the tax amount, without modifying the structure or the goods themselves.

In conclusion, the decorator pattern is used when you want to add or modify the behavior of an object dynamically, while the visitor pattern is used when you want to separate an algorithm from an object structure. Both patterns have their own advantages and can be applied in different scenarios, depending on the requirements of your project.
*/

ICoffee latte = new Latte();
latte = new WhippedCream(latte);
latte = new Syrup(latte);
Console.WriteLine(latte.Description + " $" + latte.Cost);
// Output: Latte, Whipped Cream, Syrup $5.25


IItemElement[] items = new IItemElement[]
{
            new Book(20, "Book1"),
            new Electronics(100, "Electronics1"),
            new Book(15, "Book2"),
            new Electronics(150, "Electronics2")
};

decimal totalTax = 0;
decimal totalShipping = 0;

TaxCalculationVisitor taxVisitor = new TaxCalculationVisitor();
ShippingVisitor shippingVisitor = new ShippingVisitor();

foreach (IItemElement item in items)
{
    totalTax += item.Accept(taxVisitor);
    totalShipping += item.Accept(shippingVisitor);
}

Console.WriteLine("Total Tax: $" + totalTax);
Console.WriteLine("Total Shipping: $" + totalShipping);
// Output:
// Total Tax: $22.6
// Total Shipping: $29

#region Decorator
public interface ICoffee
{
    decimal Cost { get; }
    string Description { get; }
}

public class Espresso : ICoffee
{
    public decimal Cost => 2.00m;
    public string Description => "Espresso";
}

public class Latte : ICoffee
{
    public decimal Cost => 3.50m;
    public string Description => "Latte";
}

public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee decoratedCoffee;

    public CoffeeDecorator(ICoffee coffee)
    {
        decoratedCoffee = coffee;
    }

    public virtual decimal Cost => decoratedCoffee.Cost;
    public virtual string Description => decoratedCoffee.Description;
}

public class WhippedCream : CoffeeDecorator
{
    public WhippedCream(ICoffee coffee) : base(coffee) { }

    public override decimal Cost => decoratedCoffee.Cost + 0.50m;
    public override string Description => decoratedCoffee.Description + ", Whipped Cream";
}

public class Syrup : CoffeeDecorator
{
    public Syrup(ICoffee coffee) : base(coffee) { }

    public override decimal Cost => decoratedCoffee.Cost + 0.75m;
    public override string Description => decoratedCoffee.Description + ", Syrup";
}
#endregion

#region Visitor 
public interface IItemElement
{
    decimal Accept(IShoppingCartVisitor visitor);
}

public class Book : IItemElement
{
    private decimal price;
    private string title;

    public Book(decimal price, string title)
    {
        this.price = price;
        this.title = title;
    }

    public decimal Price => price;
    public string Title => title;

    public decimal Accept(IShoppingCartVisitor visitor)
    {
        return visitor.Visit(this);
    }
}

public class Electronics : IItemElement
{
    private decimal price;
    private string name;

    public Electronics(decimal price, string name)
    {
        this.price = price;
        this.name = name;
    }

    public decimal Price => price;
    public string Name => name;

    public decimal Accept(IShoppingCartVisitor visitor)
    {
        return visitor.Visit(this);
    }
}

public interface IShoppingCartVisitor
{
    decimal Visit(Book book);
    decimal Visit(Electronics electronics);
}

public class TaxCalculationVisitor : IShoppingCartVisitor
{
    public decimal Visit(Book book)
    {
        return book.Price * 0.08m;
    }

    public decimal Visit(Electronics electronics)
    {
        return electronics.Price * 0.12m;
    }
}

public class ShippingVisitor : IShoppingCartVisitor
{
    public decimal Visit(Book book)
    {
        return book.Price * 0.05m;
    }

    public decimal Visit(Electronics electronics)
    {
        return electronics.Price * 0.10m;
    }
}

#endregion



