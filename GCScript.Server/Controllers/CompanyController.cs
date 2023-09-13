using GCScript.Server.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GCScript.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ICompanyRepository _repository;

    public CompanyController(ICompanyRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var listaDeEmpresas = _repository.GetCompanies();
        return Ok(listaDeEmpresas);
    }

    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        var empresa = _repository.GetCompany(id);

        if (empresa is null) return NotFound("Não encontrado!");
        return Ok(empresa);
    }

    [HttpPost]
    public IActionResult Create(MCompany company)
    {
        _repository.CreateCompany(company);
        return Ok(company);
    }

    [HttpPut]
    public IActionResult Update(MCompany company)
    {
        _repository.UpdateCompany(company);
        return Ok(company);
    }
    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        _repository.DeleteCompany(id);
        return Ok();
    }
}
