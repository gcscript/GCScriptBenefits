using GCScript.Database.MongoDB.Data;
using GCScript.Database.MongoDB.Models;
using GCScript.Database.MongoDB.ViewModels;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GCScript.Database.MongoDB.DataAccess;

public class UnitDataAccess
{
    private readonly IMongoDBContext dbContext = new MongoDBContext();
    //private readonly IMongoClient mongoClient = new MongoClient(SettingsDB.MongoDbConnectionString);

    public async Task<(bool Result, string Message)> InsertOneAsync(MUnit unit)
    {
        try { await dbContext.UnitCollection.InsertOneAsync(unit); return (true, ""); }
        catch (Exception ex) { return (false, ex.Message); }
    }

    public async Task<bool> InsertManyAsync(List<MUnit> units)
    {
        try { await dbContext.UnitCollection.InsertManyAsync(units); return true; }
        catch { return false; }
    }

    public async Task<MUnit?> GetAsync(ObjectId id)
    {
        var filter = Builders<MUnit>.Filter.Eq(m => m.Id, id);
        return await dbContext.UnitCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<string> GetCnpjAsync(string uf, string @operator, string company, string unit)
    {
        var filter = Builders<MUnit>.Filter.And(Builders<MUnit>.Filter.Eq(x => x.Uf, uf),
                                                Builders<MUnit>.Filter.Eq(x => x.Operator, @operator),
                                                Builders<MUnit>.Filter.Eq(x => x.Company, company),
                                                Builders<MUnit>.Filter.Eq(x => x.Name, unit));

        var result = await dbContext.UnitCollection.Find(filter).FirstOrDefaultAsync();
        return result != null ? result.Cnpj : "";
    }


    public async Task<bool> UpdateAsync(MUnit unit)
    {
        var filter = Builders<MUnit>.Filter.Eq(m => m.Id, unit.Id);
        var update = Builders<MUnit>.Update
            .Set(m => m.Name, unit.Name)
            .Set(m => m.Username, unit.Username)
            .Set(m => m.Password, unit.Password)
            .Set(m => m.Cnpj, unit.Cnpj);
        var result = await dbContext.UnitCollection.UpdateOneAsync(filter, update);
        return result.ModifiedCount > 0;
    }

    public async Task<(bool Success, string Message, int Count)> UpdatePasswordAsync(MUnit unit)
    {
        try
        {
            //IMongoDBContext dbContext = new MongoDBContext();
            var filter = Builders<MUnit>.Filter.And(
                Builders<MUnit>.Filter.Eq(x => x.Username, unit.Username),
                    Builders<MUnit>.Filter.Eq(x => x.Uf, unit.Uf),
                    Builders<MUnit>.Filter.Eq(x => x.Operator, unit.Operator),
                    Builders<MUnit>.Filter.Eq(x => x.Company, unit.Company));

            var update = Builders<MUnit>.Update.Set(m => m.Password, unit.Password);
            //.Set(m => m.Updated, DateTime.UtcNow);

            var result = await dbContext.UnitCollection.UpdateManyAsync(filter, update);
            return (true, "", Convert.ToInt32(result.ModifiedCount));
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("user is not allowed to do action"))
            {
                return (false, "Você não tem permissão para alterar senhas!", 0);
            }

            return (false, ex.Message, 0);
        }
    }

    //public async Task<bool> UpdateNotesAsync(MUnit unit)
    //{
    //    try
    //    {
    //        var filter = Builders<MUnit>.Filter.Eq(m => m.Id, unit.Id);
    //        var update = Builders<MUnit>.Update.Set(m => m.Notes, unit.Notes);
    //        var result = await dbContext.UnitCollection.UpdateOneAsync(filter, update);
    //        return result.ModifiedCount > 0;
    //    }
    //    catch { return false; }
    //}

    public async Task<List<VMUnitMenu>> GetAllAsyncByCompanyName(string companyName)
    {

        for (int i = 0; i < 3; i++)
        {
            try
            {
                var filter = Builders<MUnit>.Filter.Eq(x => x.Company, companyName);
                var list = await dbContext.UnitCollection.Find(filter).ToListAsync();
                return list.Select(x => new VMUnitMenu
                {
                    Uf = x.Uf,
                    Operator = x.Operator,
                    Company = x.Company,
                    Unit = x.Name,
                    UnitId = x.Id.ToString()
                }).ToList();
            }
            catch { }
        }
        throw new Exception("Erro ao buscar dados no banco de dados");
    }
    public async Task<int> RemoveNotesAsync()
    {
        try
        {
            var filter = Builders<MUnit>.Filter.Empty;
            var update = Builders<MUnit>.Update.Unset("Notes");
            var result = await dbContext.UnitCollection.UpdateManyAsync(filter, update);
            return (int)result.ModifiedCount;
        }
        catch { return 0; }
    }
}
