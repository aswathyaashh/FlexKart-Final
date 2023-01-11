using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.core.DomainLayer.Entities;
using E_Commerce.core.ApplicationLayer.DTOModel;
using E_Commerce.core.ApplicationLayer.Interface;
using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;
using E_Commerce.core.ApplicationLayer.BuyerModuleDTO;
using E_Commerce.core.ApplicationLayer.Interface.Salesforce;

namespace E_Commerce.infrastructure.RepositoryLayer.services
{
    public class Category : ICategory
    {
        #region(Private Variables)

        private readonly AdminDbContext _adminDbContext;
        private readonly IMapper _mapper;
        private readonly IBuyerService _buyerService;

        #endregion

        #region(Constructor)
        public Category(AdminDbContext adminDbContext, IMapper mapper, IBuyerService buyerService)
        {
            _adminDbContext = adminDbContext;
            _mapper = mapper;
            _buyerService = buyerService;
        }
        #endregion

        #region(Get Category)
        /// <summary>  
        /// Gets all data  
        /// </summary>  
        /// <returns>collection of categories.</returns>  
        public ApiResponse<List<CategoryDTO>> Get()
        {
            ApiResponse<List<CategoryDTO>> response = new ApiResponse<List<CategoryDTO>>();
            var data = _mapper.Map<List<CategoryModel>, List<CategoryDTO>>(_adminDbContext.Category.Where(e => e.Status == 0).ToList());

            if (data != null && data.Count > 0)
            {
                response.Message = "Category Listed";
                response.Success = true;
                response.Data = data;
                return response;
            }
            else
            {
                response.Message = "No Category Found";
                response.Success = false;
                return response;
            }

        }
        #endregion

        #region(get CategoryName By Name)
        /// <summary>  
        ///  Get Category by name  
        /// </summary>  
        /// <param Display category exist if it is category existing otherwise Category doesnt exists </param> 
        public ApiResponse<bool> GetByCategoryName(string name)
        {
            var entity = _adminDbContext.Category.FirstOrDefault(e => e.CategoryName == name);
            ApiResponse<bool> response = new ApiResponse<bool>();

            if (entity != null)
            {
                if (entity.Status == 0)
                {
                    response.Success = true;
                    response.Message = "Category exists";
                    response.Data = true;
                    return response;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Category doesnt exists";
                    response.Data = false;
                    return response;
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Category doesnt exists";
                return response;
            }


        }
        #endregion

        #region(post)
        /// <summary>  
        ///  Add Category by id  
        /// </summary>  
        /// <param add category name in database</param> 
        public async Task<ApiResponse<bool>> Post([FromBody] CategoryDTO categoryDTO)
        {
            var categoryModel = new CategoryModel()
            {
                CategoryName = categoryDTO.CategoryName
            };

           // categoryModel.UpdatedDate = null;
            _adminDbContext.Category.Add(categoryModel);
            _adminDbContext.SaveChanges();

            CategoryDTOReq categoryDTOReq = new CategoryDTOReq();
            categoryDTOReq.Name = categoryModel.CategoryName;
            categoryDTOReq.CategoryDotNetId__c = categoryModel.CategoryId.ToString();
            var response = await _buyerService.AddCategory(categoryDTOReq);
            categoryModel.SalesForceId = response.id;
            _adminDbContext.Category.Update(categoryModel);
            _adminDbContext.SaveChanges();

            var add = _adminDbContext.Category.FirstOrDefault(e => e.CategoryName == categoryModel.CategoryName);
            ApiResponse<bool> addResponse = new ApiResponse<bool>();

            if (add == null)
            {
                addResponse.Success = false;
                addResponse.Message = "Category is not added";
                addResponse.Data = false;
                return addResponse;
            }
            else
            {
                addResponse.Success = true;
                addResponse.Message = "Category is added";
                addResponse.Data = true;
                return addResponse;

            }

        }
        #endregion

        #region(Delete Category)
        /// <summary>  
        ///  Delete Category by id 
        /// </summary>  
        /// <param set status field in database as one when category deleted</param> 
        public ApiResponse<bool> Delete(int categoryId)
        {
            CategoryModel category = _adminDbContext.Category.FirstOrDefault(i => i.CategoryId == categoryId);
            ApiResponse<bool> response = new ApiResponse<bool>();

            if (category != null)
            {
                if (category.Status == 0)
                {

                    category.Status = 1;
                    category.UpdatedDate = DateTime.Now;
                    _adminDbContext.Category.Update(category);
                    _adminDbContext.SaveChanges();

                    CategoryDTOReq categoryDTOReq = new CategoryDTOReq();
                    categoryDTOReq.Name = category.CategoryName;
                    categoryDTOReq.CategoryDotNetId__c = category.CategoryId.ToString();
                    _buyerService.DeleteCategory(category.SalesForceId);
                    _adminDbContext.Category.Update(category);
                    _adminDbContext.SaveChanges();

                    response.Success = true;
                    response.Message = "Category Deleted";
                    response.Data = true;
                    return response;


                }
                else
                {
                    response.Success = false;
                    response.Message = "Already Deleted category";
                    response.Data = false;
                    return response;
                }
            }

            response.Success = false;
            response.Message = "ID doesn't exist.";
            return response;
        }

        #endregion

        #region(Put)
        /// <summary>  
        ///  Edit Category by id  
        /// </summary>  
        /// <param edit category name in database</param> 
        public async Task<ApiResponse<bool>> Update(int id, [FromBody] CategoryDTO categoryDTO)
        {
            var update = _adminDbContext.Category.FirstOrDefault(e => e.CategoryId == id);
            ApiResponse<bool> updateResponse = new ApiResponse<bool>();

            if (update == null)
            {
                updateResponse.Success = false;
                updateResponse.Message = "Category doesnt exist";
                updateResponse.Data = false;
                return updateResponse;
            }
            else
            {
                updateResponse.Success = true;
                updateResponse.Message = "Category is updated";
                updateResponse.Data = true;
                update.CategoryName = categoryDTO.CategoryName;
               // update.UpdatedDate = DateTime.Now;
                _adminDbContext.Update(update);
                _adminDbContext.SaveChanges();

                CategoryDTOReq categoryDTOReq = new CategoryDTOReq();
                categoryDTOReq.Name = update.CategoryName;
                categoryDTOReq.CategoryDotNetId__c = update.CategoryId.ToString();
                var response = await _buyerService.EditCategory(categoryDTOReq, update.SalesForceId);
                _adminDbContext.Category.Update(update);
                _adminDbContext.SaveChanges();
                return updateResponse;
            }

        }
        #endregion
    }
}
