using GCScript.Shared.Models;

namespace GCScript.Server.Repositories;

public interface ICompanyRepository
{
    // CRUD - Create, Read, Update, Delete
    List<MCompany> GetCompanies();
    MCompany GetCompany(Guid id);
    void CreateCompany(MCompany company);
    void UpdateCompany(MCompany company);
    void DeleteCompany(Guid id);
}