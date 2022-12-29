using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;
using E_Commerce.core.ApplicationLayer.DTOModel.Order;
using E_Commerce.core.ApplicationLayer.DTOModel.SubCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.core.ApplicationLayer.Interface
{
    public interface IOrder
    {
        public ApiResponse<List<OrderDTO>> Get();
        public ApiResponse<bool> Post(OrderDTO order);
        public ApiResponse<bool> Update(int id, OrderDTO order);

    }
}
