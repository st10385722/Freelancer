using FreelancerJerry.Models;
using FreelancerJerry.Services;
using FreelancerJerry.Services.IRepository;
using FreelancerJerry.Services.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<FreelancerjerrydbContext>(options => 
    options.UseSqlServer(Environment.GetEnvironmentVariable("freelancerjerrydbconnectionstring")));

builder.Services.AddSession(options => 
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//dependency injection??
builder.Services.AddScoped<IFreelancerRepository, FreelancerRepository>();
//dependency injection.
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddScoped<IListingRepository, ListingRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
