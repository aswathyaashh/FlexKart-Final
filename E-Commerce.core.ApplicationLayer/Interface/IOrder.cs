using E_Commerce.core.ApplicationLayer.DTOModel.Order;
using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;

namespace E_Commerce.core.ApplicationLayer.Interface
{
    public interface IOrder
    {
        public ApiResponse<List<OrderListDTO>> Get();
        public ApiResponse<bool> Post(OrderDTO order);

    }
}
