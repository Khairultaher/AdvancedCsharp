
using Microsoft.Data.SqlClient;

class DatabaseConnection : IDisposable
{
    private SqlConnection connection;
    private bool disposed = false;

    public DatabaseConnection(string connectionString)
    {
        connection = new SqlConnection(connectionString);
        connection.Open();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
            return;

        if (disposing)
        {
            // free other managed objects that implement IDisposable only
        }

        if (connection != null)
        {
            connection.Close();
            connection = null!;
        }

        disposed = true;
    }

    ~DatabaseConnection()
    {
        Dispose(false);
    }
}
