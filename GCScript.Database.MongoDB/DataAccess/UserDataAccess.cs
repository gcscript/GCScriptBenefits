using GCScript.Database.MongoDB.Data;
using GCScript.Database.MongoDB.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GCScript.Database.MongoDB.DataAccess;

public class UserDataAccess
{
    private readonly IMongoDBContext dbContext = new MongoDBContext();
    //private readonly IMongoClient mongoClient = new MongoClient(SettingsDB.MongoDbConnectionString);

    public async Task<bool> InsertOneAsync(MUser user)
    {
        try { await dbContext.UserCollection.InsertOneAsync(user); return true; }
        catch { return false; }
    }

    public async Task<bool> InsertManyAsync(List<MUser> users)
    {
        try { await dbContext.UserCollection.InsertManyAsync(users); return true; }
        catch { return false; }
    }

    public async Task<bool> UpdateAsync(MUser user)
    {
        var updateResult = await dbContext.UserCollection.ReplaceOneAsync(filter: g => g.Id == user.Id, replacement: user);
        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    public async Task<bool> DeleteAsync(ObjectId id)
    {
        var filter = Builders<MUser>.Filter.Eq(m => m.Id, id);
        var deleteResult = await dbContext.UserCollection.DeleteOneAsync(filter);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

    public async Task<MUser?> GetAsync(ObjectId id)
    {
        var filter = Builders<MUser>.Filter.Eq(m => m.Id, id);
        return await dbContext.UserCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<List<MUser>> GetAllAsync()
    {
        return await dbContext.UserCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<(MUser? User, string Message)> Login()
    {
        try
        {
            var filter = Builders<MUser>.Filter.Eq(m => m.Username, SettingsDB.MongoDbUsername);
            var user = await dbContext.UserCollection.Find(filter).FirstOrDefaultAsync();
            if (user == null) { return (null, "Usuário não autorizado!"); }
            return (user, "");
        }
        catch (Exception ex)
        {
            if (ex.Message == "Unable to authenticate using sasl protocol mechanism SCRAM-SHA-1.")
            {
                return (null, "Usuário e/ou senha inválido(s)!");
            }

            return (null, ex.Message);
        }
    }

}
