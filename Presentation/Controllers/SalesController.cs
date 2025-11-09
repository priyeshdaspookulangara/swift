using ARCAERP.Application.Interfaces;
using ARCAERP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ARCAERP.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly ISalesService _salesService;

    public SalesController(ISalesService salesService)
    {
        _salesService = salesService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SalesOrder>>> GetSalesOrders()
    {
        return Ok(await _salesService.GetSalesOrders());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SalesOrder>> GetSalesOrder(int id)
    {
        var salesOrder = await _salesService.GetSalesOrder(id);

        if (salesOrder == null)
        {
            return NotFound();
        }

        return Ok(salesOrder);
    }

    [HttpPost]
    public async Task<ActionResult<SalesOrder>> PostSalesOrder(SalesOrder salesOrder)
    {
        var createdSalesOrder = await _salesService.CreateSalesOrder(salesOrder);
        return CreatedAtAction("GetSalesOrder", new { id = createdSalesOrder.Id }, createdSalesOrder);
    }
}
