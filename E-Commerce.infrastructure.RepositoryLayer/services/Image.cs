//using AutoMapper;
//using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;
//using E_Commerce.core.ApplicationLayer.DTOModel.Image;
//using E_Commerce.core.ApplicationLayer.DTOModel.Product;
//using E_Commerce.core.ApplicationLayer.DTOModel.SubCategory;
//using E_Commerce.core.ApplicationLayer.Interface;
//using E_Commerce.core.DomainLayer.Entities;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Drawing.Drawing2D;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

//namespace E_Commerce.infrastructure.RepositoryLayer.services
//{
//    public class Image : IImage
//    {
//        #region(Private Variables)
//        private readonly AdminDbContext _adminDbContext;
//        private readonly IMapper _mapper;
//        private readonly IWebHostEnvironment _hostEnvironment;
//        #endregion

//        #region(Constructor)
//        public Image(AdminDbContext adminDbContext, IMapper mapper, IWebHostEnvironment hostEnvironment)
//        {
//            _adminDbContext = adminDbContext;
//            _mapper = mapper;
//            _hostEnvironment = hostEnvironment;
//        }
//        #endregion

//        #region(Get Image)
//        /// <summary>  
//        /// Gets all data  
//        /// </summary>  
//        /// <returns>collection of Images.</returns>  
//        public ApiResponse<List<ImageDTO>> Get(String Scheme, HostString Host, PathString PathBase)
//        {
//            ApiResponse<List<ImageDTO>> response = new ApiResponse<List<ImageDTO>>();
//            var list = new List<ImageDTO>();
//            var value = _adminDbContext.Image.Where(e => e.Status == 0).Include(x => x.ProductModel).ToList();

//            if (value != null && value.Count > 0)
//            {
//                foreach (var content in value)
//                {

//                    ImageDTO imageDTO = new ImageDTO();
//                    imageDTO.ImageId = content.ImageId;
//                    imageDTO.ImageName = content.ImageName;
//                    imageDTO.ImagePath = content.ImagePath;
//                    imageDTO.ImageSrc = String.Format("{0}://{1}{2}/Images/{3}", Scheme, Host, PathBase, content.ImagePath);
//                    imageDTO.Priority = content.Priority;

//                    //add ternary operator here
//                    imageDTO.ProductName = content.ProductModel.ProductName;

//                    list.Add(imageDTO);
//                }
//                response.Message = "Image Listed";
//                response.Success = true;
//                response.Data = list;
//                return response;
//            }
//            else
//            {
//                response.Message = "No Image Found";
//                response.Success = false;
//                return response;
//            }

//        }
//        #endregion

//        #region(Post)
//        /// <summary>  
//        ///  Create Image  
//        /// </summary>  
//        /// <param Create Image name and Image path</param>
//        //public async Task<ApiResponse<bool>> Post(ImageDTO imageName)
//        //{
//        //    var productId = _adminDbContext.Product.Where(x => x.ProductName == imageName.ProductName && x.Status == 0).Select(x => x.ProductId).FirstOrDefault();


//        //    ApiResponse<bool> addResponse = new ApiResponse<bool>();
//        //    var response =GetByPriority(imageName.Priority, productId);

//        //    if (productId > 0 && response.Success==false)
//        //    {

//        //        var imageModel = new ImageModel()
//        //       {
//        //            ImageName = imageName.ImageName,
//        //            ImagePath = await SaveLogo(imageName.Image),
//        //            Priority = imageName.Priority,
//        //            ProductId = productId,
//        //            CreatedDate = DateTime.UtcNow
//        //    };
//        //        _adminDbContext.Image.Add(imageModel);
//        //        _adminDbContext.SaveChanges();
//        //        addResponse.Success = true;
//        //        addResponse.Message = "New Image created";
//        //        addResponse.Data = true;
//        //        return addResponse;
//        //    }
//        //    else
//        //    {
//        //        addResponse.Success = false;
//        //        addResponse.Message = "Product not found or Priority already exists";
//        //        addResponse.Data = false;
//        //        return addResponse;
//        //    }

//        //}
//        #endregion

//        #region(Get Image by Priority)
//        /// <summary>  
//        /// Get image by priority  
//        /// </summary>  
//        /// <param Display  priority exist if it is in database otherwise doesnt exist</param>
//        public ApiResponse<bool> GetByPriority(int priority , int productId)
//        {
            
//            var priorityimage = _adminDbContext.Image.FirstOrDefault(e => e.Priority == priority && e.ProductId == productId);
//            ApiResponse<bool> response = new ApiResponse<bool>();
//            if (priorityimage != null)
//            {
//                if (priorityimage.Status == 0)
//                {
//                    response.Success = true;
//                    response.Message = "priority exists";
//                    response.Data = true;
//                    return response;
//                }
//                else
//                {
//                    response.Success = false;
//                    response.Message = "priority doesnt exists";
//                    response.Data = false;
//                    return response;
//                }
//            }
//            else
//            {
//                response.Success = false;
//                response.Message = "priority doesnt exists";
//                response.Data = false;
//                return response;

//            }

//        }
//        #endregion

//        #region(Function for Uploading image)
//        /// <summary>  
//        /// Function for upload image path  
//        /// </summary>  
//        /// <param Upload a  image path  with current datetime in imagepath</param>
//        public async Task<string> SaveLogo(IFormFile image)
//        {

