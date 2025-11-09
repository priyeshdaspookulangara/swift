using ARCAERP.Application.Interfaces;
using ARCAERP.Domain.Entities;
using ARCAERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ARCAERP.Infrastructure.Services
{
    public class PayrollService : IPayrollService
    {
        private readonly ApplicationDbContext _context;

        public PayrollService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeMaster>> GetAllEmployeesAsync()
        {
            return await _context.EmployeeMasters.ToListAsync();
        }

        public async Task CreateSalaryAdvanceAsync(SalaryAdvance advance)
        {
            _context.SalaryAdvances.Add(advance);
            await _context.SaveChangesAsync();
        }

        public async Task CreateLeaveApplicationAsync(LeaveApplication leave)
        {
            _context.LeaveApplications.Add(leave);
            await _context.SaveChangesAsync();
        }
    }
}
