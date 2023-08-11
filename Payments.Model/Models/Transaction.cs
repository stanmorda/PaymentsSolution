namespace Payments.Model.Models;

public class Transaction
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal Summ { get; set; }
    public DateTime CreatedDate { get; set; }

    public User? User { get; set; }
}