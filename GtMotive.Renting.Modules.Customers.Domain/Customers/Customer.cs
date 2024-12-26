﻿namespace GtMotive.Renting.Modules.Customers.Domain.Customers;

public class Customer
{
    public Guid Id { get; private set; }

    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    public string PhoneNumber { get; private set; } = string.Empty;

    public CustomerStatus Status { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public static Customer Create(
        string firstName,
        string lastName,
        string email,
        string phoneNumber
    )
    {
        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phoneNumber,
            Status = CustomerStatus.Active,
            CreatedAt = DateTime.UtcNow
        };

        return customer;
    }
}