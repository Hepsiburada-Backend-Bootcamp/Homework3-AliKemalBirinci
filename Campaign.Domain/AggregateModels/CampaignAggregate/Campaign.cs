using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampaignApi.Models.Entities
{
    public class Campaign
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<ProductGroup> ProductGroups { get; set; }
        public ICollection<Store> Stores { get; set; }
    }
}
