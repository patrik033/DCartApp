using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DCartWeb.Data;
using DCartWeb.Models.Users;
using Microsoft.AspNetCore.Identity.UI.Services;
using DCartWeb.Email;
using DCartWeb.LoadIntoUI;
using DCartWeb.Models.Stripe;
using DCartWeb.Repos.MainCategoryRepo;
using Stripe;
using DCartWeb.Repos.CartRepo;
using DCartWeb.Repos.HomeRepo;

var builder = WebApplication.CreateBuilder(args);



//Sql Server
builder.Services.AddDbContext<DCartWebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//Test Db
builder.Services.AddDbContext<DCartWebContext>(options =>
{
    options.UseInMemoryDatabase("InMemoryTest");
});

//Add Authentication
builder.Services.AddIdentity<User, IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<DCartWebContext>();

//Services
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("SendGrid"));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSingleton<ISendGridEmailSender, SendGridEmailSender>();
builder.Services.AddScoped<ILoadCategories, LoadCategories>();

//Repos
builder.Services.AddScoped<ICartRepo, CartRepo>();
builder.Services.AddScoped<IHomeRepo, HomeRepo>();
builder.Services.AddScoped<IMainCategoryRepository, MainCategoryRepository>();

//more services
builder.Services.AddScoped<IStripeService, StripeService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.ConfigureApplicationCookie(options =>
{
    //options.LoginPath = "/Identity/Account/Login";
    //options.LogoutPath = "/Identity/Account/Logout";
    //options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


var app = builder.Build();

Console.WriteLine();
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
app.UseAuthentication();
app.UseAuthorization();



app.MapRazorPages();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

});

app.Run();


public partial class Program { }