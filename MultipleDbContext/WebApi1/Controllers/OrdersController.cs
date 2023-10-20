namespace WebApi1.Controllers;

using global::WebApi1.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi1.Contracts;
using WebApi1.Products;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ILogger<OrdersController> _logger;
    private readonly OrdersDbContext ordersDbContext;
    private readonly ProductsDbContext productsDbContext;

    public OrdersController(ILogger<OrdersController> logger,
        OrdersDbContext ordersDbContext,
        ProductsDbContext productsDbContext)
    {
        _logger = logger;
        this.ordersDbContext = ordersDbContext;
        this.productsDbContext = productsDbContext;
    }

    [HttpPost]
    public async Task<IActionResult> Post(SubmitOrderRequest request)
    {
        var products = await productsDbContext.Products
            .Where(x => request.ProductIds.Contains(x.Id))
            .AsNoTracking()
            .ToListAsync();

        if (products.Count != request.ProductIds.Count)
        {
            return BadRequest("Some product is missing");
        }

        /*
         * if on same db =>
        using var transaction = new SqlTransaction();

        await ordersDbContext.Database.UseTransactionAsync(transaction);
        await productsDbContext.Database.UseTransactionAsync(transaction);
        */
        var order = new Order
        {
            Id = Guid.NewGuid(),
            TotalPrice = products.Sum(x => x.Price),
            LineItems = products.Select(x => new LineItem
            {
                ProductId = x.Id,
                Price = x.Price,
                Id = Guid.NewGuid()
            }).ToList(),
        };

        ordersDbContext.Orders.Add(order);
        await ordersDbContext.SaveChangesAsync();

        return Ok(order);
    }
}
