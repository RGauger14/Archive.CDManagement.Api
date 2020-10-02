using Archive.CDManagement.Api.Configuration;
using Archive.CDManagement.Api.DbContexts;
using Archive.CDManagement.Api.Repositories;
using Archive.CDManagement.Api.Repositories.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Archive.CDManagement.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var settings = new MySettings();
            Configuration.Bind("MySettings", settings);
            services.AddDbContext<CdManagementContext>(opt => opt.UseSqlServer(settings.CDManagementDBConnectionString));
            services.AddControllers();
            services.AddTransient<ICDRepository, CDRepository>();
            services.AddTransient<IRentalRepository, RentalRepository>();
            services.AddTransient<IStaffRepository, StaffRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}