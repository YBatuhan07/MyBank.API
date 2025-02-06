using Microsoft.EntityFrameworkCore;
using MyBank.Repository.Accounts;
using MyBank.Repository.Customers;
using MyBank.Repository.Transactions;
using System.Reflection;

namespace MyBank.Repository;

public class MyBankDbContext : DbContext
{
    public MyBankDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Account> Accounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}