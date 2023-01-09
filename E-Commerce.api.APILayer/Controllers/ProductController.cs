using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;
using E_Commerce.core.ApplicationLayer.DTOModel.Image;
using E_Commerce.core.ApplicationLayer.DTOModel.Product;
using E_Commerce.core.ApplicationLayer.DTOModel.SubCategory;
using E_Commerce.core.ApplicationLayer.Interface;
using E_Commerce.infrastructure.RepositoryLayer.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceStack;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace E_Commerce.api.APILayer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [Consumes("application/json", MediaTypeNames.Application.Xml)]
    [Produces("application/json", MediaTypeNames.Application.Xml)]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _product;
        public ProductController(IProduct product)
        {
            _product = product;
        }

        #region(Get)
        /// <summary>  
        /// API to Get all data  
        /// </summary>  
        /// <returns>API for calling function to list products with their id</returns>  
        [HttpGet]
        [Route("get")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<List<ProductListDTO>>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get all List", Description = "Get Product List")]
        public ApiResponse<List<ProductListDTO>> Get()
        {
            return _product.Get();
        }
        #endregion

        #region(Post)
        /// <summary>  
        ///  API for Adding Product  
        /// </summary>  
        /// <param API to add Product name in database</param> 
        [HttpPost]
        [Route("AddProduct")]
        [Consumes("multipart/form-data")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Posts new Product", Description = "Adds a new Product")]

        public async Task<ApiResponse<bool>> AddProduct([FromForm] ProductDTO Product)
        {
            return await _product.Post(Product, Request.Scheme, Request.Host, Request.PathBase);

        }
        #endregion

        #region(Delete Product)
        /// <summary>  
        ///  API for Delete Product   
        /// </summary>  
        /// <param API for setting status field in database as one when product deleted</param> 
        [HttpDelete]
        [AllowAnonymous]
        [Route("delete/{productId}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Delete Product", Description = "Delete specified Product by id")]
        public ApiResponse<bool> Delete(int productId)
        {
            return _product.Delete(productId);
        }
        #endregion

        #region(get Product By Name)
        /// <summary>  
        ///  Get Product by name  
        /// </summary>  
        /// <param Display product exist if it is product existing otherwise product doesnt exists </param> 
        [HttpGet]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Gets product By Name", Description = "Checks if product exists")]
        public ApiResponse<bool> GetProductByName(string productName)
        {
            return _product.GetByProductName(productName);
        }
        #endregion

        #region(get Product By Id)
        /// <summary>  
        ///  Get Product by id  
        /// </summary>  
        /// <param Display product details by id </param> 
        [HttpGet]
        [Route("getById")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Product View", Description = "Display product details by its id")]
        public ApiResponse<List<ProductViewDTO>> GetProductById(int id)
        {
            return _product.GetProductById(id, Request.Scheme, Request.Host, Request.PathBase);
        }
        #endregion

        #region(Put)
        /// <summary>  
        /// API for Editing Product   
        /// </summary>  
        /// <param API to edit product name in database</param> 
        [HttpPut]
        [Route("EditProduct/{id}")]
        [Consumes("multipart/form-data")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Edit new product", Description = "Edit a new product")]
        public async Task<ApiResponse<bool>> EditProduct(string id, [FromForm] ProductDTO productDTO)
        {

            return await _product.Update(id.ToInt(), productDTO);

        }
        #endregion

        #region(get SubcategoryList By Category )
        /// <summary>  
        ///  Get Subcategory by category id 
        /// </summary>  
        /// <param Display subcategory details by category id </param> 
        [HttpGet]
        [Route("getBySubcategory")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Subcategory listing", Description = "Display product details by its id")]
        public ApiResponse<List<SubCategoryDTO>> GetBySubcategory(int id)
        {
            return _product.GetSubcategory(id);
        }
        #endregion


    }
}




