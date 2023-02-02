/*
 * The Visitor pattern is a design pattern used in software development to separate an algorithm from 
 * an object structure on which it operates. The Visitor pattern allows a new operation to be added to 
 * an existing object structure without modifying the classes of the elements in that structure
 * 
 * Visitor pattern is used when we have to perform an operation on a group of similar kind of Objects.
*/

Directory root = new Directory("root");
Directory home = new Directory("home");
Directory music = new Directory("music");
Directory pictures = new Directory("pictures");
File file1 = new File("file1");
File file2 = new File("file2");
root.Add(home);
home.Add(music);
home.Add(pictures);
music.Add(file1);
pictures.Add(file2);

FileSizeVisitor visitor = new FileSizeVisitor();
root.Accept(visitor);
Console.WriteLine("Total files: " + visitor.GetSize());


abstract class Entry
{
    protected string _name;
    public Entry(string name)
    {
        _name = name;
    }
    public abstract void Accept(IVisitor visitor);
}

class File : Entry
{
    public File(string name) : base(name)
    {
    }
    public override void Accept(IVisitor visitor)
    {
        visitor.VisitFile(this);
    }
}

class Directory : Entry
{
    List<Entry> _entries = new List<Entry>();
    public Directory(string name) : base(name)
    {
    }
    public override void Accept(IVisitor visitor)
    {
        visitor.VisitDirectory(this);
        foreach (var entry in _entries)
        {
            entry.Accept(visitor);
        }
    }
    public void Add(Entry entry)
    {
        _entries.Add(entry);
    }
}

interface IVisitor
{
    void VisitFile(File file);
    void VisitDirectory(Directory directory);
}

class FileSizeVisitor : IVisitor
{
    int _totalSize = 0;
    public void VisitFile(File file)
    {
        _totalSize += 1;
    }
    public void VisitDirectory(Directory directory)
    {
    }
    public int GetSize()
    {
        return _totalSize;
    }
}

