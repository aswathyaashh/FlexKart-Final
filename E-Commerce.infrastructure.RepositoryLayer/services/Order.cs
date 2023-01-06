using AutoMapper;
using E_Commerce.core.ApplicationLayer.DTOModel;
using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;
using E_Commerce.core.ApplicationLayer.DTOModel.Order;
using E_Commerce.core.ApplicationLayer.DTOModel.SubCategory;
using E_Commerce.core.ApplicationLayer.Interface;
using E_Commerce.core.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.infrastructure.RepositoryLayer.services
{
    public class Order : IOrder
    {
        #region(Private Variables)
        private readonly AdminDbContext _adminDbContext;
        private readonly IMapper _mapper;
        #endregion

        #region(Constructor)
        public Order(AdminDbContext adminDbContext, IMapper mapper)
        {
            _adminDbContext = adminDbContext;
            _mapper = mapper;
        }
        #endregion
        public ApiResponse<List<OrderDTO>> Get()
        {
            //ApiResponse<List<OrderDTO>> response = new ApiResponse<List<OrderDTO>>();
            //var list = new List<OrderDTO>();
            //var data = _adminDbContext.Order.Include(x => x.CustomerModel).ToList();
            //if (data != null && data.Count > 0)
            //{
            //    foreach (var content in data)
            //    {

            //        OrderDTO orderDTO = new OrderDTO();
            //        orderDTO.OrderId = content.OrderId;
            //        orderDTO.CustomerName = content.CustomerModel.CustomerName;
            //        orderDTO.ProductId= content.ProductId;
            //        orderDTO.ProductName = content.ProductName;
            //        orderDTO.Status=content.Status;
            //        orderDTO.Quantity= content.Quantity;
            //        orderDTO.Price= content.Price;
            //        orderDTO.OrderDate=content.OrderDate;
            //        list.Add(orderDTO);
            //    }
            //    response.Message = "Listed";
            //    response.Success = true;
            //    response.Data = list;
            //    return response;
            //}
            //else
            //{
            //    response.Message = "Null";
            //    response.Success = false;
            //    return response;
            //}
            return null;
        }

        public ApiResponse<bool> Post(OrderDTO order)
        {
            //var customerId = _adminDbContext.Customer.Where(x => x.CustomerName == order.CustomerName).Select(x => x.CustomerId).FirstOrDefault();
            //ApiResponse<bool> Response = new ApiResponse<bool>();
            //if (customerId != null)
            //{
            //    var orderModel = new OrderModel1()
            //    {
            //        OrderId = order.OrderId,
            //        ProductId = order.ProductId,
            //        ProductName = order.ProductName,
            //        Status= order.Status,
            //        OrderDate = order.OrderDate,
            //        Quantity = order.Quantity,
            //        Price=order.Price,
            //        CustomerId= customerId,
            //        SalesforceOrderId= order.SalesforceOrderId
            //    };
            //    _adminDbContext.Add(orderModel);
            //    _adminDbContext.SaveChangesAsync();

            //    Response.Success = true;
            //    Response.Message = "Order is added";
            //    Response.Data = true;
            //    return Response;
            //}
            //else
            //{
            //    Response.Success = false;
            //    Response.Message = "Order is not added";
            //    Response.Data = false;
            //    return Response;
            //}
            return null;

        }

        public ApiResponse<bool> Update(int id, OrderDTO order)
        {
            //    var update = _adminDbContext.Order.FirstOrDefault(e => e.OrderId == id);
            //    ApiResponse<bool> updateResponse = new ApiResponse<bool>();

            //    if (update == null)
            //    {
            //        updateResponse.Success = false;
            //        updateResponse.Message = "Order doesnt exist";
            //        updateResponse.Data = false;
            //        return updateResponse;
            //    }
            //    else
            //    {
            //        var orderId = _adminDbContext.Order.Select(x => x.OrderId).FirstOrDefault();


            //        if (orderId == null)
            //        {
            //            updateResponse.Success = false;
            //            updateResponse.Message = "Customer doesnt exist";
            //            updateResponse.Data = false;
            //            return updateResponse;
            //        }
            //        else
            //        {
            //            updateResponse.Success = true;
            //            updateResponse.Message = "Updated";
            //            updateResponse.Data = true;
            //            //update.SubCategoryName = subCategory.SubCategoryName;
            //           // update.CustomerId = customerId;
            //            update.Status = order.Status;
            //            // update.UpdatedDate = DateTime.Now;
            //            _adminDbContext.Update(update);
            //            _adminDbContext.SaveChanges();
            //            return updateResponse;
            //        }
            //    }
            //}
            return null;
        }
    }
}
