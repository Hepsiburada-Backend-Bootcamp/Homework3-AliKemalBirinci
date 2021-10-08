using CampaignApi.Models.AutoMapper;
using CampaignApi.Models.Context;
using CampaignApi.Models.Repositories;
using CampaignApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CampaignApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<ICampaignService, CampaignService>();
            services.AddTransient<ICampaignRepository, CampaignRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CampaignApi", Version = "v1" });
            });

            services.AddDbContext<CampaignDbContext>(
                options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            services.AddDbContext<AnotherCampaignDbContext>(
                options => options.UseSqlServer("name=ConnectionStrings:SecondConnection"));
            services.AddDbContext<DapperContext>(
                options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CampaignApi v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
