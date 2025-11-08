using ARCAERP.Domain.Entities;

namespace ARCAERP.Application.Interfaces;

public interface ICompanyService
{
    Task<IEnumerable<Company>> GetCompanies();
    Task<Company> GetCompany(int id);
    Task<Company> CreateCompany(Company company);
}
