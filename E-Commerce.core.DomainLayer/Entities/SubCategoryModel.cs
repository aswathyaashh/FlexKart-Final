using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.core.DomainLayer.Entities
{
    public class SubCategoryModel
    {
        [Key]
        public int SubCategoryId { get; set; } = 0;
        [StringLength(30, MinimumLength = 3)]
        public string SubCategoryName { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; } 
        public DateTime? UpdatedDate { get; set; } 

        [ForeignKey("CategoryModel")]
        public int CategoryId { get; set; }
        public CategoryModel CategoryModel { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string SalesForceId { get; set; }

    }

}
