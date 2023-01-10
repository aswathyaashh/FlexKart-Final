using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;
using E_Commerce.core.ApplicationLayer.DTOModel.Order;
using E_Commerce.core.ApplicationLayer.DTOModel.SubCategory;
using E_Commerce.core.ApplicationLayer.Interface;
using E_Commerce.infrastructure.RepositoryLayer.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace E_Commerce.api.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [Consumes("application/json", MediaTypeNames.Application.Xml)]
    [Produces("application/json", MediaTypeNames.Application.Xml)]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _order;

        public OrderController(IOrder order)
        {
            _order = order;
        }

        #region(Get)
        /// <summary>  
                    /// API to Get all data  
                    /// </summary>  
                    /// <returns>API for calling function to list orders with their id</returns>  
        [HttpGet]
        [Route("get")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<List<OrderDTO>>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get all List", Description = "Get order List")]
        public ApiResponse<List<OrderListDTO>> Get()
        {
            return _order.Get();
        }
        #endregion


        #region(Post)
        /// <summary>  
                    ///  API for Adding SubCategory   
                    /// </summary>  
                    /// <param API to add subcategory name in database</param> 
        [HttpPost]
        [Route("AddOrder")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Posts new order", Description = "Adds a new order")]
        public ApiResponse<bool> AddOrder([FromBody] OrderDTO Order)
        {
            return _order.Post(Order);
        }
        #endregion



    }
}

