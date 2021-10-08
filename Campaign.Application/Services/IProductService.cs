using CampaignApi.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampaignApi.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDto>> GetAllAsync();
        public Task<ProductDto> GetByIdAsync(int id);
    }
}
