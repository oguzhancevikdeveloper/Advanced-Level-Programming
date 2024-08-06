namespace Lecture_4;

public class Database
{
    static string _connectionString;

    public static bool operator +(Database database, DatabaseType databaseType)
    {
        _connectionString = databaseType switch
        {
            DatabaseType.Oracle =>"",
            DatabaseType.MySQL =>"",
            DatabaseType.PostgreSQL =>"",
            DatabaseType.SQLServer =>""
             _ => throw new ArgumentOutOfRangeException(nameof(databaseType), "Unsupported database type.")
        };

        OpenConnection(_connectionString);

        return true;
    }

    static bool OpenConnection(string connectionString)
    {
        return true;
    }
}
public enum DatabaseType
{
    Oracle,
    MySQL,
    PostgreSQL,
    SQLServer
}