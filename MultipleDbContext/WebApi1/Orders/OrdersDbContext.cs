﻿using Microsoft.EntityFrameworkCore;

namespace WebApi1.Orders;

public class OrdersDbContext : DbContext
{
    public OrdersDbContext(DbContextOptions<OrdersDbContext> options)
        : base(options)
    {

    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<LineItem> LineItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("orders");

        modelBuilder.Entity<Order>().HasMany<LineItem>().WithOne()
            .HasForeignKey(li => li.OrderId);

    }
}