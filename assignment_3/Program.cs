using System;
using assignment_3.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace assignment_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
                
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    using (var context = new DatabaseContext(
                        services.GetRequiredService<
                            DbContextOptions<DatabaseContext>>())
                    )
                    {
                        DatabaseInitializer.Initialize(context);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex + " \n Error");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
