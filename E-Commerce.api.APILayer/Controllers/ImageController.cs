//using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;
//using E_Commerce.core.ApplicationLayer.DTOModel.Image;
//using E_Commerce.core.ApplicationLayer.Interface;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Swashbuckle.AspNetCore.Annotations;

//namespace E_Commerce.api.APILayer.Controllers
//{
//    [Route("api/[controller]")]
//    [Authorize]
//    [ApiController]
//    public class ImageController : ControllerBase
//    {
//        private readonly IImage _image;
//        public ImageController(IImage image)
//        {
//            _image = image;

//        }
//        #region(Get)
//        /// <summary>  
//        /// API to Get all data  
//        /// </summary>  
//        /// <returns>API for calling function to list Image with their id</returns>  
//        [HttpGet]
//        [Route("get")]
//        [AllowAnonymous]
//        [SwaggerResponse(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(typeof(ApiResponse<List<ImageDTO>>), StatusCodes.Status200OK)]
//        [SwaggerOperation(Summary = "Get all List", Description = "Get Image List")]
//        public ApiResponse<List<ImageDTO>> Get()
//        {
//            return _image.Get(Request.Scheme, Request.Host, Request.PathBase);
//        }

//        #endregion

//        #region(Post)
//        /// <summary>  
//        ///  API for Adding Image   
//        /// </summary>  
//        /// <param API to add image name in database</param> 
//        [HttpPost]
//        [AllowAnonymous]
//        [Route("post")]
//        [SwaggerResponse(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
//        [SwaggerOperation(Summary = "Create image", Description = "Add image name and image  path")]

//        public async Task<ApiResponse<bool>> Post([FromForm] string productName, string imageName, int priority, IFormFile image)
//        {
//            var images = new ImageDTO();
//            images.ProductName = productName;
//            images.ImageName = imageName;
//            images.Priority = priority;
//            images.Image = image;
//            return await _image.Post(images);
//        }

//        //USING OBJECT
//        //public async Task<ApiResponse<bool>> Post(BrandDTO brandDTO)
//        //{
//        //    BrandDTO brand = new BrandDTO();
//        //    brand.BrandName = brandDTO.BrandName;
//        //    brand.Logo = brandDTO.Logo;
//        //    return await _brand.Post(brandDTO);
//        //}
//        #endregion

//        #region(Image by name)
//        /// <summary>  
//        /// API to get image by name  
//        /// </summary>  
//        /// <param API to display existing image name</param>
//        [HttpGet]
//        [AllowAnonymous]
//        [SwaggerResponse(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
//        [SwaggerOperation(Summary = "Get image by name", Description = "success true if image not exist")]
//        public ApiResponse<bool> GetByImageName(string imageName)
//        {
//            return _image.GetByImageName(imageName);
//        }

//        #endregion

//        #region(put)
//        /// <summary>  
//        ///  API for Update image  
//        /// </summary>  
//        /// <param API to Edit image name and image path in database</param>
//        [HttpPut]
//        [Route("Edit")]
//        [AllowAnonymous]
//        [SwaggerResponse(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
//        [SwaggerOperation(Summary = "Update image by Id", Description = "success true if image not exist")]
//        public Task<ApiResponse<bool>> Update(int id, [FromForm] string imageName, int priority, string productName,  IFormFile image)
//        {
//            var updateDetails = new ImageDTO();
//            updateDetails.ImageName = imageName;
//            updateDetails.Image = image;
//            updateDetails.ImageId = id;
//            updateDetails.Priority = priority;
//            updateDetails.ProductName = productName;
//            return _image.Update(updateDetails);
//        }
//        #endregion

//        #region( Delete Image )
//        /// <summary>  
//        ///  API for Delete image   
//        /// </summary>  
//        /// <param API for setting status field in database as one when image deleted</param> 
//        [HttpDelete]
//        [AllowAnonymous]
//        [Route("delete/{imageId}")]
//        [SwaggerResponse(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
//        [SwaggerOperation(Summary = "Delete Image", Description = "Delete specified image by id")]
//        public ApiResponse<bool> Delete(int imageId)
//        {
//            return _image.Delete(imageId);
//        }
//        #endregion
//    }
//}

