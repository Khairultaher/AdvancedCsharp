/*
 * The Decorator pattern is a structural design pattern that allows you to add new behaviors 
 * to objects by wrapping them in decorator objects that contain these behaviors.
 * It allows you to add, remove or override behavior of an object at runtime.
 * 
 * The decorator design pattern is used to modify the functionality of an object at runtime.
*/

Document document = new SimpleDocument("This is a simple document");
document = new BoldDecorator(document);
document = new ItalicDecorator(document);
document = new UnderlineDecorator(document);
document.Display();


abstract class Document
{
    public abstract void Display();
}

class SimpleDocument : Document
{
    private string _text;
    public SimpleDocument(string text)
    {
        _text = text;
    }
    public override void Display()
    {
        Console.WriteLine(_text);
    }
}

abstract class FormatDecorator : Document
{
    protected Document _document;
    public FormatDecorator(Document document)
    {
        _document = document;
    }
}

class BoldDecorator : FormatDecorator
{
    public BoldDecorator(Document document) : base(document) { }
    public override void Display()
    {
        Console.Write("<b>");
        _document.Display();
        Console.Write("</b>");
    }
}

class ItalicDecorator : FormatDecorator
{
    public ItalicDecorator(Document document) : base(document) { }
    public override void Display()
    {
        Console.Write("<i>");
        _document.Display();
        Console.Write("</i>");
    }
}

class UnderlineDecorator : FormatDecorator
{
    public UnderlineDecorator(Document document) : base(document) { }
    public override void Display()
    {
        Console.Write("<u>");
        _document.Display();
        Console.Write("</u>");
    }
}

