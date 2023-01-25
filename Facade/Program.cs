/*
 * It is a structural pattern that provides a simplified interface to a complex system of classes, 
 * hiding the underlying complexity.
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