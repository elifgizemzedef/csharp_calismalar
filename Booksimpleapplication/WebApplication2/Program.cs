using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<booksContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnection"));options.EnableSensitiveDataLogging(true); });
builder.Services.AddTransient<IRepository, EfRepository>();//IRepository tab
//builder.Services.AddDbContext<booksContext>(options => { options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")); options.EnableSensitiveDataLogging(true); });

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Book}/{action=Index}/{id?}");

app.Run();
