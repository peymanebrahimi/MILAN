using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi1.Products;

namespace WebApi1.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{


    private readonly ILogger<ProductsController> _logger;
    private readonly ProductsDbContext productsDbContext;

    public ProductsController(ILogger<ProductsController> logger,
        ProductsDbContext productsDbContext)
    {
        _logger = logger;
        this.productsDbContext = productsDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var q = await productsDbContext.Products.Select(x => x.Id).ToListAsync();

        return Ok(q);
    }
}