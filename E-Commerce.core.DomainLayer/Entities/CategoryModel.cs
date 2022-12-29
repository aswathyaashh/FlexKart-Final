
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
        public DateTime CreatedDate { get; set; }  = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public CategoryModel()
        {
            //CreatedDate = DateTime.UtcNow;
            //UpdatedDate = DateTime.UtcNow;
        }
        //public ICollection<ProductModel> Products { get; set; }
        
        public int SalesForceId { get; set; }

    }
}