//            string imagePath = new String(Path.GetFileNameWithoutExtension(image.FileName).Take(10).ToArray()).Replace(' ', '-');
//            imagePath = imagePath + DateTime.Now.ToString("yyyyMMddhhmmfff") + Path.GetExtension(image.FileName);
//            var path = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imagePath);

//            using (var filestream = new FileStream(path, FileMode.Create))
//            {
//                await image.CopyToAsync(filestream);
//            }
//            return imagePath;
//        }
//        #endregion

//        #region(Get Image by Name)
//        /// <summary>  
//        /// Get image by name  
//        /// </summary>  
//        /// <param Display image exist if it is in database otherwise doesnt exist</param>
//        public ApiResponse<bool> GetByImageName(string image)
//        {
//            var imageName = _adminDbContext.Image.FirstOrDefault(e => e.ImageName == image);
//            ApiResponse<bool> response = new ApiResponse<bool>();
//            if (imageName != null)
//            {
//                if (imageName.Status == 0)
//                {
//                    response.Success = true;
//                    response.Message = "Image exists";
//                    response.Data = true;
//                    return response;
//                }
//                else
//                {
//                    response.Success = false;
//                    response.Message = "Image doesnt exists";
//                    response.Data = false;
//                    return response;
//                }
//            }
//            else
//            {
//                response.Success = false;
//                response.Message = "Image doesnt exists";
//                response.Data = false;
//                return response;

//            }

//        }
//        #endregion

//        #region(Update)
//        /// <summary>  
//        ///  Update image  
//        /// </summary>  
//        /// <param Edit image name and image path</param>
//        public async Task<ApiResponse<bool>> Update(ImageDTO ImageId)
//        {
//            var updateData = _adminDbContext.Image.FirstOrDefault(i => i.ImageId == ImageId.ImageId);
//            ApiResponse<bool> updateResponse = new ApiResponse<bool>();
//            if (updateData == null)
//            {
//                updateResponse.Success = false;
//                updateResponse.Message = "image doesnt exist";
//                updateResponse.Data = false;
//                return updateResponse;
//            }
//            else 
//            { 
//                var productId = _adminDbContext.Product.Where(x => x.ProductName == ImageId.ProductName && x.Status == 0).Select(x => x.ProductId).FirstOrDefault();
//                var response = GetByPriority(ImageId.Priority, productId);
                
//                if (productId > 0 && response.Success == false)
                
//                {
//                    updateResponse.Success = true;
//                    updateResponse.Message = "Updated Image";
//                    updateResponse.Data = true;
//                    updateData.ImageName = ImageId.ImageName;
//                    updateData.ProductId = productId;
//                    updateData.Priority = ImageId.Priority;
//                    updateData.ImagePath = await SaveLogo(ImageId.Image);
//                    updateData.UpdatedDate = DateTime.Now;
//                    _adminDbContext.Update(updateData);
//                    _adminDbContext.SaveChanges();
//                    return updateResponse;

//                }
//                else if(productId > 0 && response.Success == true)
//                {
//                    var imgobj = _adminDbContext.Image.FirstOrDefault(x => x.ImageId == ImageId.ImageId);
//                    var updateid = imgobj.Priority;
//                    var newobj = _adminDbContext.Image.FirstOrDefault(x => x.ProductId == productId && x.Priority == ImageId.Priority);
//                    newobj.Priority = updateid;
//                    imgobj.Priority = ImageId.Priority;
//                    updateResponse.Success = true;
//                    updateResponse.Message = "Updated Image";
//                    updateResponse.Data = true;
//                    imgobj.ImageName = ImageId.ImageName;
//                    imgobj.ProductId = productId;
//                    imgobj.Priority = ImageId.Priority;
//                    imgobj.ImagePath = await SaveLogo(ImageId.Image);
//                    imgobj.UpdatedDate = DateTime.Now;
//                    _adminDbContext.Update(imgobj);
//                    _adminDbContext.Update(newobj);
//                    _adminDbContext.SaveChanges();
//                    return updateResponse;

//                }
//                else
//                {

//                    updateResponse.Success = false;
//                    updateResponse.Message = "Product doesnt exist or Priority already exists";
//                    updateResponse.Data = false;
//                    return updateResponse;
//                }              
//            }
           
//        }
//        #endregion

//        #region(Delete Image)
//        /// <summary>  
//        ///  Delete Image by id 
//        /// </summary>  
//        /// <param set status field in database as one when Image deleted</param> 
//        public ApiResponse<bool> Delete(int imageId)
//        {
//            ImageModel image = _adminDbContext.Image.FirstOrDefault(i => i.ImageId == imageId);
//            ApiResponse<bool> response = new ApiResponse<bool>();

//            if (image != null)
//            {
//                if (image.Status == 0)
//                {
//                    image.Status = 1;
//                    image.UpdatedDate = DateTime.Now;
//                    _adminDbContext.Image.Update(image);
//                    _adminDbContext.SaveChanges();
//                    response.Success = true;
//                    response.Message = "Image Deleted";
//                    response.Data = true;
//                    return response;
//                }
//                else
//                {
//                    response.Success = false;
//                    response.Message = "Already Deleted Image";
//                    response.Data = false;
//                    return response;
//                }
//            }

//            response.Success = false;
//            response.Message = "ID doesn't exist.";
//            return response;
//        }

//        #endregion
//    }
//}


