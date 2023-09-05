using Payments.Model.Models;

namespace Payments.Db.Services;

public interface IPaymentsManager
{
    public User[] GetUsers();

    public Transaction[] GetTransactionsByUserId(int userId);

    public Task<User> CreateUser(User user);

    public Task<Transaction> CreateTransaction(Transaction transaction);
}