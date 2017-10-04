using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vega.Api.Core;
using Vega.Api.Persistence;

namespace Vega.Api
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
            services.AddAutoMapper();

            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddCors(options =>
            {
                options.AddPolicy("ManaAPI",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:4200")
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
            });
            //services.AddDbContext<VegaDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:Default"]));
            services.AddDbContext<VegaDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("ManaAPI");
            app.UseMvc();
        }
    }
}
