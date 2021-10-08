using CampaignApi.Models.Context;
using CampaignApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampaignApi.Models.Repositories
{
    public class CampaignRepository : BaseRepository<Campaign>, ICampaignRepository
    {
        public CampaignRepository(CampaignDbContext context) : base(context)
        {

        }

        //private CampaignRepository(DbContext context): base(context)
        //{

        //}

        //public static CampaignRepository FactoryMethod(DbContext context)
        //{
        //    if(true)
        //    {

        //    }

        //    return new CampaignRepository(contextqwe);
        //}

    }
}
