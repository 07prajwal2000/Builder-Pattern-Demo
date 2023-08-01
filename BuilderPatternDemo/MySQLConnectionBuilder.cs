using System.Text;

namespace BuilderPatternDemo;

public sealed class MySqlConnectionBuilder : IMySqlConnectionBuilder
{
    private readonly StringBuilder _stringBuilder = new();
    private MySqlConnectionBuilder()
    {
        
    }
    public static IMySqlPasswordConstructor FromUsername(in string username)
    {
        var builder = new MySqlConnectionBuilder();
        builder._stringBuilder.AppendFormat("uid={0};", username);
        return builder;
    }
    
    public IMySqlHostConstructor WithPassword(in string password)
    {
        _stringBuilder.AppendFormat("pwd={0};", password);
        return this;
    }

    public IMySqlPortConstructor HasHost(in string host)
    {
        _stringBuilder.AppendFormat("server={0};", host);
        return this;
    }

    public IMySqlDatabaseConstructor HavingPort(in int port)
    {
        _stringBuilder.AppendFormat("port={0};", port);
        return this;
    }

    public IMySqlFinalConfigBuilder ContainsDatabase(in string dbName)
    {
        _stringBuilder.AppendFormat("database={0};", dbName);
        return this;
    }

    public string Build()
    {
        return _stringBuilder.ToString();
    }
}

public interface IMySqlConnectionBuilder : IMySqlPasswordConstructor, IMySqlHostConstructor,
    IMySqlPortConstructor, IMySqlFinalConfigBuilder, IMySqlDatabaseConstructor { }


public interface IMySqlPasswordConstructor
{
    IMySqlHostConstructor WithPassword(in string password);
}

public interface IMySqlHostConstructor
{
    IMySqlPortConstructor HasHost(in string host);
}

public interface IMySqlPortConstructor
{
    IMySqlDatabaseConstructor HavingPort(in int port);
}

public interface IMySqlDatabaseConstructor
{
    IMySqlFinalConfigBuilder ContainsDatabase(in string databaseName);
}
public interface IMySqlFinalConfigBuilder
{
    string Build();
}