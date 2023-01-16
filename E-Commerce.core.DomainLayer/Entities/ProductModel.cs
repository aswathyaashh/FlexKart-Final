using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.core.DomainLayer.Entities
{
    public class ProductModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; } = 0;

        [StringLength(30, MinimumLength = 3)]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }= DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow;

        [ForeignKey("SubCategoryModel")]
        public int SubCategoryId { get; set; }
        public SubCategoryModel SubCategoryModel { get; set; }

        [ForeignKey("BrandModel")]
        public int BrandId { get; set; }
        public BrandModel BrandModel { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string SalesForceId { get; set; }

    }
}
