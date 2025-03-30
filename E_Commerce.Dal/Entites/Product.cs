﻿namespace E_Commerce.Dal.Entites;

public class Product
{
    public long ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string? ImageLink { get; set; }
    public List<CartProduct> CartProducts { get; set; }
    public List<OrderProduct> OrderProducts { get; set; }
}