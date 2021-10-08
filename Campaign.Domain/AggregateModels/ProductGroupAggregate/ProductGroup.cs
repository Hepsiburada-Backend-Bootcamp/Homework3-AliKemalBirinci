using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampaignApi.Models.Entities
{
    public class ProductGroup
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Campaign> Campaigns { get; set; }
    }
}
