using AutoMapper;
using CampaignApi.Models;
using CampaignApi.Models.Entities;
using CampaignApi.Models.Repositories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampaignApi.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CampaignService> _logger;

        public CampaignService(ICampaignRepository campaignRepository, IMapper mapper, ILogger<CampaignService> logger)
        {
            _campaignRepository = campaignRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CampaignDto> CreateProductGroup(CampaignDto newCampaign)
        {
            //TODO : Mapper eklenecek - DONE

            //BEFORE
            //var tmpCampaign = new Campaign
            //{
            //    Description = newCampaign.Description,
            //    EndDate = newCampaign.EndDate,
            //    StartDate = newCampaign.StartDate,
            //    IsActive = newCampaign.IsActive,
            //    Name = newCampaign.Name
            //};

            //AFTER
            var tmpCampaign = _mapper.Map<Campaign>(newCampaign);

            await _campaignRepository.AddAsync(tmpCampaign);
            await _campaignRepository.CommitAsync();
            return newCampaign;
            //TODO : METHODLARIN NE DÖNMESİ GEREKTİĞİNİ ÖĞREN. CQS ???
        }

        public async Task<List<CampaignDto>> GetAllCampaign()
        {
            var campaignObjectList = await _campaignRepository.GetAllAsync();

            //BEFORE
            //var campaignDboList = campaignObjectList.Select(x => new CampaignDto
            //{
            //    Id = x.Id,
            //    Description = x.Description,
            //    EndDate = x.EndDate,
            //    StartDate = x.StartDate,
            //    IsActive = x.IsActive,
            //    Name = x.Name
            //}).ToList();

            //AFTER
            var campaignDtoList = _mapper.Map<List<CampaignDto>>(campaignObjectList);

            return campaignDtoList;
        }

        public async void DeleteCampaign(int id)
        {
            var tmpEntity = await _campaignRepository.GetByIdAsync(id);
            _campaignRepository.Remove(tmpEntity);
            await _campaignRepository.CommitAsync();

        }
    }
}
