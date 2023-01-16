using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.core.DomainLayer.Entities
{
    public class ImageModel
    {
        [Key]
        public int ImageId { get; set; }

        [ForeignKey("ProductModel")]
        public int ProductId { get; set; }
        public ProductModel ProductModel { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string ImageName { get; set; }
        public int Priority { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string ImagePath { get; set; }

        [NotMapped]
        public string ImageSrc { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow;


    }
}
