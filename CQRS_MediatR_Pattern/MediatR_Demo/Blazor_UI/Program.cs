using Blazor_UI.Data;
using DemoLibrary.DataAccess;
using MediatR;
using DemoLibrary;

namespace Blazor_UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();

            //While AddSingleton is not a good idea for adata access, for this
            //demo it is perfect as it will make our data persist.
            builder.Services.AddSingleton<IDataAccess, DemoDataAccess>();

            //We create a class at the root of the project containing the MediatR
            //and pass it to the AddMediatR() method specifying that we target the
            //whole Assembly. The sole purpose of the DemoLibraryMediatREntrypoint
            //class is to be used here as a reference to the assembly where
            //MediatR-related components are located.

            //The AddMediatR method requires a reference point to determine which
            //assembly to scan for handlers, requests, and other MediatR-related components.
            //This reference point is typically the type of a class. By using a dedicated
            //"entry point" class (DemoLibraryMediatREntrypoint), you make the purpose clear:

            //It explicitly signals that the entire assembly should be scanned for MediatR components.

            //It avoids accidental dependencies on other, unrelated classes in the assembly.
            builder.Services.AddMediatR(typeof(DemoLibraryMediatREntrypoint).Assembly);

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

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}