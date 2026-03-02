using CustomerApp;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// IMPORTANT: We use AddSingleton here so that the same '_customers' list 
// is shared across all users and requests while the app is running.
builder.Services.AddSingleton<ICustomerService, CustomerService>();

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();