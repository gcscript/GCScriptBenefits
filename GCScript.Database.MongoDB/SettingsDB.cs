namespace GCScript.Database.MongoDB;

public class SettingsDB
{
    public static readonly string MongoDbDataSource = "Cluster0";
    public static readonly string MongoDbDatabase = "GCScriptBenefits";
    public static string MongoDbUsername = "";
    public static string MongoDbPassword = "";
    public static string MongoDbConnectionString = $"mongodb+srv://{MongoDbUsername}:{MongoDbPassword}@cluster0.vfegmlt.mongodb.net/?retryWrites=true&w=majority";
}
