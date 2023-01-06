//using Castle.Components.DictionaryAdapter;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.core.DomainLayer.Entities
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string ProductName { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string Status { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("CustomerModel")]
        public int CustomerId { get; set; }
        public CustomerModel CustomerModel { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string SalesForceId { get; set; }

    }
}
