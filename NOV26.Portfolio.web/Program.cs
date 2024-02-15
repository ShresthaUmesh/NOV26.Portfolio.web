using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NOV26.Portfolio.web.Data;
namespace NOV26.Portfolio.web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<NOV26PortfoliowebContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("NOV26PortfoliowebContext") ?? throw new InvalidOperationException("Connection string 'NOV26PortfoliowebContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
