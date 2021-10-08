using CampaignApi.Models;
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
    public class CampaignController : ControllerBase
    {
        private ICampaignService _campaignService;
        private readonly ILogger<CampaignController> _logger;

        public CampaignController(ICampaignService campaignService, ILogger<CampaignController> logger)
        {
            _campaignService = campaignService;
            _logger = logger;
            logger.LogInformation("Hello first log in CampaignController Constructor");
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateCampaignAsync([FromBody] CampaignDto campaign)
        {
            var result = await _campaignService.CreateProductGroup(campaign);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CampaignDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetCampaignsAsync()
        {
            var campaign = await _campaignService.GetAllCampaign();

            if (campaign is not null)
            {
                return Ok(campaign);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult DeleteCampaignAsync(int id)
        {
            _campaignService.DeleteCampaign(id);

            return Ok();
        }

    }
}
