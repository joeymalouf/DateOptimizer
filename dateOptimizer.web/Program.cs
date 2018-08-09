using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using dateOptimizer.data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace dateOptimizer.web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = BuildWebHost(args);
            using (IServiceScope scope = host.Services.CreateScope()) {
                IServiceProvider services = scope.ServiceProvider;
                var context = ((DateOptimizerContext)services.GetService(typeof(DateOptimizerContext)));
                var provider = context.ProviderName;

                //if not an InMemory database, migrate

                if (!provider.Contains("InMemory")) {
                    ((DateOptimizerContext)services.GetService(typeof(DateOptimizerContext))).Migrate();
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) {
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();
            return WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
        }
    }
}
