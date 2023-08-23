using GCScript.DataBase.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GCScript.DataBase.Controllers;

public class AuthenticationController
{
    private readonly IMongoDBContext dbContext = new MongoDBContext();

    public async Task<(bool Success, string Message)> Login()
    {
        try
        {
            var result = await dbContext.AuthenticationCollection.Find(new BsonDocument()).ToListAsync();
            if (result != null)
            {
                if (result.Count == 0)
                {
                    return (false, "result.Count is 0");
                }
                else if (result.Count == 1)
                {
                    return (true, "");
                }
                else
                {
                    return (false, "result.Count is more than 1");
                }

            }
            else
            {
                return (false, "result is null");
            }

        }
        catch (Exception ex)
        {
            if (ex.Message == "Unable to authenticate using sasl protocol mechanism SCRAM-SHA-1.")
            {
                return (false, "Usuário e/ou senha inválido(s)");
            }

            return (false, ex.Message);
        }
    }
}
