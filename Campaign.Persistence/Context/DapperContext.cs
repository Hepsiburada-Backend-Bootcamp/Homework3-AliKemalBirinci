using Microsoft.EntityFrameworkCore;

namespace CampaignApi.Models.Context
{
    public class DapperContext : DbContext
    {
        public DapperContext(DbContextOptions<DapperContext> options) : base(options) { }
    }
}
