﻿using EFCorePerformanceTips.ApplicationLayer.Services;
using EFCorePerformanceTips.CoreLayer.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts(int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var products = await _productService.GetPaginatedProductsAsync(pageNumber, pageSize, cancellationToken);
        Type type = typeof(List<Product>);
        return Ok(products);
    }

    [HttpGet("GetProductById")]
    public async Task<IActionResult> GetProductById(int productId, CancellationToken cancellationToken = default)
    {
        var products = await _productService.GetProductByIdAsync(productId, cancellationToken);
        Type type = typeof(Product);
        return Ok(products);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] int categoryId, CancellationToken cancellationToken = default)
    {
        await _productService.UpdateProductPricesAsync(categoryId, 1000, cancellationToken);
        return Ok();
    }
}