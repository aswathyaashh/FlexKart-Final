using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using E_Commerce.core.ApplicationLayer.Interface;
using E_Commerce.core.ApplicationLayer.DTOModel.Brand;
using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;

namespace E_Commerce.api.APILayer.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrand _brand;
        public BrandController(IBrand brand)
        {
            _brand = brand;
        }

        #region(GetBrand)
        /// <summary>  
        /// API to Get all data  
        /// </summary>  
        /// <returns>API for calling function to list Brand with their id</returns>  
        [HttpGet]
        [Route("GetBrand")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<List<BrandDTO>>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get all List", Description = "Get Brand List")]
        public ApiResponse<List<BrandDTO>> GetBrand()
        {
            return _brand.Get(Request.Scheme, Request.Host, Request.PathBase);
        }

        #endregion

        #region(PostBrand)
        /// <summary>  
        ///  API for Adding Brand   
        /// </summary>  
        /// <param API to add brand name in database</param> 
        [HttpPost]
        [Route("PostBrand")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Create brand", Description = "Add Brand name and brand logo path")]

        public async Task<ApiResponse<bool>> PostBrand([FromForm] string brandName, IFormFile logo)
        {
            var brand = new BrandDTO();
            brand.BrandName = brandName;
            brand.Logo = logo;
            return await _brand.Post(brand);
        }

        #endregion

        #region(GetBrand by name)
        /// <summary>  
        /// API to get brand by name  
        /// </summary>  
        /// <param API to display existing brand name</param>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get brand by name", Description = "success true if brand not exist")]
        public ApiResponse<bool> GetByBrandName(string brandName)
        {
            return _brand.GetByBrandName(brandName);
        }

        #endregion

        #region(PutBrand)
        /// <summary>  
        ///  API for Update brand  
        /// </summary>  
        /// <param API to Edit brand name and logo path in database</param>
        [HttpPut]
        [Route("EditBrand")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Update brand by Id", Description = "success true if brand not exist")]
        public Task<ApiResponse<bool>> UpdateBrand(int id, [FromForm] string brandName, IFormFile logo)
        {
            var updateDetails = new BrandDTO();
            updateDetails.BrandName = brandName;
            updateDetails.Logo = logo;
            updateDetails.BrandId = id;
            return _brand.Update(updateDetails);
        }
        #endregion

        #region(DeleteBrand)
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
        public ApiResponse<bool> DeleteBrand(int brandId)
        {
            return _brand.Delete(brandId);
        }
        #endregion

    }

}
