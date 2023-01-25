/*
 * It is a behavioral pattern that allows passing requests along a dynamic chain of objects, 
 * avoiding coupling the sender of a request to its receiver.
*/

TenPercentDiscountHandler tenPercent = new TenPercentDiscountHandler();
TwentyPercentDiscountHandler twentyPercent = new TwentyPercentDiscountHandler();
FiftyDollarDiscountHandler fiftyDollar = new FiftyDollarDiscountHandler();
InvalidDiscountHandler invalid = new InvalidDiscountHandler();
tenPercent.SetNext(twentyPercent);
twentyPercent.SetNext(fiftyDollar);
fiftyDollar.SetNext(invalid);

double price = 100;
string code = "20PERCENT";
tenPercent.HandleDiscountCode(code, price);


abstract class DiscountCodeHandler
{
    protected DiscountCodeHandler _next = null!;
    public void SetNext(DiscountCodeHandler next)
    {
        _next = next;
    }
    public abstract void HandleDiscountCode(string code, double price);
}

class TenPercentDiscountHandler : DiscountCodeHandler
{
    public override void HandleDiscountCode(string code, double price)
    {
        if (code == "10PERCENT")
        {
            double discount = price * 0.1;
            Console.WriteLine("10% discount applied, new price: " + (price - discount));
        }
        else
        {
            _next.HandleDiscountCode(code, price);
        }
    }
}

class TwentyPercentDiscountHandler : DiscountCodeHandler
{
    public override void HandleDiscountCode(string code, double price)
    {
        if (code == "20PERCENT")
        {
            double discount = price * 0.2;
            Console.WriteLine("20% discount applied, new price: " + (price - discount));
        }
        else
        {
            _next.HandleDiscountCode(code, price);
        }
    }
}

class FiftyDollarDiscountHandler : DiscountCodeHandler
{
    public override void HandleDiscountCode(string code, double price)
    {
        if (code == "50DOLLAR")
        {
            double discount = 50;
            if (price - discount < 0)
            {
                discount = price;
            }
            Console.WriteLine("$50 discount applied, new price: " + (price - discount));
        }
        else
        {
            _next.HandleDiscountCode(code, price);
        }
    }
}

class InvalidDiscountHandler : DiscountCodeHandler
{
    public override void HandleDiscountCode(string code, double price)
    {
        Console.WriteLine("Invalid discount code, no discount applied, price: " + price);
    }
}

