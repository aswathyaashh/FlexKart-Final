using E_Commerce.core.ApplicationLayer.DTOModel.Customer;
using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;

namespace E_Commerce.core.ApplicationLayer.Interface
{
    public interface ICustomer
    {
        public ApiResponse<List<CustomerListDTO>> Get();

        public ApiResponse<int> Post(CustomerDTO customer);
    }
}
