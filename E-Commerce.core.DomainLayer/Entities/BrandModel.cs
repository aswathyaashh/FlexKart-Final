using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.core.DomainLayer.Entities
{
    public class BrandModel
    {
        [Key]
        [Column(Order = 0)]
        public int BrandId { get; set; } = 0;

        [Column(Order = 1)]
        [StringLength(30, MinimumLength = 3)]
        public string BrandName { get; set; }

        [NotMapped]
        public IFormFile Logo { get; set; } 

        [Column(Order = 2)]
        [StringLength(30, MinimumLength = 3)]
        public string LogoPath { get; set; }

        [NotMapped]
        public string ImageSrc { get; set; }
        
        [Column(Order = 3)]
        public int Status { get; set; }
        [Column(Order = 4)]
        public DateTime? CreatedDate { get; set; } 
        [Column(Order = 5)]
        public DateTime? UpdatedDate { get; set; } 

        [StringLength(30, MinimumLength = 3)]
        public string SalesForceId { get; set; }
    }
}
