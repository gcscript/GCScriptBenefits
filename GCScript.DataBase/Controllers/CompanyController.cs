using GCScript.DataBase.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GCScript.DataBase.Controllers;

public class CompanyController
{
    private readonly IMongoCollection<MCompany> _companyCollection;
    public CompanyController()
    {
        string connectionString = $"mongodb+srv://{SettingsDB.MongoDbUsername}:{SettingsDB.MongoDbPassword}@cluster0.vfegmlt.mongodb.net/?retryWrites=true&w=majority";
        var mongoClient = new MongoClient(connectionString);
        var mongoDatabase = mongoClient.GetDatabase(SettingsDB.MongoDbDatabase);
        _companyCollection = mongoDatabase.GetCollection<MCompany>("Company");
    }

    public async Task<bool> InsertOneAsync(MCompany company)
    {
        try { await _companyCollection.InsertOneAsync(company); return true; }
        catch { return false; }
    }

    public async Task<bool> InsertManyAsync(List<MCompany> companies)
    {
        try { await _companyCollection.InsertManyAsync(companies); return true; }
        catch { return false; }
    }

    public async Task<bool> UpdateAsync(MCompany company)
    {
        var updateResult = await _companyCollection.ReplaceOneAsync(filter: g => g.Id == company.Id, replacement: company);
        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    public async Task<bool> DeleteAsync(ObjectId id)
    {
        var filter = Builders<MCompany>.Filter.Eq(m => m.Id, id);
        var deleteResult = await _companyCollection.DeleteOneAsync(filter);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

    public async Task<MCompany?> GetAsync(ObjectId id)
    {
        var filter = Builders<MCompany>.Filter.Eq(m => m.Id, id);
        return await _companyCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<MCompany?> GetAsync(string name)
    {
        var filter = Builders<MCompany>.Filter.Eq(m => m.Name, name);
        return await _companyCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<List<MCompany>> GetAllAsync()
    {
        return await _companyCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<ObjectId> GetObjectIdByNameAsync(string name)
    {
        try
        {
            var filter = Builders<MCompany>.Filter.Eq(m => m.Name, name);
            var projection = Builders<MCompany>.Projection.Include(x => x.Id);
            var result = await _companyCollection.Find(filter).Project<BsonDocument>(projection).FirstOrDefaultAsync();
            if (result == null) return ObjectId.Empty;
            return result["_id"].AsObjectId;
        }
        catch
        {
            return ObjectId.Empty;
        }
    }

    public async Task<string> GetNameByObjectIdAsync(ObjectId objectId){
        try
        {
            //var filter = Builders<MCompany>.Filter.Eq(m => m.Id, objectId);
            //var projection = Builders<MCompany>.Projection.Include(x => x.Name);
            //var result = await _companyCollection.Find(filter).Project<MCompany>(projection).FirstOrDefaultAsync();
            //if (result == null) return string.Empty;
            //return result.Name;

            var filter = Builders<MCompany>.Filter.Eq(m => m.Id, objectId);
            var projection = Builders<MCompany>.Projection.Include(x => x.Name);
            var result = await _companyCollection.Find(filter).Project<MCompany>(projection).FirstOrDefaultAsync();
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
        var projection = Builders<MCompany>.Projection.Include(x => x.Name);

        var resultado = await _companyCollection.Find(new BsonDocument()).Project<MCompanyResponse>(projection).ToListAsync();

        return resultado.Select(x => x.Name).ToList();

    }
}
