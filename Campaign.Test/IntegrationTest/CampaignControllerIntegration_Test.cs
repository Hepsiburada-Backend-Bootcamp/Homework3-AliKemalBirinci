using Campaign.Test.IntegrationTest;
using CampaignApi.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Xunit;

namespace Campaign.Test
{
    public class CampaignControllerIntegration_Test : IClassFixture<CampaignApiFactory>
    {
        private readonly WebApplicationFactory<TestStartup> _factory;

        public CampaignControllerIntegration_Test(CampaignApiFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void Post_Should_Return_Ok_Result_Then_Get_Added_Data()
        {
            var campaign = new CampaignDto
            {
                Description = "testDataDesc",
                EndDate = DateTime.Now.AddMonths(-1),
                IsActive = true,
                Id = 61,
                Name = "CampaignTest",
                StartDate = DateTime.Now.AddMonths(3)
            };

            var json = JsonSerializer.Serialize(campaign);

            var client = _factory.CreateClient();

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var postResponse = await client.PostAsync("api/v1/campaign", content);

            var actualStatusCode = postResponse.StatusCode;

            Assert.Equal(HttpStatusCode.OK, actualStatusCode);

            var responseContent = await postResponse.Content.ReadAsStringAsync();

            var okResult = JsonSerializer.Deserialize<JsonElement>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Assert.Equal("CampaignTest", okResult.GetProperty("name").ToString());

            var getAllResponse = await client.GetAsync("api/v1/campaign");

            getAllResponse.EnsureSuccessStatusCode(); //dönen datanın Ok olup olmadıgını kontrol eden func.

            var campaignListData = await getAllResponse.Content.ReadAsStringAsync();

            var campaignList = JsonSerializer.Deserialize<List<CampaignDto>>(campaignListData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Assert.NotNull(campaignList);
            Assert.NotEmpty(campaignList);

            var addedCampaign = campaignList.First(x => x.Id == 61);

            Assert.NotNull(addedCampaign);
        }
    }
}
