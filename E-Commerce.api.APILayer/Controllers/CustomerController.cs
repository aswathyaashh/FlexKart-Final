using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;
using E_Commerce.core.ApplicationLayer.DTOModel;
using E_Commerce.core.ApplicationLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using E_Commerce.core.ApplicationLayer.DTOModel.Customer;

namespace E_Commerce.api.APILayer.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        [Authorize]
        [Consumes("application/json", MediaTypeNames.Application.Xml)]
        [Produces("application/json", MediaTypeNames.Application.Xml)]
        public class CustomerController : ControllerBase
        {
            private readonly ICustomer _customer;

            public CustomerController(ICustomer customer)
            {
            _customer = customer;
            }

            #region(Get)

            /// <summary>  
            /// API to Get all data  
            /// </summary>  
            /// <returns>API for calling function to list customers with their id</returns>  
            [HttpGet]
            [AllowAnonymous]
            [SwaggerResponse(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(typeof(ApiResponse<List<CustomerDTO>>), StatusCodes.Status200OK)]
            [SwaggerOperation(Summary = "Get all List", Description = "Get Customers List")]
            public ApiResponse<List<CustomerDTO>> Get()
            {
                return _customer.Get();
            }

            #endregion

            #region(Delete Customer)
            /// <summary>  
            ///  API for Delete Customer   
            /// </summary>  
            /// <param API for setting status field in database as one when customer deleted</param> 
            [HttpDelete]
            [AllowAnonymous]
            [Route("delete/{customerId}")]
            [SwaggerResponse(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
            [SwaggerOperation(Summary = "Delete customer", Description = "Delete specific customer by id")]
            public ApiResponse<bool> Delete(int customerId)
            {
                return _customer.Delete(customerId);
            }
            #endregion

            #region(Post)
            /// <summary>  
            ///  API for Adding customer   
            /// </summary>  
            /// <param API to add customer name in database</param> 
            [HttpPost("Add")]
            [Route("Add")]
            [AllowAnonymous]
            [SwaggerResponse(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
            [SwaggerOperation(Summary = "Posts new customer", Description = "Adds a new customer")]
            public ApiResponse<bool> AddCustomer(CustomerDTO customerDTO)
            {
                return _customer.Post(customerDTO);
            }
            #endregion

            #region(Put)
            /// <summary>  
            /// API for Editing customer   
            /// </summary>  
            /// <param API to edit customer name in database</param> 
            [HttpPut("{id}")]
            [Route("Edit/{CustomerId}")]
            [AllowAnonymous]
            [SwaggerResponse(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
            [SwaggerOperation(Summary = "Edit new customer", Description = "Edit a new customer")]
            public ApiResponse<bool> EditCustomer(int id, CustomerDTO customerDTO)
            {
                return _customer.Update(id, customerDTO);
            }
            #endregion

        }
    }

