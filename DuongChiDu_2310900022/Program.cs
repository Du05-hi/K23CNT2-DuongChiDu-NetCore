using DuongChiDu_2310900022.Models;
using Microsoft.EntityFrameworkCore;

namespace DuongChiDu_2310900022
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();



            var connectionString = builder.Configuration.GetConnectionString("DcdDbConnect");
            builder.Services.AddDbContext<DuongChiDu2310900022Context>(x => x.UseSqlServer(connectionString));
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
                pattern: "{controller=DcdHome}/{action=DcdIndex}/{dcdid?}");

            app.Run();
        }
    }
}
