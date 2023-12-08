using DCartWeb.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCartTests.HelperClasses
{
    public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
    {
        /// <summary>
        /// Set up new configuration for testing
        /// </summary>
        /// <param name="builder"></param>
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                //Removes the current dbcontext and add an in memory database instead
                var descriptor = services.SingleOrDefault(x => x.ServiceType == typeof(DbContextOptions<DCartWebContext>));
                if (descriptor != null)
                    services.Remove(descriptor);
                services.AddDbContext<DCartWebContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryTest");
                });

                //add anti forgerytoken 
                services.AddAntiforgery(x =>
                {
                    x.Cookie.Name = AntiForgeryTokenExtractor.AntiForgeryCookieName;
                    x.FormFieldName = AntiForgeryTokenExtractor.AntiForgeryFieldName;
                });

                //get the db context and ensures the database is created
                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                using (var appContext = scope.ServiceProvider.GetRequiredService<DCartWebContext>())
                {
                    try
                    {
                        appContext.Database.EnsureCreated();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }

            });
        }
    }
}
