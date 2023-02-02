/*
 * The Facade pattern is a design pattern used in software development to provide a simplified interface 
 * to a complex system. It provides a single, simplified interface to a set of interfaces in a subsystem, 
 * hiding the implementation details of the subsystem from the client.
 * 
 * Creating a wrapper interfaces on top of existing interfaces to help client applications.
*/

Order order = new Order();
order.PlaceOrder();
Console.Read();

public class Product
{
    public void GetProductDetails()
    {
        Console.WriteLine("Fetching the Product Details");
    }
}

public class Payment
{
    public void MakePayment()
    {
        Console.WriteLine("Payment Done Successfully");
    }
}

public class Invoice
{
    public void Sendinvoice()
    {
        Console.WriteLine("Invoice Send Successfully");
    }
}

public class Order
{
    public void PlaceOrder()
    {
        Console.WriteLine("Place Order Started");
        Product product = new Product();
        product.GetProductDetails();
        Payment payment = new Payment();
        payment.MakePayment();
        Invoice invoice = new Invoice();
        invoice.Sendinvoice();
        Console.WriteLine("Order Placed Successfully");
    }
}