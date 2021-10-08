using CampaignApi.Controllers;
using CampaignApi.Models;
using CampaignApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Campaign.Test
{
    public class CampaignController_Test
    {
        [Fact]
        public async void GetAll_Return_CampaignList()
        {
            var mockService = new Mock<ICampaignService>();
            var mockLog = new Mock<ILogger<CampaignController>>();

            //Controller içerisinde kullanılan campaignService objecti mocklandı.
            mockService.Setup(service => service.CreateProductGroup(It.IsAny<CampaignDto>())).ReturnsAsync(new CampaignDto { Id = 1 });

            var controller = new CampaignController(mockService.Object, mockLog.Object);

            var result = await controller.CreateCampaignAsync(new CampaignDto { Id = 1 });

            Assert.IsType<OkObjectResult>(result);

            var tmpResult = result as OkObjectResult;
            CampaignDto tmpDtoResult = tmpResult.Value as CampaignDto;

            Assert.Equal(1, tmpDtoResult.Id);
        }
    }
}
