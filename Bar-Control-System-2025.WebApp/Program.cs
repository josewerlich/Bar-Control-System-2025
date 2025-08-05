using Bar_Control_System_2025.Infrastructure.Files.ProductRepositoryInFile;
using Bar_Control_System_2025.Infrastructure.Files.Shared;
using Bar_Control_System_2025.Infrastructure.Files.TableModule;
using Bar_Control_System_2025.Infrastructure.Files.WaiterRepositoryInFile;

namespace Bar_Control_System_2025.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddScoped<DataContext>(provider => new DataContext(loadData: true));
            builder.Services.AddScoped<TableRepositoryInFile>();
            builder.Services.AddScoped<ProductReposirotyInFile>();
            builder.Services.AddScoped<WaiterRepositoryInFile>();
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
