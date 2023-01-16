using System.ComponentModel.DataAnnotations;

namespace E_Commerce.core.DomainLayer.Entities
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; } = 0;
        [StringLength(30, MinimumLength = 3)]
        public string CategoryName { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; } 

        [StringLength(30, MinimumLength = 3)]
        public string SalesForceId { get; set; }

    }
}
