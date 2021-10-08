using System.ComponentModel.DataAnnotations;

namespace CampaignApi.Models.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int ProductGroupId { get; set; }
        public ProductGroup ProductGroup { get; set; }
    }
}
