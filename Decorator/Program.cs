/*
 * It is a structural pattern that allows adding new behavior to objects by placing them 
 * inside wrapper objects that contain the new behavior.
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

