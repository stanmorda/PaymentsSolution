using Payments.Model.Models;

namespace Payments.Db.Services;

public class PaymentsFileContext
{
    public List<User> Users { get; set; }
    public List<Transaction> Transactions { get; set; }

    public PaymentsFileContext()
    {
        Users = new List<User>();
        Transactions = new List<Transaction>();
    }
}