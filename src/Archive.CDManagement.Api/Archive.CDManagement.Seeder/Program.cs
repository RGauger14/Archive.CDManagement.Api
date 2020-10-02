using Archive.CDManagement.Api.Configuration;
using Archive.CDManagement.Api.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Archive.CDManagement.Seeder
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var configuration = BuildConfiguration(args);
            var settings = new MySettings();
            configuration.Bind("MySettings", settings);

            var services = BuildServices(settings);
            var serviceProvider = services.BuildServiceProvider();
            var dropExistingData = true;

            SeedTables(serviceProvider, dropExistingData);
        }

        private static IConfiguration BuildConfiguration(string[] args)
        {
            return new ConfigurationBuilder()
                          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                          .AddUserSecrets(typeof(Program).Assembly)
                          .AddEnvironmentVariables()
                          .AddCommandLine(args)
                          .Build();
        }

        private static void SeedTables(ServiceProvider serviceProvider, bool dropExistingData)
        {
            CDSeeder.Seed(serviceProvider, dropExistingData);
            StaffSeeder.Seed(serviceProvider, dropExistingData);
            RentalsSeeder.Seed(serviceProvider, dropExistingData);
        }

        private static ServiceCollection BuildServices(MySettings settings)
        {
            var services = new ServiceCollection();
            services.AddDbContext<CdManagementContext>(opt => opt.UseSqlServer(settings.CDManagementDBConnectionString));
            return services;
        }
    }
}