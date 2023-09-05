using Payments.Db;
using Payments.Db.Services;

namespace Payments.WebService.DI;

public static class PaymentsDiExstensions
{
    public static void AddPaymentsManager(this IServiceCollection services)
    {
        services.AddTransient<PaymentsDbContext>();
        services.AddSingleton<IPaymentsManager, DbPaymentsManager>();
    }
}