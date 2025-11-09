using ARCAERP.Domain.Entities;
using System.Threading.Tasks;

namespace ARCAERP.Application.Interfaces
{
    public interface IAccountsService
    {
        Task CreateReceiptAsync(Receipt receipt);
        Task CreatePaymentAsync(Payment payment);
    }
}
