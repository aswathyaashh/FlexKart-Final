using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;
using E_Commerce.core.ApplicationLayer.DTOModel.SubCategory;
using E_Commerce.core.ApplicationLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace E_Commerce.api.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [Consumes("application/json", MediaTypeNames.Application.Xml)]
    [Produces("application/json", MediaTypeNames.Application.Xml)]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategory _subCategory;

        public SubCategoryController(ISubCategory subCategory)
        {
            _subCategory = subCategory;
        }

        #region(Get)
        /// <summary>  
        /// API to Get all data  
        /// </summary>  
        /// <returns>API for calling function to list subcategories with their id</returns>  
        [HttpGet]
        [Route("get")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<List<SubCategoryDTO>>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get all List", Description = "Get SubCategory List")]
        public ApiResponse<List<SubCategoryDTO>> Get()
        {
            return _subCategory.Get();
        }
        #endregion

        #region(Delete SubCategory)
        /// <summary>  
        ///  API for Delete SubCategory   
        /// </summary>  
        /// <param API for setting status field in database as one when subcategory deleted</param> 
        [HttpDelete]
        [AllowAnonymous]
        [Route("delete/{subCategoryId}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Delete SubCategory", Description = "Delete specified SubCategory by id")]
        public ApiResponse<bool> Delete(int subCategoryId)
        {
            return _subCategory.Delete(subCategoryId);
        }
        #endregion

        #region(Post)
        /// <summary>  
        ///  API for Adding SubCategory   
        /// </summary>  
        /// <param API to add subcategory name in database</param> 
        [HttpPost]
        [Route("Post")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Posts new subcategory", Description = "Adds a new SubCategory")]
        public ApiResponse<bool> AddSubCategory([FromBody] SubCategoryDTO Subcategory)
        {
            return _subCategory.Post(Subcategory);
        }
        #endregion

        #region(get SubCategoryName By Name)
        /// <summary>  
        ///  Get SubCategory by name  
        /// </summary>  
        /// <param Display subcategory exist if it is subcategory existing otherwise SubCategory doesnt exists </param> 
        [HttpGet]
        [AllowAnonymous]
       // [Route("SubCategoryName/{subcategoryName}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Gets SubCategory By Name", Description = "Checks if subcategory exists")]
        public ApiResponse<bool> GetSubCategoryByName(string subcategoryName)
        {
            return _subCategory.GetBySubCategoryName(subcategoryName);
        }
        #endregion

        #region(Put)
        /// <summary>  
        /// API for Editing SubCategory   
        /// </summary>  
        /// <param API to edit subcategory name in database</param> 
        [HttpPut]
        [Route("Edit")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Edit new subcategory", Description = "Edit a new subCategory")]
        public ApiResponse<bool> EditSubCategory(int id, SubCategoryDTO subCategory)
        {
            return _subCategory.Update(id, subCategory);
        }
        #endregion


    }
}
