using GCScript.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace GCScript.Server.Repositories;

public interface IUserRepository
{
    Task<ActionResult<List<MUser>>> GetUsers();
    Task<ActionResult<MUser>> GetUser(int id);
    Task<ActionResult<MUser>> CreateUser(MUser user);
    Task<ActionResult<bool>> UpdateUser(MUser user);
    Task<ActionResult<bool>> DeleteUser(int id);
}