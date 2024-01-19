using Shared_Demo_DBSlide.Repositories;
using BLL = BLL_Demo_DBSlide;
using DAL = DAL_Demo_DBSlide;
using Mockup = Mockup_Demo_DBSlide;

namespace ASP_Demo_DBSlide
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //Ajout des services par injection de dépendance :
            #region Services
            builder.Services.AddScoped<IStudentRepository<BLL.Entities.Student>, BLL.Services.StudentService>();
            builder.Services.AddScoped<ISectionRepository<BLL.Entities.Section>, BLL.Services.SectionService>();
            builder.Services.AddScoped<IStudentRepository<DAL.Entities.Student>, DAL.Services.StudentService>();
            builder.Services.AddScoped<ISectionRepository<DAL.Entities.Section>, DAL.Services.SectionService>();
            //builder.Services.AddScoped<IStudentRepository<Mockup.Entities.Student>, Mockup.Services.StudentService>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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