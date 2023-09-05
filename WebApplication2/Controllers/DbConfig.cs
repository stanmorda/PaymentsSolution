
public class DbConfig
{
    public string TypeOfDbProvider { get; set; }
    public string ConnectionString { get; set; }
    
    public int MaxConnections { get; set; }
    
    public const string Position = "SpecialParams:DbConfig";

    public override string ToString()
    {
        return $"TypeOfDbProvider: {TypeOfDbProvider}, ConnectionString: {ConnectionString}";
    }
}