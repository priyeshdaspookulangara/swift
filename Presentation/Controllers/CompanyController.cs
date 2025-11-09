using ARCAERP.Application.Interfaces;
using ARCAERP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ARCAERP.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
    {
        return Ok(await _companyService.GetCompanies());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Company>> GetCompany(int id)
    {
        var company = await _companyService.GetCompany(id);

        if (company == null)
        {
            return NotFound();
        }

        return Ok(company);
    }

    [HttpPost]
    public async Task<ActionResult<Company>> PostCompany(Company company)
    {
        var createdCompany = await _companyService.CreateCompany(company);
        return CreatedAtAction("GetCompany", new { id = createdCompany.Id }, createdCompany);
    }
}
