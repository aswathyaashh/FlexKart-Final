using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using E_Commerce.core.ApplicationLayer.Interface;
using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;
using E_Commerce.core.ApplicationLayer.DTOModel.SubCategory;

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

        #region(GetSubCategory)
        /// <summary>  
        /// API to Get all data  
        /// </summary>  
        /// <returns>API for calling function to list subcategories with their id</returns>  
        [HttpGet]
        [Route("get")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<List<SubCategoryDTO>>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get all List", Description = "Get SubCategory List")]
        public ApiResponse<List<SubCategoryDTO>> GetSubCategory()
        {
            return _subCategory.Get();
        }
        #endregion

        #region(DeleteSubCategory)
        /// <summary>  
        ///  API for Delete SubCategory   
        /// </summary>  
        /// <param API for setting status field in database as one when subcategory deleted</param> 
        [HttpDelete]
        [Route("delete/{subCategoryId}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Delete SubCategory", Description = "Delete specified SubCategory by id")]
        public ApiResponse<bool> DeleteSubCategory(int subCategoryId)
        {
            return _subCategory.Delete(subCategoryId);
        }
        #endregion

        #region(AddSubCategory)
        /// <summary>  
        ///  API for Adding SubCategory   
        /// </summary>  
        /// <param API to add subcategory name in database</param> 
        [HttpPost]
        [Route("Post")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Posts new subcategory", Description = "Adds a new SubCategory")]
        public Task<ApiResponse<bool>> AddSubCategory([FromBody] SubCategoryDTO Subcategory)
        {
            return _subCategory.Post(Subcategory);
        }
        #endregion

        #region(GetSubCategory By Name)
        /// <summary>  
        ///  Get SubCategory by name  
        /// </summary>  
        /// <param Display subcategory exist if it is subcategory existing otherwise SubCategory doesnt exists </param> 
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Gets SubCategory By Name", Description = "Checks if subcategory exists")]
        public ApiResponse<bool> GetSubCategoryByName(string subcategoryName,int categoryId)
        {
            return _subCategory.GetBySubCategoryName(subcategoryName, categoryId);
        }
        #endregion

        #region(EditSubCategory)
        /// <summary>  
        /// API for Editing SubCategory   
        /// </summary>  
        /// <param API to edit subcategory name in database</param> 
        [HttpPut]
        [Route("Edit")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Edit new subcategory", Description = "Edit a new subCategory")]
        public Task<ApiResponse<bool>> EditSubCategory(int id, SubCategoryDTO subCategory)
        {
            return _subCategory.Update(id, subCategory);
        }
        #endregion

    }
}
