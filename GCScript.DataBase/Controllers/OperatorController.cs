using GCScript.DataBase.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GCScript.DataBase.Controllers;

public class OperatorController
{
    private readonly IMongoCollection<MOperator> _operatorCollection;
    public OperatorController()
    {
        string connectionString = $"mongodb+srv://{SettingsDB.MongoDbUsername}:{SettingsDB.MongoDbPassword}@cluster0.vfegmlt.mongodb.net/?retryWrites=true&w=majority";
        var mongoClient = new MongoClient(connectionString);
        var mongoDatabase = mongoClient.GetDatabase(SettingsDB.MongoDbDatabase);
        _operatorCollection = mongoDatabase.GetCollection<MOperator>("Operator");
    }

    public async Task<bool> InsertOneAsync(MOperator company)
    {
        try { await _operatorCollection.InsertOneAsync(company); return true; }
        catch { return false; }
    }

    public async Task<bool> InsertManyAsync(List<MOperator> companies)
    {
        try { await _operatorCollection.InsertManyAsync(companies); return true; }
        catch { return false; }
    }

    public async Task<bool> UpdateAsync(MOperator company)
    {
        var updateResult = await _operatorCollection.ReplaceOneAsync(filter: g => g.Id == company.Id, replacement: company);
        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    public async Task<bool> DeleteAsync(ObjectId id)
    {
        var filter = Builders<MOperator>.Filter.Eq(m => m.Id, id);
        var deleteResult = await _operatorCollection.DeleteOneAsync(filter);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

    public async Task<MOperator?> GetAsync(ObjectId id)
    {
        var filter = Builders<MOperator>.Filter.Eq(m => m.Id, id);
        return await _operatorCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<MOperator?> GetAsync(string uf, string name)
    {
        var filter = Builders<MOperator>.Filter.Where(op => op.UF == uf && op.Name == name);
        return await _operatorCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<List<MOperator>> GetAllAsync()
    {
        return await _operatorCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<ObjectId> GetObjectIdByUfNameAsync(string uf, string name)
    {
        try
        {
            var filter = Builders<MOperator>.Filter.Eq(m => m.UF, uf) & Builders<MOperator>.Filter.Eq(m => m.Name, name);
            var projection = Builders<MOperator>.Projection.Include(x => x.Id);
            var result = await _operatorCollection.Find(filter).Project<BsonDocument>(projection).FirstOrDefaultAsync();
            if (result == null) return ObjectId.Empty;
            return result["_id"].AsObjectId;
        }
        catch
        {
            return ObjectId.Empty;
        }
    }

    public async Task<(string UF, string Name)> GetUfNameByObjectIdAsync(ObjectId objectId)
    {
        try
        {
            var filter = Builders<MOperator>.Filter.Eq(m => m.Id, objectId);
            var projection = Builders<MOperator>.Projection.Include(x => x.UF).Include(x => x.Name);
            var result = await _operatorCollection.Find(filter).Project<MOperator>(projection).FirstOrDefaultAsync();
            if (result == null) return (string.Empty, string.Empty);
            return (result.UF, result.Name);
        }
        catch
        {
            return (string.Empty, string.Empty);
        }
    }

    public async Task<MOperator> FindAsync(string name)
    {
        var filter = Builders<MOperator>.Filter.Eq(m => m.Name, name);
        return await _operatorCollection.Find(filter).FirstOrDefaultAsync();
    }
}
