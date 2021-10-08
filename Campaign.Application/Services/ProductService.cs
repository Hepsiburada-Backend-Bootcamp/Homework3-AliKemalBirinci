using AutoMapper;
using CampaignApi.Models.Dtos;
using CampaignApi.Models.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CampaignApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CampaignService> _logger;

        public ProductService(IProductRepository productRepository, IMapper mapper, ILogger<CampaignService> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<ProductDto>> GetAllAsync()
        //{
        //    var productObjectList = await _productRepository.GetAllWithDapper();
        //    var productDtoList = _mapper.Map<List<ProductDto>>(productObjectList);

        //    return productDtoList;
        //}

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var productObject = await _productRepository.GetByIdWithDapper(id);
            var productDto = _mapper.Map<ProductDto>(productObject);

            return productDto;
        }
    }
}
