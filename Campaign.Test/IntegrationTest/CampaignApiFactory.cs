using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Test.IntegrationTest
{
    public class CampaignApiFactory : WebApplicationFactory<TestStartup>
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<TestStartup>();
                 });
        }
    }
}
