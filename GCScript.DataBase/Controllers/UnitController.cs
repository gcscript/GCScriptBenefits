using GCScript.DataBase.Data;
using GCScript.DataBase.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GCScript.DataBase.Controllers;

public class UnitController
{

    private readonly IMongoDBContext dbContext = new MongoDBContext();
    private readonly IMongoClient mongoClient;

    public UnitController()
    {
        string connectionString = $"mongodb+srv://{SettingsDB.MongoDbUsername}:{SettingsDB.MongoDbPassword}@cluster0.vfegmlt.mongodb.net/?retryWrites=true&w=majority";
        mongoClient = new MongoClient(connectionString);
    }

    public async Task<bool> InsertOneAsync(MUnit un)
    {
        var sessionOptions = new ClientSessionOptions
        {
            DefaultTransactionOptions = new TransactionOptions(readConcern: ReadConcern.Snapshot, writeConcern: WriteConcern.WMajority)
        };

        using var session = await mongoClient.StartSessionAsync(sessionOptions);
        session.StartTransaction();
        try
        {
            await dbContext.UnitCollection.InsertOneAsync(session, un);

            var cs = new CompanyController();
            var companyName = await cs.GetNameByObjectIdAsync(un.CompanyId);
            if (string.IsNullOrEmpty(companyName))
            {
                throw new Exception("Empresa não encontrada!");
            }

            var os = new OperatorController();
            var opData = await os.GetUfNameByObjectIdAsync(un.OperatorId);
            if (string.IsNullOrEmpty(opData.UF) || string.IsNullOrEmpty(opData.Name))
            {
                throw new Exception("Operadora não encontrada!");
            }

            MDataMenu dm = new()
            {
                UF = opData.UF,
                Operator = opData.Name,
                Company = companyName,
                Unit = un.Name,
                UnitId = un.Id
            };

            await dbContext.DataMenuCollection.InsertOneAsync(session, dm);

            await session.CommitTransactionAsync();
            return true;
        }
        catch (Exception ex)
        {
            await session.AbortTransactionAsync();
            return false;
        }
    }
    public async Task<MUnit?> GetAsync(ObjectId id)
    {
        var filter = Builders<MUnit>.Filter.Eq(m => m.Id, id);
        return await dbContext.UnitCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<(MOperator? mOperator, MCompany? mCompany, MUnit? mUnit)> GetDataAsync(ObjectId unitId)
    {
        try
        {
            var mUnit = await GetAsync(unitId) ?? throw new Exception("Unidade não encontrada!");
            var mCompany = await new CompanyController().GetAsync(mUnit.CompanyId) ?? throw new Exception("Empresa não encontrada!");
            var mOperator = await new OperatorController().GetAsync(mUnit.OperatorId) ?? throw new Exception("Operadora não encontrada!");
            return (mOperator, mCompany, mUnit);
        }
        catch
        {
            return (null, null, null);
        }
    }

    public async Task<bool> UpdateAsync(MUnit mUnit)
    {
        var filter = Builders<MUnit>.Filter.Eq(m => m.Id, mUnit.Id);
        var update = Builders<MUnit>.Update
            .Set(m => m.Name, mUnit.Name)
            .Set(m => m.Username, mUnit.Username)
            .Set(m => m.Password, mUnit.Password)
            .Set(m => m.CNPJ, mUnit.CNPJ)
            .Set(m => m.Observations, mUnit.Observations);
        var result = await dbContext.UnitCollection.UpdateOneAsync(filter, update);
        return result.ModifiedCount > 0;
    }

    public async Task<(bool Success, string Message, int Count)> UpdatePasswordAsync(MUnit mUnit)
    {
        try
        {
            IMongoDBContext dbContext = new MongoDBContext();
            var filter = Builders<MUnit>.Filter.And(
                Builders<MUnit>.Filter.Eq(x => x.Username, mUnit.Username),
                    Builders<MUnit>.Filter.Eq(x => x.CompanyId, mUnit.CompanyId),
                    Builders<MUnit>.Filter.Eq(x => x.OperatorId, mUnit.OperatorId));

            var update = Builders<MUnit>.Update
                .Set(m => m.Password, mUnit.Password)
                .Set(m => m.Updated, DateTime.UtcNow);

            var result = await dbContext.UnitCollection.UpdateManyAsync(filter, update);
            return (true, "", Convert.ToInt32(result.ModifiedCount));
        }
        catch (Exception ex)
        {
            if(ex.Message.Contains("user is not allowed to do action"))
            {
                return (false, "Você não tem permissão para alterar senhas!", 0);
            }

            return (false, ex.Message, 0);
        }
    }
}
