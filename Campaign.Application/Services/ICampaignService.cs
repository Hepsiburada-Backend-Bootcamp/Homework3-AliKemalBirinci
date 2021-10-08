using CampaignApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampaignApi.Services
{
    public interface ICampaignService
    {
        Task<List<CampaignDto>> GetAllCampaign();
        Task<CampaignDto> CreateProductGroup(CampaignDto newCampaign);
        void DeleteCampaign(int id);
    }
}
