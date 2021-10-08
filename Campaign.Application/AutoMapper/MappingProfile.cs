using AutoMapper;
using CampaignApi.Models.Dtos;
using CampaignApi.Models.Entities;

namespace CampaignApi.Models.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CampaignDto, Campaign>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}
