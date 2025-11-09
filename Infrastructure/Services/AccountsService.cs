using ARCAERP.Application.Interfaces;
using ARCAERP.Domain.Entities;
using ARCAERP.Infrastructure.Data;
using System.Threading.Tasks;

namespace ARCAERP.Infrastructure.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly ApplicationDbContext _context;

        public AccountsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateReceiptAsync(Receipt receipt)
        {
            _context.Receipts.Add(receipt);
            await _context.SaveChangesAsync();
        }

        public async Task CreatePaymentAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
        }
    }
}
