/*
 * The Composite pattern is a structural pattern that allows you to compose objects into tree structures 
 * to represent part-whole hierarchies. This pattern is used when you want to represent a complex object 
 * as a tree of simpler objects, and when you want to treat both individual objects and compositions 
 * of objects uniformly.
 * 
 * 
 * Used when we have to implement a part-whole hierarchy. For example, a diagram made of other pieces such as circle, square, triangle, etc.
*/

Document document = new Document();
document.Add(new Paragraph("This is a paragraph."));
document.Add(new Paragraph("This is another paragraph."));
List list = new List();
list.Add(new Paragraph("List item 1"));
list.Add(new Paragraph("List item 2"));
document.Add(list);
document.Display();

abstract class DocumentElement
{
    public abstract void Display();
}

class Paragraph : DocumentElement
{
    private string _text;
    public Paragraph(string text)
    {
        _text = text;
    }
    public override void Display()
    {
        Console.WriteLine("Paragraph: " + _text);
    }
}

class List : DocumentElement
{
    private List<DocumentElement> _elements;
    public List()
    {
        _elements = new List<DocumentElement>();
    }
    public void Add(DocumentElement element)
    {
        _elements.Add(element);
    }
    public void Remove(DocumentElement element)
    {
        _elements.Remove(element);
    }
    public override void Display()
    {
        Console.WriteLine("List:");
        foreach (var element in _elements)
        {
            element.Display();
        }
    }
}

class Document
{
    private List<DocumentElement> _elements;
    public Document()
    {
        _elements = new List<DocumentElement>();
    }
    public void Add(DocumentElement element)
    {
        _elements.Add(element);
    }
    public void Remove(DocumentElement element)
    {
        _elements.Remove(element);
    }
    public void Display()
    {
        Console.WriteLine("Document:");
        foreach (var element in _elements)
        {
            element.Display();
        }
    }
}

