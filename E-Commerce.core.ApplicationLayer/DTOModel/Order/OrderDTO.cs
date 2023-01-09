using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.core.ApplicationLayer.DTOModel.Order
{
    public class OrderDTO
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Status { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string SalesforceOrderId { get; set; }
    }
}
