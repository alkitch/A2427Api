using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using A2427Api.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace A2427Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //BuildWebHost(args).Run();
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<RFIDContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args).ConfigureAppConfiguration((context, builder) =>
            {
                var env = context.HostingEnvironment;
                //var appAss = Assembly.Load(new AssemblyName(env.ApplicationName));
                //string path = appAss.Location;
                builder.AddJsonFile(env.ContentRootPath + "/appsettings.json",
                             optional: true, reloadOnChange: true)
                       .AddJsonFile($"appsettings.{env.EnvironmentName}.json",
                             optional: true, reloadOnChange: true);

                if (env.IsDevelopment())
                {
                    var appAssembly = Assembly.Load(
                        new AssemblyName(env.ApplicationName));
                    if (appAssembly != null)
                    {
                        builder.AddUserSecrets(appAssembly, optional: true);
                    }
                }

                builder.AddEnvironmentVariables();

                if (args != null)
                {
                    builder.AddCommandLine(args);
                }
            })

                .UseStartup<Startup>()
                .Build();
    }
}
