using CampaignApi.Models.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Campaign.Test
{
    public class CampaignRepository_Test : IClassFixture<CampaignRepository_Test>
    {
        private Mock<ICampaignRepository> _mock;

        public CampaignRepository_Test()
        {
            _mock = new Mock<ICampaignRepository>();
        }

        [Fact]
        public async void GetAll_Return_CampaignList()
        {
            //Arrange
            //var campaignRepositoryMock = new Mock<ICampaignRepository>();
            //DI üzerinden set edildi.

            var list = GetAllCampaign();
            _mock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(list);
            ICampaignRepository campaignRepository = _mock.Object;

            //Act
            var result = (await campaignRepository.GetAllAsync()).ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(list.Count, result.Count);
        }

        [Fact]
        public async void GetByIdAsync_Return_Campaign()
        {
            //Arrange
            _mock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new CampaignApi.Models.Entities.Campaign { Id = 1 });
            ICampaignRepository campaignRepository = _mock.Object;

            //Act
            var result = (await campaignRepository.GetByIdAsync(1));

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void Remove_Campaign()
        {
            //Arrange
            var list = GetAllCampaign();
            var listCount = list.Count;
            _mock.Setup(repo => repo.Remove(It.IsAny<CampaignApi.Models.Entities.Campaign>())).Callback((CampaignApi.Models.Entities.Campaign campaign) =>
            {
                var tmpItem = list.FirstOrDefault(x => x.Id == campaign.Id);
                list.Remove(tmpItem);
            });

            //Act
            var campaignRepository = _mock.Object;
            campaignRepository.Remove(new CampaignApi.Models.Entities.Campaign { Id = 1 });

            //Assert
            Assert.True(listCount > list.Count);
            Assert.Null(list.FirstOrDefault(x => x.Id == 1));
        }

        private List<CampaignApi.Models.Entities.Campaign> GetAllCampaign()
        {
            List<CampaignApi.Models.Entities.Campaign> campaigns = new();

            for (int i = 0; i < 5; i++)
            {
                CampaignApi.Models.Entities.Campaign campaign = new();
                campaign.Description = "campaign" + i;
                campaign.EndDate = DateTime.Now.AddMonths(i);
                campaign.StartDate = DateTime.Now.AddMonths(i * -1);
                campaign.Id = i;
                campaign.IsActive = true;
                campaign.Name = "campaign" + i;

                campaigns.Add(campaign);
            }

            return campaigns;
        }
    }
}
