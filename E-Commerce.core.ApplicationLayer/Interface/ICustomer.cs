using E_Commerce.core.ApplicationLayer.DTOModel;
using E_Commerce.core.ApplicationLayer.DTOModel.Customer;
using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;
using E_Commerce.core.ApplicationLayer.DTOModel.Order;
using E_Commerce.core.ApplicationLayer.DTOModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.core.ApplicationLayer.Interface
{
    public interface ICustomer 
    {
        public ApiResponse<List<CustomerDTO>> Get();
        public ApiResponse<bool> Delete(int customerId);
        public ApiResponse<bool> Post(CustomerDTO customer);
        public ApiResponse<bool> Update(int id, CustomerDTO customer);
    }
}
