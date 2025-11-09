using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARCAERP.Domain.Entities
{
    public class EmployeeMaster
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(100)]
        public string? EmployeeName { get; set; }
        [Required]
        [StringLength(20)]
        public string? EmployeeCode { get; set; }
        public DateTime DateOfJoining { get; set; }
        [StringLength(100)]
        public string? Designation { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal BasicSalary { get; set; }
    }

    public class SalaryAdvance
    {
        [Key]
        public int AdvanceId { get; set; }
        [ForeignKey("EmployeeMaster")]
        public int EmployeeId { get; set; }
        public EmployeeMaster? Employee { get; set; }
        public DateTime AdvanceDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public bool IsApproved { get; set; }
    }

    public class LeaveApplication
    {
        [Key]
        public int LeaveApplicationId { get; set; }
        [ForeignKey("EmployeeMaster")]
        public int EmployeeId { get; set; }
        public EmployeeMaster? Employee { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        [Required]
        [StringLength(200)]
        public string? Reason { get; set; }
        public bool IsApproved { get; set; }
    }

    public class Overtime
    {
        [Key]
        public int OvertimeId { get; set; }
        [ForeignKey("EmployeeMaster")]
        public int EmployeeId { get; set; }
        public EmployeeMaster? Employee { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal RatePerHour { get; set; }
    }
}
