using Payments.Db.Services;
using Payments.Model.Models;

namespace Payments.Db;

public class DbPaymentsManager : IPaymentsManager
{
    private readonly PaymentsDbContext _paymentsDbContext;

    public DbPaymentsManager(PaymentsDbContext paymentsDbContext)
    {
        _paymentsDbContext = paymentsDbContext;
    }

    public User[] GetUsers()
    {
        return _paymentsDbContext.Users.ToArray();
    }

    public Transaction[] GetTransactionsByUserId(int userId)
    {
        return _paymentsDbContext.Transactions.Where(x => x.UserId == userId).ToArray();
    }

    public async Task<User> CreateUser(User user)
    {
        _paymentsDbContext.Users.Add(user);
        await _paymentsDbContext.SaveChangesAsync();
        return user;
    }

    public async Task<Transaction> CreateTransaction(Transaction transaction)
    {
        _paymentsDbContext.Transactions.Add(transaction);
        await _paymentsDbContext.SaveChangesAsync();
        return transaction;
    }
}