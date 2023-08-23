using GCScript.DataBase.Data;
using GCScript.DataBase.Models;
using GCScript.DataBase.ViewModels;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GCScript.DataBase.Controllers;

public class DataMenuController
{
    private readonly IMongoDBContext dbContext = new MongoDBContext();
    public async Task<List<VMDataMenu>> GetAllAsyncByCompanyName(string companyName)
    {
        for (int i = 0; i < 3; i++)
        {
            try
            {
                var filter = Builders<MDataMenu>.Filter.Eq(x => x.Company, companyName);
                var list = await dbContext.DataMenuCollection.Find(filter).ToListAsync();
                return list.Select(x => new VMDataMenu
                {
                    UF = x.UF,
                    Operator = x.Operator,
                    Company = x.Company,
                    Unit = x.Unit,
                    UnitId = x.UnitId.ToString()
                }).ToList();
            }
            catch { }
        }
        throw new Exception("Erro ao buscar dados no banco de dados");
    }
}
