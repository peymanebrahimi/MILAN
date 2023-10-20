﻿namespace WebApi1.Products;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
