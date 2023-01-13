using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.core.DomainLayer.Entities
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string SalesforceOrderId { get; set; } 

        [ForeignKey("ProductModel")]
        public int ProductId { get; set; }
        public ProductModel ProductModel { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string Status { get; set; }
        public DateTime OrderDate { get; set; } 
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("CustomerModel")]
        public int CustomerId { get; set; }
        public CustomerModel CustomerModel { get; set; }             

    }
}
