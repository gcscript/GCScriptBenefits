using GCScript.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace GCScript.Server.Repositories;

public class UserRepository : IUserRepository
{
    public async Task<ActionResult<MUser>> CreateUser(MUser user)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<bool>> DeleteUser(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<MUser>> GetUser(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<List<MUser>>> GetUsers()
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<bool>> UpdateUser(MUser user)
    {
        throw new NotImplementedException();
    }
}