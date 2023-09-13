using GCScript.Shared.Models;

namespace GCScript.Server.Repositories;

public interface IOperatorRepository
{
    // CRUD - Create, Read, Update, Delete
    List<MOperator> GetOperators();
    MOperator GetOperator(Guid id);
    void CreateOperator(MOperator @operator);
    void UpdateOperator(MOperator @operator);
    void DeleteOperator(MOperator @operator);
}
