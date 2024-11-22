using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using EventPlanner.Data;
using EventPlanner.Models;

namespace EventPlanner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddAuthentication().AddCookie("MycookieAuth", options =>
            {
                options.Cookie.Name = "MycookieAuth";
                options.LoginPath = "/Account/Login";
            });

            builder.Services.AddDbContext<EventPlannerContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("EventPlannerDB"))
            );

            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
