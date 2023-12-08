using DCartWeb.Models.Carts;
using DCartWeb.Models.Orders;
using DCartWeb.Models.Products;
using DCartWeb.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DCartWeb.Data;

public class DCartWebContext : IdentityDbContext<IdentityUser>
{


    public DCartWebContext(DbContextOptions<DCartWebContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<MainCategory> MainCategories { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }



    protected override async void OnModelCreating(ModelBuilder modelBuilder)
    {

        //Apply configurations for MainCategory,SubCategory and Products to be seeded to database
        modelBuilder.ApplyConfiguration(new MainCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new SubCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());

        //Setup identity role which uses the names from Models.Users.Roles class
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "6c2e174e-1b0e-416f-83af-483d56fd7212", Name = DCartWeb.Models.Users.Roles.RoleAdmin, NormalizedName = DCartWeb.Models.Users.Roles.RoleAdmin.ToUpper() });
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = DCartWeb.Models.Users.Roles.RoleUser, NormalizedName = DCartWeb.Models.Users.Roles.RoleUser.ToUpper() });



        //create admin
        var adminUser = new User
        {
            Id = "3a3e134a-2c3a-446f-86af-112d26fd2890",
            Email = "admin.dcartapp@gmail.com",
            NormalizedEmail = "admin.dcartapp@gmail.com".ToUpper(),
            FirstName = "Admin",
            LastName = "Admin",
            UserName = "admin.dcartapp@gmail.com",
            NormalizedUserName = "admin.dcartapp@gmail.com".ToUpper(),
            EmailConfirmed = true,
        };
        //hash the password
        PasswordHasher<User> ph = new PasswordHasher<User>();
        adminUser.PasswordHash = ph.HashPassword(adminUser, "Admin123#");

        // assign the user as an admin
        modelBuilder.Entity<User>().HasData(adminUser);
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "6c2e174e-1b0e-416f-83af-483d56fd7212",
            UserId = "3a3e134a-2c3a-446f-86af-112d26fd2890",
        });

        var customerUser = new User
        {
            Id = "9a3e139a-1c7a-446f-86af-112d26fd2899",
            Email = "test.dcartapp@gmail.com",
            NormalizedEmail = "test.dcartapp@gmail.com".ToUpper(),
            FirstName = "Test",
            LastName = "Test",
            UserName = "test.dcartapp@gmail.com",
            NormalizedUserName = "test.dcartapp@gmail.com".ToUpper(),
            EmailConfirmed = true,
        };
        PasswordHasher<User> ph2 = new PasswordHasher<User>();
        customerUser.PasswordHash = ph2.HashPassword(customerUser, "Test123#");

        modelBuilder.Entity<User>().HasData(customerUser);
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
            UserId = "9a3e139a-1c7a-446f-86af-112d26fd2899",
        });


        base.OnModelCreating(modelBuilder);





    }
}
