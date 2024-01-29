using ASP_Demo_Session.Handlers;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ASP_Demo_Session
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            #region Services de session
            builder.Services.AddHttpContextAccessor();  //Injection de dépendance du HttpContext dans le SessionManager (Handlers)

            builder.Services.AddDistributedMemoryCache();   //Ajout d'espace mémoire pour lier les cookie à l'application

            builder.Services.AddSession(options =>          //Création d'un cookie pour sauvegarder la session
            {
                options.Cookie.Name = "ASP-Demo-Session";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });

            builder.Services.Configure<CookiePolicyOptions>(options =>  //Définition des règles (pour être OK avec le RGPD)
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.Secure = CookieSecurePolicy.Always;
            });

            builder.Services.AddScoped<UserSessionManager>();   //Ajout du UserSessionManager (Handlers) par injection de dépendance
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSession();       //Activation des Middlewares permettant le contrôle 
            app.UseCookiePolicy();  //du Cookie de Session durant chaque requête HTTP

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