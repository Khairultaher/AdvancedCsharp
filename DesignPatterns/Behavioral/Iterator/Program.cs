/*
 * It is a behavioral pattern that provides a way to traverse a collection of objects 
 * without exposing the underlying representation.
 * 
 * Used to provide a standard way to traverse through a group of Objects.
*/

using System.Collections;

ProductList products = new ProductList(
    new List<Product> { new Product("product1"), 
    new Product("product2"), new Product("product3") }
    );
IIterator iterator = products.CreateIterator();
while (iterator.HasNext())
{

    Product product = (Product)iterator.Next();
    Console.WriteLine(product.Name);
}


interface IIterator
{
    bool HasNext();
    object Next();
}
class Product
{
    public string Name { get; set; }
    public Product(string name)
    {
        Name = name;
    }
}

class ProductList : IEnumerable
{
    private List<Product> _products;
    public ProductList(List<Product> products)
    {
        _products = products;
    }
    public IIterator CreateIterator()
    {
        return new ProductIterator(this);
    }
    public int Count
    {
        get { return _products.Count; }
    }
    public Product this[int index]
    {
        get { return _products[index]; }
        set { _products.Insert(index, value); }
    }
    public IEnumerator GetEnumerator()
    {
        return _products.GetEnumerator();
    }
}

class ProductIterator : IIterator
{
    private ProductList _productList;
    private int _current = 0;
    public ProductIterator(ProductList productList)
    {
        _productList = productList;
    }
    public bool HasNext()
    {
        if (_current < _productList.Count)
            return true;
        else
            return false;
    }
    public object Next()
    {
        return _productList[_current++];
    }
}

