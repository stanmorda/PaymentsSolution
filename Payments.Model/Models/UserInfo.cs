namespace Payments.Model.Models;

public class UserInfo
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Comment { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, UserId: {UserId}, Comment: {Comment}, Age: {Age}";
    }
}