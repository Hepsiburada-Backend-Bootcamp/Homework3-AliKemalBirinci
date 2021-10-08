using CampaignApi.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampaignApi.Models
{
    public class CampaignDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //public List<ProductGroup> ProductGroups { get; set; }
        //public List<Store> Stores { get; set; }
    }
}
