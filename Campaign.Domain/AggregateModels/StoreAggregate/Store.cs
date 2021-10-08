using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampaignApi.Models.Entities
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public ICollection<Campaign> Campaigns { get; set; }
    }
}
