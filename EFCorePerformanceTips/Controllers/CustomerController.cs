using EFCorePerformanceTips.ApplicationLayer.Services;
using EFCorePerformanceTips.CoreLayer.Entities;
using EFCorePerformanceTips.CoreLayer.Interfaces;
using EFCorePerformanceTips.InfrastructureLayer.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _custoemrService;

    public CustomerController(ICustomerService custoemrService)
    {
        _custoemrService = custoemrService;
    }

    [HttpGet("get-customers-with-orders")]
    public async Task<IActionResult> GetcustomersWithOrdersAsync(CancellationToken cancellationToken = default)
    {
        return Ok(await _custoemrService.GetCustomersWithOrders());
    }
}
