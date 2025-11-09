using Microsoft.AspNetCore.Mvc;
using ARCAERP.Domain.Entities;
using ARCAERP.Application.Interfaces;
using System.Threading.Tasks;

namespace ARCAERP.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService _accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            _accountsService = accountsService;
        }

        // POST: api/accounts/receipts
        [HttpPost("receipts")]
        public async Task<IActionResult> CreateReceipt([FromBody] Receipt receipt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _accountsService.CreateReceiptAsync(receipt);
            return StatusCode(201); // Created
        }

        // POST: api/accounts/payments
        [HttpPost("payments")]
        public async Task<IActionResult> CreatePayment([FromBody] Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _accountsService.CreatePaymentAsync(payment);
            return StatusCode(201); // Created
        }
    }
}
