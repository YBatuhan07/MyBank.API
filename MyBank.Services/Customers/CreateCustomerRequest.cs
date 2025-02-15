namespace MyBank.Services.Customers;

public record CreateCustomerRequest(string FullName, string Email, string Phone, DateTime DateOfBirth);