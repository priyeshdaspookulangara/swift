using ARCAERP.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ARCAERP.Application.Interfaces
{
    public interface IPayrollService
    {
        Task<IEnumerable<EmployeeMaster>> GetAllEmployeesAsync();
        Task CreateSalaryAdvanceAsync(SalaryAdvance advance);
        Task CreateLeaveApplicationAsync(LeaveApplication leave);
    }
}
