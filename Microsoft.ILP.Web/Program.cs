using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.ILP.Web.Services;

namespace Microsoft.ILP.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //HttpClinet
            //1. //builder.Services.AddHttpClient();
            //2. //builder.Services.AddHttpClient("ILPMicroserviceClient", client =>
            //{
            //    client.BaseAddress = new Uri("https://api.example.com/");
            //    client.DefaultRequestHeaders.Add("Accept", "application/json");
            //});

            //3. 
            builder.Services.AddHttpClient<IUserService, UserService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
