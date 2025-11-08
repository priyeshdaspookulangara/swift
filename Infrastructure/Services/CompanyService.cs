using ARCAERP.Application.Interfaces;
using ARCAERP.Domain.Entities;
using ARCAERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ARCAERP.Infrastructure.Services;

public class CompanyService : ICompanyService
{
    private readonly ApplicationDbContext _context;

    public CompanyService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Company>> GetCompanies()
    {
        return await _context.Companies.ToListAsync();
    }

    public async Task<Company> GetCompany(int id)
    {
        return await _context.Companies.FindAsync(id);
    }

    public async Task<Company> CreateCompany(Company company)
    {
        _context.Companies.Add(company);
        await _context.SaveChangesAsync();
        return company;
    }
}
