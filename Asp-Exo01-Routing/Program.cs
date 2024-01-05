namespace Asp_Exo01_Routing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.MapControllerRoute(
                name: "Pile",
                pattern: "Jeu/Pile",
                defaults: new { Controller = "Jeu", Action = "PileFace", Choix = "Pile" });

            app.MapControllerRoute(
                name: "Face",
                pattern: "Jeu/Face",
                defaults: new { Controller = "Jeu", Action = "PileFace", Choix = "Face" });

            app.MapControllerRoute(
                name: "LancerDé",
                pattern: "Jeu/LancerDé/{max?}",
                defaults : new {Controller = "Jeu", Action = "LancerDe"});

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}