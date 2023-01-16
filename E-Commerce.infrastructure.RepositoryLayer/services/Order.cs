using AutoMapper;
using Microsoft.EntityFrameworkCore;
using E_Commerce.core.DomainLayer.Entities;
using E_Commerce.core.ApplicationLayer.Interface;
using E_Commerce.core.ApplicationLayer.DTOModel.Order;
using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;


namespace E_Commerce.infrastructure.RepositoryLayer.services
{
    public class Order : IOrder
    {
        #region(Private Variables)

        private readonly IMapper _mapper;
        private readonly AdminDbContext _adminDbContext;

        #endregion

        #region(Constructor)
        public Order(AdminDbContext adminDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _adminDbContext = adminDbContext;
        }

        #endregion

        #region(Get Order Details)

        /// <summary>  
        /// Gets all data of order details 
        /// </summary>  
        /// <returns>collection of Products.</returns> 
        public ApiResponse<List<OrderListDTO>> Get()
        {
            ApiResponse<List<OrderListDTO>> response = new ApiResponse<List<OrderListDTO>>();
            var list = new List<OrderListDTO>();
            var data = _adminDbContext.Order.Include(x => x.CustomerModel).Include(y => y.ProductModel).ToList();
            if (data != null && data.Count > 0)
            {
                foreach (var content in data)
                {
                    OrderListDTO orderListDTO = new OrderListDTO();
                    orderListDTO.OderId = content.OrderId;
                    orderListDTO.OrderDate = content.OrderDate;
                    orderListDTO.Status = content.Status;
                    orderListDTO.Quantity = content.Quantity;
                    orderListDTO.Price = content.Price;
                    orderListDTO.SalesforceOrderId = content.SalesforceOrderId;
                    orderListDTO.CustomerName = content.CustomerModel.CustomerName;
                    orderListDTO.ProductName = content.ProductModel.ProductName;
                    list.Add(orderListDTO);
                }
                response.Message = "Order Listed";
                response.Success = true;
                response.Data = list;
                return response;
            }
            else
            {
                response.Message = "Null";
                response.Success = false;
                return response;
            }
        }
        #endregion

        #region(Post Order)
        /// <summary>  
        ///  Add Order Details
        /// </summary>  
        /// <param Add Order details in database</param> 

        public ApiResponse<bool> Post(OrderDTO order)
        {
            var customerId = _adminDbContext.Customer.Where(x => x.CustomerId == order.CustomerId).FirstOrDefault();
            var productId = _adminDbContext.Product.Where(x => x.ProductId == order.ProductId).FirstOrDefault();
            ApiResponse<bool> Response = new ApiResponse<bool>();
            if (customerId != null && productId != null)
            {
                var orderModel = new OrderModel()
                {
                    ProductId = productId.ProductId,
                    Status = order.Status,
                    OrderDate = order.OrderDate,
                    Quantity = order.Quantity,
                    Price = order.Price,
                    CustomerId = customerId.CustomerId,
                    SalesforceOrderId = order.SalesforceOrderId
                };
                _adminDbContext.Add(orderModel);
                _adminDbContext.SaveChanges();

                Response.Success = true;
                Response.Message = "Order is added";
                Response.Data = true;
                return Response;
            }
            else
            {
                Response.Success = false;
                Response.Message = "Order is not added";
                Response.Data = false;
                return Response;
            }
        }
        #endregion

    }
}