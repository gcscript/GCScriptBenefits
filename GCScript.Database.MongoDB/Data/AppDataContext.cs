﻿using GCScript.Database.MongoDB.Models;
using MongoDB.Driver;

namespace GCScript.Database.MongoDB.Data;

public interface IMongoDBContext
{
    IMongoCollection<MAuthentication> AuthenticationCollection { get; }
    IMongoCollection<MOperator> OperatorCollection { get; }
    IMongoCollection<MCompany> CompanyCollection { get; }
    IMongoCollection<MUnit> UnitCollection { get; }
    IMongoCollection<MUser> UserCollection { get; }
}

public class MongoDBContext : IMongoDBContext
{
    private readonly IMongoDatabase _db;

    public MongoDBContext()
    {
        string connectionString = $"mongodb+srv://{SettingsDB.MongoDbUsername}:{SettingsDB.MongoDbPassword}@cluster0.vfegmlt.mongodb.net/?retryWrites=true&w=majority";
        string databaseName = SettingsDB.MongoDbDatabase;

        var client = new MongoClient(connectionString);
        _db = client.GetDatabase(databaseName);
    }

    public IMongoCollection<MAuthentication> AuthenticationCollection => _db.GetCollection<MAuthentication>("Authentication");
    public IMongoCollection<MOperator> OperatorCollection => _db.GetCollection<MOperator>("Operator");
    public IMongoCollection<MCompany> CompanyCollection => _db.GetCollection<MCompany>("Company");
    public IMongoCollection<MUnit> UnitCollection => _db.GetCollection<MUnit>("Unit");
    public IMongoCollection<MUser> UserCollection => _db.GetCollection<MUser>("User");
}
