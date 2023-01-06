using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using E_Commerce.core.ApplicationLayer.Interface;
using E_Commerce.core.ApplicationLayer.DTOModel;
using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce.api.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [Consumes("application/json", MediaTypeNames.Application.Xml)]
    [Produces("application/json", MediaTypeNames.Application.Xml)]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _category;

        public CategoryController(ICategory category)
        {
            _category = category;
        }

        #region(Get)

        /// <summary>  
        /// API to Get all data  
        /// </summary>  
        /// <returns>API for calling function to list categories with their id</returns>  
        [HttpGet]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<List<CategoryDTO>>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get all List", Description = "Get Category List")]
        public ApiResponse<List<CategoryDTO>> Get()
        {
            return _category.Get();
        }

        #endregion

        #region(Delete Category)
        /// <summary>  
        ///  API for Delete Category   
        /// </summary>  
        /// <param API for setting status field in database as one when category deleted</param> 
        [HttpDelete]
        [AllowAnonymous]
        [Route("delete/{categoryId}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Delete Category", Description = "Delete specified category by id")]
        public ApiResponse<bool> Delete(int categoryId)
        {
            return _category.Delete(categoryId);
        }
        #endregion

        #region(get CategoryName By Name)
        /// <summary>  
        ///  Get Category by name  
        /// </summary>  
        /// <param Display category exist if it is category existing otherwise Category doesnt exists </param> 
        [HttpGet]
        [AllowAnonymous]
        [Route("CategoryName/{categoryName}")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Gets Category By Name", Description = "Checks if category exists")]
        public ApiResponse<bool> GetCategoryByName(string categoryName)
        {
            return _category.GetByCategoryName(categoryName);
        }
        #endregion

        #region(Post)
        /// <summary>  
        ///  API for Adding Category   
        /// </summary>  
        /// <param API to add category name in database</param> 
        [HttpPost("Add")]
        [Route("Add")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Posts new category", Description = "Adds a new Category")]
        public async Task<ApiResponse<bool>> AddCategory(CategoryDTO categoryDTO)
        {
            return await _category.Post(categoryDTO);
        }
        #endregion

        #region(Put)
        /// <summary>  
        /// API for Editing Category   
        /// </summary>  
        /// <param API to edit category name in database</param> 
        [HttpPut("{id}")]
        [Route("Edit/{CategoryId}")]
        [AllowAnonymous]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Edit new category", Description = "Edit a new Category")]
        public Task<ApiResponse<bool>> EditCategory(int id, CategoryDTO categoryDTO)
        {
            return _category.Update(id, categoryDTO);
        }
        #endregion

    }
}
