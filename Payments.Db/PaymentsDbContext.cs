using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Payments.Model.Models;

namespace Payments.Db;

public class PaymentsDbContext : DbContext
{
    private const string ConnectionString = "Host=localhost;Username=postgres;Password=admin;Database=Maxima";
    
    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConnectionString);
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }
}