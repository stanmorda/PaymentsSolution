using Payments.Db;
using Payments.Db.Services;
using Payments.WebService.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// var dbContext = new PaymentsDbContext();
// var paymentsManager = new DbPaymentsManager(dbContext);



// var dbContext = new PaymentsFileContext();
// var paymentsManager = new FilePaymentsManager(dbContext);

// builder.Services.AddSingleton(dbContext);
// builder.Services.AddSingleton<IPaymentsManager>(paymentsManager);

builder.Services.AddPaymentsManager();


#region 1. Enable session mechanism
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();
#endregion



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Map("/users", HandlerUsersMap);


static void HandlerUsersMap(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        if (context.Request.Headers.ContainsKey("mykey"))
        {
             await context.Response.WriteAsync("UNAUTORIZE");
        }
    });
}
app.Run();