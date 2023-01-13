using System.ComponentModel.DataAnnotations;

namespace E_Commerce.core.DomainLayer.Entities
{
    public class CustomerModel
    {
        [Key]
        public int CustomerId { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string SalesForceCustomerId { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string CustomerName { get; set; }
        public int Status { get; set; }

     


    }
}
