using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MobileStore.Models;

namespace MobileStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TopNavigationBar.BuyCounter = 0;
            TopNavigationBar.CurrentOrder = new Order();
            TopNavigationBar.m_ActiveValues = new string[2] { "nav-item active", "nav-item" };
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<MobileContext>();
                    SampleData.Initialize(context);
                    FilterViewProducer.MakeList(context.Phones.ToList());
                    System.Collections.Generic.List<string> sortTypes = new System.Collections.Generic.List<string>();
                    sortTypes.Add("За зр. алфавіту");
                    sortTypes.Add("За сп. алфавіту");
                    sortTypes.Add("За зр. ціни");
                    sortTypes.Add("За сп. ціни");
                    FilterViewSortType.MakeList(sortTypes);

                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
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