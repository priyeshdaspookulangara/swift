using Microsoft.AspNetCore.Mvc;
using ARCAERP.Domain.Entities;
using ARCAERP.Application.Interfaces;
using System.Threading.Tasks;

namespace ARCAERP.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayrollController : ControllerBase
    {
        private readonly IPayrollService _payrollService;

        public PayrollController(IPayrollService payrollService)
        {
            _payrollService = payrollService;
        }

        // GET: api/payroll/employees
        [HttpGet("employees")]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _payrollService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        // POST: api/payroll/salaryadvance
        [HttpPost("salaryadvance")]
        public async Task<IActionResult> CreateSalaryAdvance([FromBody] SalaryAdvance advance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _payrollService.CreateSalaryAdvanceAsync(advance);
            return StatusCode(201); // Created
        }

        // POST: api/payroll/leaveapplication
        [HttpPost("leaveapplication")]
        public async Task<IActionResult> CreateLeaveApplication([FromBody] LeaveApplication leave)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _payrollService.CreateLeaveApplicationAsync(leave);
            return StatusCode(201); // Created
        }
    }
}
