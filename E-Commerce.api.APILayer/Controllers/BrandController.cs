using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using E_Commerce.core.ApplicationLayer.Interface;
using E_Commerce.core.ApplicationLayer.DTOModel.Brand;
using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;
using E_Commerce.core.ApplicationLayer.DTOModel;
using ServiceStack;
using System.Collections.Generic;
using E_Commerce.core.ApplicationLayer.Interface.Salesforce;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce.api.APILayer.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IBrand _brand;
        //private readonly ISalesConnection _connection;
        public BrandController(IBrand brand, IConfiguration configuration)
        {
            _brand = brand;
            _configuration = configuration;
           
        }
        #region(Get)
        /// <summary>  
        /// API to Get all data  
        /// </summary>  
        /// <returns>API for calling function to list Brand with their id</returns>  
        [HttpGet]
        [Route("get")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<List<BrandDTO>>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get all List", Description = "Get Brand List")]
        public ApiResponse<List<BrandDTO>> Get()
        {
            return _brand.Get(Request.Scheme, Request.Host, Request.PathBase);
        }

        #endregion

        #region(Post)
        /// <summary>  
        ///  API for Adding Brand   
        /// </summary>  
        /// <param API to add brand name in database</param> 
        [HttpPost]
        [AllowAnonymous]
        [Route("post")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Create brand", Description = "Add Brand name and brand logo path")]

        public async Task<ApiResponse<bool>> Post([FromForm] string brandName, IFormFile logo)
        {
            //_connection.Authentication();
           // var values = _configuration.value.BuyerConfig;
            var brand = new BrandDTO();
            brand.BrandName = brandName;
            brand.Logo = logo;
            return await _brand.Post(brand);
        }

        //USING OBJECT
        //public async Task<ApiResponse<bool>> Post(BrandDTO brandDTO)
        //{
        //    BrandDTO brand = new BrandDTO();
        //    brand.BrandName = brandDTO.BrandName;
        //    brand.Logo = brandDTO.Logo;
        //    return await _brand.Post(brandDTO);
        //}
        #endregion

        #region(Brand by name)
        /// <summary>  
        /// API to get brand by name  
        /// </summary>  
        /// <param API to display existing brand name</param>
        [HttpGet]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get brand by name", Description = "success true if brand not exist")]
        public ApiResponse<bool> GetByBrandName(string brandName)
        {
            return _brand.GetByBrandName(brandName);
        }

        #endregion

        #region(put)
        /// <summary>  
        ///  API for Update brand  
        /// </summary>  
        /// <param API to Edit brand name and logo path in database</param>
        [HttpPut]
        [Route("Edit")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Update brand by Id", Description = "success true if brand not exist")]
        public Task<ApiResponse<bool>> Update(int id,[FromForm]string brandName, IFormFile logo)
        {
            var updateDetails = new BrandDTO();
            updateDetails.BrandName = brandName;
            updateDetails.Logo = logo;
            updateDetails.BrandId = id;
            return _brand.Update(updateDetails);
        }
        #endregion

        #region( Delete Brand )
        /// <summary>  
        ///  API for Delete Brand   
        /// </summary>  
        /// <param API for setting status field in database as one when brand deleted</param> 
        [HttpDelete]
        [AllowAnonymous]
        [Route("delete/{brandId}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Delete Brand", Description = "Delete specified brand by id")]
        public ApiResponse<bool> Delete(int brandId)
        {
            return _brand.Delete(brandId);
        }
        #endregion



    }

}
