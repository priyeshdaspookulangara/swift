using ARCAERP.Domain.Entities;

namespace ARCAERP.Application.Interfaces;

public interface ISalesService
{
    Task<IEnumerable<SalesOrder>> GetSalesOrders();
    Task<SalesOrder> GetSalesOrder(int id);
    Task<SalesOrder> CreateSalesOrder(SalesOrder salesOrder);
}
