﻿namespace MiageCorp.AwesomeShop.ProductApi.Models;

public class ProductDTO
{
    public string? Id { get; set; }
    
    public string Label { get; set; }
    
    public string Description { get; set; }
    
    public double Price { get; set; }
}