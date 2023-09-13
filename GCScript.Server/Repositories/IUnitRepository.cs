using GCScript.Shared.Models;

namespace GCScript.Server.Repositories;

public interface IUnitRepository
{
    // CRUD - Create, Read, Update, Delete
    List<MUnit> GetUnits();
    MUnit GetUnit(Guid id);
    void CreateUnit(MUnit unit);
    void UpdateUnit(MUnit unit);
    void DeleteUnit(MUnit unit);
}
