using CampaignApi.Models.Dtos;
using CampaignApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CampaignApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        private readonly ILogger<CampaignController> _logger;

        public ProductController(IProductService productService, ILogger<CampaignController> logger)
        {
            _productService = productService;
            _logger = logger;
            logger.LogInformation("Hello first log in ProductController Constructor");
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetProductsAsync()
        {
            var result = await _productService.GetAllAsync();
            return Ok(result);
        }

        [Route("{productId:int}")]
        [HttpGet]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var product = await _productService.GetByIdAsync(productId);

            if (product is not null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
