using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.core.ApplicationLayer.DTOModel.Customer
{
    public class CustomerListDTO
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string SalesForceCustomerId { get; set; }
    }
}
