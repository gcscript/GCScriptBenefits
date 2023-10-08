using GCScript.Database.MongoDB.Data;
using GCScript.Database.MongoDB.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GCScript.Database.MongoDB.DataAccess;

public class OperatorDataAccess
{
    private readonly IMongoDBContext dbContext = new MongoDBContext();
    //private readonly IMongoClient mongoClient = new MongoClient(SettingsDB.MongoDbConnectionString);

    public async Task<bool> InsertOneAsync(MOperator @operator)
    {
        try { await dbContext.OperatorCollection.InsertOneAsync(@operator); return true; }
        catch { return false; }
    }

    public async Task<bool> InsertManyAsync(List<MOperator> operators)
    {
        try { await dbContext.OperatorCollection.InsertManyAsync(operators); return true; }
        catch { return false; }
    }

    public async Task<bool> UpdateAsync(MOperator @operator)
    {
        var updateResult = await dbContext.OperatorCollection.ReplaceOneAsync(filter: g => g.Id == @operator.Id, replacement: @operator);
        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    public async Task<bool> DeleteAsync(ObjectId id)
    {
        var filter = Builders<MOperator>.Filter.Eq(m => m.Id, id);
        var deleteResult = await dbContext.OperatorCollection.DeleteOneAsync(filter);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

    public async Task<MOperator?> GetAsync(ObjectId id)
    {
        var filter = Builders<MOperator>.Filter.Eq(m => m.Id, id);
        return await dbContext.OperatorCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<MOperator?> GetAsync(string uf, string name)
    {
        var filter = Builders<MOperator>.Filter.Where(op => op.Uf == uf && op.Name == name);
        return await dbContext.OperatorCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<List<MOperator>> GetAllAsync()
    {
        return await dbContext.OperatorCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<ObjectId> GetObjectIdByUfNameAsync(string uf, string name)
    {
        try
        {
            var filter = Builders<MOperator>.Filter.Eq(m => m.Uf, uf) & Builders<MOperator>.Filter.Eq(m => m.Name, name);
            var projection = Builders<MOperator>.Projection.Include(x => x.Id);
            var result = await dbContext.OperatorCollection.Find(filter).Project<BsonDocument>(projection).FirstOrDefaultAsync();
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
            var projection = Builders<MOperator>.Projection.Include(x => x.Uf).Include(x => x.Name);
            var result = await dbContext.OperatorCollection.Find(filter).Project<MOperator>(projection).FirstOrDefaultAsync();
            if (result == null) return (string.Empty, string.Empty);
            return (result.Uf, result.Name);
        }
        catch
        {
            return (string.Empty, string.Empty);
        }
    }

    public async Task<MOperator> FindAsync(string name)
    {
        var filter = Builders<MOperator>.Filter.Eq(m => m.Name, name);
        return await dbContext.OperatorCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateNotesAsync(MOperator @operator)
    {
        try
        {
            var filter = Builders<MOperator>.Filter.Eq(m => m.Id, @operator.Id);
            var update = Builders<MOperator>.Update.Set(m => m.Notes, @operator.Notes);
            var result = await dbContext.OperatorCollection.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }
        catch { return false; }
    }
}
