using GCScript.Database.MongoDB.Data;
using GCScript.Database.MongoDB.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GCScript.Database.MongoDB.DataAccess;

public class CompanyDataAccess
{
    private readonly IMongoDBContext dbContext = new MongoDBContext();
    //private readonly IMongoClient mongoClient = new MongoClient(SettingsDB.MongoDbConnectionString);

    public async Task<bool> InsertOneAsync(MCompany company)
    {
        try { await dbContext.CompanyCollection.InsertOneAsync(company); return true; }
        catch { return false; }
    }

    public async Task<bool> InsertManyAsync(List<MCompany> companies)
    {
        try { await dbContext.CompanyCollection.InsertManyAsync(companies); return true; }
        catch { return false; }
    }

    public async Task<bool> UpdateAsync(MCompany company)
    {
        var updateResult = await dbContext.CompanyCollection.ReplaceOneAsync(filter: g => g.Id == company.Id, replacement: company);
        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    public async Task<bool> DeleteAsync(ObjectId id)
    {
        var filter = Builders<MCompany>.Filter.Eq(m => m.Id, id);
        var deleteResult = await dbContext.CompanyCollection.DeleteOneAsync(filter);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

    public async Task<MCompany?> GetAsync(ObjectId id)
    {
        var filter = Builders<MCompany>.Filter.Eq(m => m.Id, id);
        return await dbContext.CompanyCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<MCompany?> GetAsync(string name)
    {
        var filter = Builders<MCompany>.Filter.Eq(m => m.Name, name);
        return await dbContext.CompanyCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<List<MCompany>> GetAllAsync()
    {
        return await dbContext.CompanyCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<ObjectId> GetObjectIdByNameAsync(string name)
    {
        try
        {
            var filter = Builders<MCompany>.Filter.Eq(m => m.Name, name);
            var projection = Builders<MCompany>.Projection.Include(x => x.Id);
            var result = await dbContext.CompanyCollection.Find(filter).Project<BsonDocument>(projection).FirstOrDefaultAsync();
            if (result == null) return ObjectId.Empty;
            return result["_id"].AsObjectId;
        }
        catch
        {
            return ObjectId.Empty;
        }
    }

    public async Task<string> GetNameByObjectIdAsync(ObjectId objectId)
    {
        try
        {
            //var filter = Builders<MCompany>.Filter.Eq(m => m.Id, objectId);
            //var projection = Builders<MCompany>.Projection.Include(x => x.Name);
            //var result = await dbContext.CompanyCollection.Find(filter).Project<MCompany>(projection).FirstOrDefaultAsync();
            //if (result == null) return string.Empty;
            //return result.Name;

            var filter = Builders<MCompany>.Filter.Eq(m => m.Id, objectId);
            var projection = Builders<MCompany>.Projection.Include(x => x.Name);
            var result = await dbContext.CompanyCollection.Find(filter).Project<MCompany>(projection).FirstOrDefaultAsync();
            if (result == null) return string.Empty;
            return result.Name!;
        }
        catch
        {
            return string.Empty;
        }
    }

    public async Task<List<string>> GetAllCompaniesAsync()
    {
        //var projection = Builders<MCompany>.Projection.Include(x => x.Name);

        //var resultado = await dbContext.CompanyCollection.Find(new BsonDocument()).Project<MCompanyResponse>(projection).ToListAsync();

        //return resultado.Select(x => x.Name).ToList();
        return new List<string>();
    }

    public async Task<bool> UpdateNotesAsync(MCompany company)
    {
        try
        {
            var filter = Builders<MCompany>.Filter.Eq(m => m.Id, company.Id);
            var update = Builders<MCompany>.Update.Set(m => m.Notes, company.Notes);
            var result = await dbContext.CompanyCollection.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }
        catch { return false; }
    }
}
