using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;
using E_Commerce.core.ApplicationLayer.DTOModel.SubCategory;
using E_Commerce.core.ApplicationLayer.Interface;
using E_Commerce.core.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace E_Commerce.infrastructure.RepositoryLayer.services
{
    public class SubCategory : ISubCategory
    {
        #region(Private Variables)
        private readonly AdminDbContext _adminDbContext;
        private readonly IMapper _mapper;
        #endregion

        #region(Constructor)
        public SubCategory(AdminDbContext adminDbContext, IMapper mapper)
        {
            _adminDbContext = adminDbContext;
            _mapper = mapper;
        }
        #endregion

        #region(Delete SubCategory)
        /// <summary>  
        ///  Delete SubCategory by id 
        /// </summary>  
        /// <param set status field in database as one when subcategory deleted</param> 
        public ApiResponse<bool> Delete(int subCategoryId)
        {
            SubCategoryModel subCategory = _adminDbContext.SubCategory.FirstOrDefault(i => i.SubCategoryId == subCategoryId);
            ApiResponse<bool> response = new ApiResponse<bool>();

            if (subCategory != null)
            {
                if (subCategory.Status == 0)
                {
                    subCategory.Status = 1;
                    _adminDbContext.SubCategory.Update(subCategory);
                    _adminDbContext.SaveChanges();
                    response.Success = true;
                    response.Message = "Deleted";
                    return response;
                };
            }
            else
            {

                response.Success = false;
                response.Message = "Already Deleted";


            }
            response.Success = false;
            response.Message = "ID doesn't exist.";
            return response;
        }
        #endregion

        #region(Get SubCategory)
        /// <summary>  
        /// Gets all data  
        /// </summary>  
        /// <returns>collection of subcategories.</returns> 
        public ApiResponse<List<SubCategoryDTO>> Get()
        {
            ApiResponse<List<SubCategoryDTO>> response = new ApiResponse<List<SubCategoryDTO>>();
            var list = new List<SubCategoryDTO>();
            var data = _adminDbContext.SubCategory.Where(e => e.Status == 0).Include(x => x.CategoryModel).ToList();
            if (data != null && data.Count > 0)
            {
                foreach (var content in data)
                {

                    SubCategoryDTO subCategoryDTO = new SubCategoryDTO();
                    subCategoryDTO.SubCategoryId = content.SubCategoryId;
                    subCategoryDTO.SubCategoryName = content.SubCategoryName;
                    //add ternary operator here
                    subCategoryDTO.CategoryName = content.CategoryModel.CategoryName;

                    list.Add(subCategoryDTO);
                }
                response.Message = "Listed";
                response.Success = true;
                response.Data = list;
                return response;
            }
            else
            {
                response.Message = "Null";
                response.Success = false;
                return response;
            }
        }
        #endregion

        #region(get SubCategoryName By Name)
        /// <summary>  
        ///  Get SubCategory by name  
        /// </summary>  
        /// <param Display subcategory exist if it is subcategory existing otherwise SubCategory doesnt exists </param> 
        public ApiResponse<bool> GetBySubCategoryName(string Name)
        {
            var entity = _adminDbContext.SubCategory.FirstOrDefault(e => e.SubCategoryName == Name);
            ApiResponse<bool> response = new ApiResponse<bool>();

            if (entity != null)
            {
                if (entity.Status == 0)
                {
                    response.Success = true;
                    response.Message = "SubCategory exists";
                    response.Data = true;
                    return response;
                }
                else
                {
                    response.Success = false;
                    response.Message = "SubCategory doesnt exists";
                    response.Data = false;
                    return response;
                }
            }
            else
            {
                response.Success = false;
                response.Message = "SubCategory doesnt exists";
                return response;
            }

        }
        #endregion

        #region(post)
        /// <summary>  
        ///  Add SubCategory by id  
        /// </summary>  
        /// <param add subcategory name in database</param> 
        public ApiResponse<bool> Post(SubCategoryDTO subCategory)
        {
            var categoryId = _adminDbContext.Category.Where(x => x.CategoryName == subCategory.CategoryName && x.Status == 0).Select(x => x.CategoryId).FirstOrDefault();
            ApiResponse<bool> Response = new ApiResponse<bool>();

            if (categoryId > 0)
            {
                var subCategoryModel = new SubCategoryModel()
                {
                    SubCategoryName = subCategory.SubCategoryName,
                    CategoryId = categoryId
                };
                _adminDbContext.Add(subCategoryModel);
                _adminDbContext.SaveChangesAsync();

                Response.Success = true;
                Response.Message = "SubCategory is added";
                Response.Data = true;
                return Response;
            }
            else
            {
                Response.Success = false;
                Response.Message = "Category not found";
                Response.Data = false;
                return Response;
            }
        }
        #endregion

        #region(Put)
        /// <summary>  
        ///  Edit SubCategory by id  
        /// </summary>  
        /// <param edit subcategory name in database</param> 
        public ApiResponse<bool> Update(int id, SubCategoryDTO subCategory)

        {
            var update = _adminDbContext.SubCategory.FirstOrDefault(e => e.SubCategoryId == id);
            ApiResponse<bool> updateResponse = new ApiResponse<bool>();

            if (update == null)
            {
                updateResponse.Success = false;
                updateResponse.Message = "subCategory doesnt exist";
                updateResponse.Data = false;
                return updateResponse;
            }
            else
            {
                var categoryId = _adminDbContext.Category.Where(x => x.CategoryName == subCategory.CategoryName && x.Status == 0).Select(x => x.CategoryId).FirstOrDefault();


                if (categoryId == 0)
                {
                    updateResponse.Success = false;
                    updateResponse.Message = "Category doesnt exist";
                    updateResponse.Data = false;
                    return updateResponse;
                }
                else
                {
                    updateResponse.Success = true;
                    updateResponse.Message = "Updated";
                    updateResponse.Data = true;
                    update.SubCategoryName = subCategory.SubCategoryName;
                    update.CategoryId = categoryId;
                   // update.UpdatedDate = DateTime.Now;
                    _adminDbContext.Update(update);
                    _adminDbContext.SaveChanges();
                    return updateResponse;
                }
            }

        }
        #endregion

    }
}
