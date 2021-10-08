using CampaignApi.Models.Entities;
using System.Threading.Tasks;

namespace CampaignApi.Models.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product> GetByIdWithDapper(int id);
    }
}
