using ARCAERP.Application.Interfaces;
using ARCAERP.Domain.Entities;
using ARCAERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ARCAERP.Infrastructure.Services;

public class SalesService : ISalesService
{
    private readonly ApplicationDbContext _context;

    public SalesService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SalesOrder>> GetSalesOrders()
    {
        return await _context.SalesOrders.Include(s => s.Customer).Include(s => s.Items).ThenInclude(i => i.Item).ToListAsync();
    }

    public async Task<SalesOrder> GetSalesOrder(int id)
    {
        return await _context.SalesOrders.Include(s => s.Customer).Include(s => s.Items).ThenInclude(i => i.Item).FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<SalesOrder> CreateSalesOrder(SalesOrder salesOrder)
    {
        _context.SalesOrders.Add(salesOrder);
        await _context.SaveChangesAsync();
        return salesOrder;
    }
}
