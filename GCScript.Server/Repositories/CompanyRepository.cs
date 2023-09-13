namespace GCScript.Server.Repositories;

public class CompanyRepository : ICompanyRepository
{
    public static List<MCompany> _db = new List<MCompany>();
    public List<MCompany> GetCompanies()
    {
        return _db;
    }

    public MCompany GetCompany(Guid id)
    {
        return _db.Find(x => x.Id == id)!;
    }

    public void CreateCompany(MCompany company)
    {
        _db.Add(company);
    }

    public void UpdateCompany(MCompany company)
    {
        _db.Remove(company);
        _db.Add(company);
    }

    public void DeleteCompany(Guid id)
    {
        _db.Remove(GetCompany(id));
    }
}
