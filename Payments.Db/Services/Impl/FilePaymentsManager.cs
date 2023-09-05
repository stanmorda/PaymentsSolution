using Payments.Db.Services;
using Payments.Model.Models;

namespace Payments.Db;

public class FilePaymentsManager : IPaymentsManager
{
    private PaymentsFileContext _paymentsFileContext;

    public FilePaymentsManager(PaymentsFileContext paymentsFileContext)
    {
        _paymentsFileContext = paymentsFileContext;
    }

    public User[] GetUsers()
    {
        throw new NotImplementedException();
    }

    public Transaction[] GetTransactionsByUserId(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<User> CreateUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<Transaction> CreateTransaction(Transaction transaction)
    {
        throw new NotImplementedException();
    }
}