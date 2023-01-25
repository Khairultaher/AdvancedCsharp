/*
 * It is a structural pattern that allows objects with incompatible interfaces to work together 
 * by wrapping an instance of one class with an adapter class that conforms to the interface of the other class.
 */

IDatabase database = new DatabaseAdapter(new LegacyDatabase());
database.Connect();
database.Execute("SELECT * FROM users");
database.Disconnect();

/// <summary>
/// using interface
/// </summary>
class LegacyDatabase
{
    public void Connect()
    {
        Console.WriteLine("Connecting to legacy database...");
    }

    public void Disconnect()
    {
        Console.WriteLine("Disconnecting from legacy database...");
    }

    public void Execute(string query)
    {
        Console.WriteLine("Executing query: " + query + " on legacy database...");
    }
}

interface IDatabase
{
    void Connect();
    void Disconnect();
    void Execute(string query);
}

class DatabaseAdapter : IDatabase
{
    private LegacyDatabase _legacyDatabase;

    public DatabaseAdapter(LegacyDatabase legacyDatabase)
    {
        _legacyDatabase = legacyDatabase;
    }

    public void Connect()
    {
        _legacyDatabase.Connect();
    }

    public void Disconnect()
    {
        _legacyDatabase.Disconnect();
    }

    public void Execute(string query)
    {
        _legacyDatabase.Execute(query);
    }
}

/// <summary>
/// using inheritance
/// </summary>
class BitmapImage
{
    public virtual void Draw()
    {
        Console.WriteLine("Drawing image using Bitmap");
    }
}
class JpegImage
{
    public void Decode()
    {
        Console.WriteLine("Decoding JPEG image");
    }
}

class JpegAdapter : BitmapImage
{
    private JpegImage _jpegImage;
    public JpegAdapter(JpegImage jpegImage)
    {
        _jpegImage = jpegImage;
    }
    public override void Draw()
    {
        _jpegImage.Decode();
        base.Draw();
    }
}


