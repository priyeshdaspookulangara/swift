using ARCAERP.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ARCAERP.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Existing DbSets
    public DbSet<Company> Companies { get; set; }
    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<SalesOrder> SalesOrders { get; set; }
    public DbSet<SalesOrderItem> SalesOrderItems { get; set; }
    public DbSet<Customer> Customers { get; set; }

    // Payroll Module
    public DbSet<EmployeeMaster> EmployeeMasters { get; set; }
    public DbSet<SalaryAdvance> SalaryAdvances { get; set; }
    public DbSet<LeaveApplication> LeaveApplications { get; set; }
    public DbSet<Overtime> Overtimes { get; set; }

    // Projects Module
    public DbSet<Project> Projects { get; set; }
    public DbSet<SubContractProject> SubContractProjects { get; set; }
    public DbSet<ProjectCost> ProjectCosts { get; set; }

    // Accounts Module
    public DbSet<Receipt> Receipts { get; set; }
    public DbSet<Payment> Payments { get; set; }

    // Production Module
    public DbSet<BillOfMaterials> BillOfMaterials { get; set; }
    public DbSet<BillOfMaterialsItem> BillOfMaterialsItems { get; set; }
    public DbSet<WorkOrder> WorkOrders { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Existing configurations
        builder.Entity<Item>(entity =>
        {
            entity.Property(e => e.UnitPrice).HasPrecision(18, 2);
        });

        builder.Entity<PurchaseOrderItem>(entity =>
        {
            entity.Property(e => e.UnitPrice).HasPrecision(18, 2);
        });

        builder.Entity<SalesOrder>(entity =>
        {
            entity.Property(e => e.TotalAmount).HasPrecision(18, 2);
        });

        builder.Entity<SalesOrderItem>(entity =>
        {
            entity.Property(e => e.UnitPrice).HasPrecision(18, 2);
        });
    }
}
