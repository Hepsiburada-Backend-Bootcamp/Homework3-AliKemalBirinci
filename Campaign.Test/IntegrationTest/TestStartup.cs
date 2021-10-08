using CampaignApi;
using CampaignApi.Models.AutoMapper;
using CampaignApi.Models.Context;
using CampaignApi.Models.Repositories;
using CampaignApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Test.IntegrationTest
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration):base(configuration)
        {

        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<ICampaignService, CampaignService>();
            services.AddTransient<ICampaignRepository, CampaignRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddControllers().AddApplicationPart(typeof(Startup).Assembly);

            services.AddDbContext<CampaignDbContext>(
                options => options.UseInMemoryDatabase("CampaignInMemoryDb"));
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context =  scope.ServiceProvider.GetRequiredService<CampaignDbContext>();
            AddTestData(context);

            base.Configure(app, env);
        }

        private void AddTestData(CampaignDbContext context)
        {
            for (int i = 150; i < 155; i++)
            {
                CampaignApi.Models.Entities.Campaign campaign = new();
                campaign.Description = "campaign" + i;
                campaign.EndDate = DateTime.Now.AddMonths(i);
                campaign.StartDate = DateTime.Now.AddMonths(i * -1);
                campaign.Id = i;
                campaign.IsActive = true;
                campaign.Name = "campaign" + i;

                context.Campaigns.Add(campaign);
            }

            for (int i = 25; i < 27; i++)
            {
                CampaignApi.Models.Entities.ProductGroup productGroup = new();
                productGroup.Id = i;
                productGroup.Name = "productGroup" + i;

                context.ProductGroups.Add(productGroup);
            }

            for (int i = 35; i < 40; i++)
            {
                CampaignApi.Models.Entities.Product product = new();
                product.Id = i;
                product.Name = "product" + i;
                product.Price = i * 5;

                context.Products.Add(product);
            }

            context.SaveChanges();
        }
    }
}
