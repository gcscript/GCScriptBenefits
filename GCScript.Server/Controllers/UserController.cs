using GCScript.Server.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GCScript.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repository;

    public UserController(IUserRepository repository) { _repository = repository; }

    [HttpGet]
    public async Task<ActionResult<List<MUser>>> GetUsers() => await _repository.GetUsers();

    [HttpGet("{id}")]
    public async Task<ActionResult<MUser>> GetUser(int id) => await _repository.GetUser(id);

    [HttpPost]
    public async Task<ActionResult<MUser>> CreateUser(MUser user) => await _repository.CreateUser(user);

    [HttpPut]
    public async Task<ActionResult<bool>> UpdateUser(MUser user) => await _repository.UpdateUser(user);

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteUser(int id) => await _repository.DeleteUser(id);
}
