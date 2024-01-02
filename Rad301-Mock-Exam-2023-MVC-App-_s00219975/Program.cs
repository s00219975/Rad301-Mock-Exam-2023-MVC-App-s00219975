using Rad301_Mock_Exam_2023_DataModel_s00219975;
using System.Configuration;
using System.Xml.Linq;
using Tracker.WebAPIClient;

namespace Rad301_Mock_Exam_2023_MVC_App__s00219975
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.

            //var connectionString = builder.Configuration.GetConnectionString("RadExamMockDB-S00219975") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");


            ActivityAPIClient.Track(StudentID: "s00219975", StudentName: "Denys Musatov", activityName: "Rad301 Mock Exam 2023", Task: "Exam Start");

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Add DbContext as a service
            builder.Services.AddDbContext<FlightContext>();

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