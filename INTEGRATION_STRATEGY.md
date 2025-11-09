# Integration Strategy: Linking Projects to Accounts

This document outlines the strategy for integrating the **Projects** and **Accounts** modules within the ARCA ERP system, ensuring a clean, decoupled, yet functionally linked architecture.

## Core Principle

The primary goal is to allow financial transactions recorded in the Accounts module (specifically `Payments`) to be directly associated with costs incurred in the Projects module. This provides a clear financial trail for project expenditures, enabling accurate cost tracking and reporting.

The integration will be handled at the **service layer**, keeping the domain models decoupled.

## Architectural Blueprint

### 1. Domain Model Modification

To establish the link, the `Payment` entity in the `ARCAERP.Domain.Entities.Accounts` will be updated to include an optional foreign key relationship to the `ProjectCost` entity.

**File:** `Core/Domain/Entities/Accounts.cs`

```csharp
public class Payment
{
    // ... existing properties

    [Required]
    public bool IsAgainstBill { get; set; }

    // --- INTEGRATION LINK ---
    // This is the foreign key to the specific cost incurred in a project.
    // It is nullable because not all payments are related to project costs.
    public int? ProjectCostId { get; set; }

    [ForeignKey("ProjectCostId")]
    public ProjectCost? ProjectCost { get; set; }
}
```

### 2. Service Layer Logic (`AccountsService`)

The business logic for this integration will reside exclusively in the `AccountsService`. When a payment is created, the service will orchestrate the interaction.

**File:** `Infrastructure/Services/AccountsService.cs`

```csharp
public class AccountsService : IAccountsService
{
    private readonly ApplicationDbContext _context;

    public AccountsService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreatePaymentAsync(Payment payment)
    {
        // Use a transaction to ensure data integrity
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            // 1. Check if the payment is against a project cost
            if (payment.IsAgainstBill && payment.ProjectCostId.HasValue)
            {
                var projectCost = await _context.ProjectCosts.FindAsync(payment.ProjectCostId.Value);

                if (projectCost == null)
                {
                    throw new InvalidOperationException($"ProjectCost with ID {payment.ProjectCostId.Value} not found.");
                }

                // Optional: Update the status of the project cost
                // To implement this, a 'Status' property would be added to the ProjectCost entity.
                // projectCost.Status = "Paid";
                // _context.ProjectCosts.Update(projectCost);
            }

            // 2. Add the payment record
            _context.Payments.Add(payment);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw; // Re-throw the exception after rolling back
        }
    }

    // ... other methods
}
```

### 3. API Endpoint (`AccountsController`)

The `AccountsController` will not need significant changes. The `CreatePayment` endpoint will naturally accept the `ProjectCostId` as part of the `Payment` object in the request body.

**File:** `Presentation/Controllers/AccountsController.cs`

```csharp
[HttpPost("payments")]
public async Task<IActionResult> CreatePayment([FromBody] Payment payment)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    try
    {
        await _accountsService.CreatePaymentAsync(payment);
        return StatusCode(201); // Created
    }
    catch (InvalidOperationException ex)
    {
        return BadRequest(new { message = ex.Message });
    }
}
```

This strategy ensures that:
- **Domain models are decoupled:** A `ProjectCost` has no direct knowledge of the `Accounts` module.
- **Business logic is centralized:** All integration logic is handled within the `AccountsService`.
- **Data integrity is maintained:** The use of database transactions guarantees that a payment and its corresponding project cost update succeed or fail together.
