using AdService.Application;
using AdService.Application.Common.Interfaces;
using AdService.Infrastructure;
using AdService.UI.Extensions;
using AdService.UI.Middlewares;
using NLog.Web;
using Stripe;

namespace AdService.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders();
            builder.Logging.SetMinimumLevel(LogLevel.Information);
            builder.Logging.AddNLogWeb();

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.DefineViewLocation(builder.Configuration);


            builder.Services.AddSession(options =>
            {
                // Ustawienia zabezpieczeñ sesji
                options.Cookie.HttpOnly = true; // Zapobiega dostêpowi do ciasteczka z poziomu JavaScript
                options.Cookie.IsEssential = true; // Oznacza ciasteczko jako niezbêdne, nawet jeœli sesja nie jest aktywna
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Czas wygaœniêcia sesji
                options.Cookie.SameSite = SameSiteMode.Strict; // Zapobiega atakom CSRF
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                app.UseInfrastructure(
                    scope.ServiceProvider.GetRequiredService<IApplicationDbContext>(),
                    app.Services.GetService<IAppSettingsService>(),
                    app.Services.GetService<IEmail>());

            }


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            var logger = app.Services.GetService<ILogger<Program>>();

            if (app.Environment.IsDevelopment())
            {
                logger.LogInformation("DEVELOPMENT MODE");
            }
            else
            {
                logger.LogInformation("PRODUCTION MODE");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();

            app.UseAuthentication();;
            app.UseAuthorization();

            // Dodanie obs³ugi sesji do potoku middleware'ów
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}