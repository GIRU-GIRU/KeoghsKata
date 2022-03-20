using KeoghsKata.Database;
using KeoghsKata.Services;
using Microsoft.Extensions.Logging.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDatabaseServiceBase, DatabaseServiceBase>();
builder.Services.AddScoped<ISKUSvc, SKUSvc>();
builder.Services.AddScoped<IBasketPromotionSvc, BasketPromotionSvc>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMvc().AddSessionStateTempDataProvider();
builder.Services.AddSession();

//We don't have a connection string in the appsettings but this is the suggested setup from the ms docs
var connectionString = builder.Configuration.GetConnectionString("KeoghsDatabase") ?? "Data Source=KeoghsDatabase.db";
builder.Services.AddSqlite<DatabaseContext>(connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//Added a session for the shopping basket
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Checkout}/{action=Index}/{id?}");

app.Run();
