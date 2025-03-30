﻿namespace E_Commerce.Dal.Entites;

public class Customer
{
    public long CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<Cart> Carts { get; set; }
    public List<Order> Orders { get; set; }
    public List<Card> Cards { get; set; }
}
