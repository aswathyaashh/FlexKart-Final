using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using E_Commerce.core.DomainLayer.Entities;
using E_Commerce.core.ApplicationLayer.Interface;
using E_Commerce.core.ApplicationLayer.DTOModel.Brand;
using E_Commerce.core.ApplicationLayer.BuyerModuleDTO;
using E_Commerce.core.ApplicationLayer.Interface.Salesforce;
using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;

namespace E_Commerce.infrastructure.RepositoryLayer.services
{
    public class Brand : IBrand
    {
        #region(Private Variables)
        private readonly AdminDbContext _adminDbContext;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IBuyerService _buyerService;

        #endregion

        #region(Constructor)
        public Brand(AdminDbContext adminDbContext, IMapper mapper, IWebHostEnvironment hostEnvironment, IBuyerService buyerService)
        {
            _adminDbContext = adminDbContext;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
            _buyerService = buyerService;
        }
        #endregion

        #region(Get Brand)
        /// <summary>  
        /// Gets all Brand data  
        /// </summary>  
        /// <returns>collection of brands.</returns>  
        public ApiResponse<List<BrandDTO>> Get(String Scheme, HostString Host, PathString PathBase)
        {
            ApiResponse<List<BrandDTO>> response = new ApiResponse<List<BrandDTO>>();
            var value = _mapper.Map<List<BrandModel>, List<BrandDTO>>(_adminDbContext.Brand.Where(e => e.Status == 0)
                .Select(x => new BrandModel()
                {
                    BrandId = x.BrandId,
                    BrandName = x.BrandName,
                    LogoPath = x.LogoPath,
                    ImageSrc = String.Format("{0}://{1}{2}/Images/{3}", Scheme, Host, PathBase, x.LogoPath)
                })
                .ToList());

            if (value != null && value.Count > 0)
            {
                response.Message = "Brands Listed";
                response.Success = true;
                response.Data = value;
                return response;
            }
            else
            {
                response.Message = "No Brand Found";
                response.Success = false;
                return response;
            }

        }
        #endregion

        #region(Add Brand)
        /// <summary>  
        ///  Create brand  
        /// </summary>  
        /// <param Create brand name and logo path</param>
        public async Task<ApiResponse<bool>> Post(BrandDTO brandName)
        {
            var brand = _mapper.Map<BrandDTO, BrandModel>(brandName);
            ApiResponse<bool> addResponse = new ApiResponse<bool>();

            if (brand != null)
            {
                brand.LogoPath = await SaveLogo(brand.Logo);
                brand.CreatedDate = DateTime.Now;
                _adminDbContext.Brand.Add(brand);
                _adminDbContext.SaveChanges();
                BrandDTOReq brandDTOReq = new BrandDTOReq();
                brandDTOReq.Name = brand.BrandName;
                brandDTOReq.BrandDotNetId__c = brand.BrandId.ToString();
                var response = await _buyerService.AddBrand(brandDTOReq);
                brand.SalesForceId = response.id;
                _adminDbContext.Brand.Update(brand);
                _adminDbContext.SaveChanges();
                addResponse.Success = true;
                addResponse.Message = "New Brand created";
                addResponse.Data = true;
                return addResponse;
            }
            else
            {
                addResponse.Success = false;
                addResponse.Message = "Not created";
                addResponse.Data = false;
                return addResponse;
            }
        }
        #endregion

        #region(Function for Uploading logo)
        /// <summary>  
        /// Function for upload brand logo  
        /// </summary>  
        /// <param Upload a brand logo with current datetime in logopath</param>
        public async Task<string> SaveLogo(IFormFile logo)
        {
            string logoPath = new String(Path.GetFileNameWithoutExtension(logo.FileName).Take(10).ToArray()).Replace(' ', '-');
            logoPath = logoPath + DateTime.Now.ToString("yyyyMMddhhmmfff") + Path.GetExtension(logo.FileName);
            var path = Path.Combine(_hostEnvironment.ContentRootPath, "Images", logoPath);
            using (var filestream = new FileStream(path, FileMode.Create))
            {
                await logo.CopyToAsync(filestream);
            }
            return logoPath;
        }
        #endregion

        #region(Get Brand by Name)
        /// <summary>  
        /// Get brand by name  
        /// </summary>  
        /// <param Display brand exist if it is in database otherwise doesnt exist</param>
        public ApiResponse<bool> GetByBrandName(string name)
        {
            var brandName = _adminDbContext.Brand.FirstOrDefault(e => e.BrandName == name && e.Status == 0);
            ApiResponse<bool> response = new ApiResponse<bool>();
            if (brandName != null)
            {
                if (brandName.Status == 0)
                {
                    response.Success = true;
                    response.Message = "Brand exists";
                    response.Data = true;
                    return response;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Brand doesnt exists";
                    response.Data = false;
                    return response;
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Brand doesnt exists";
                response.Data = false;
                return response;

            }
        }
        #endregion

        #region(Update Brand)
        /// <summary>  
        ///  Update brand  
        /// </summary>  
        /// <param Edit brand name and logo path</param>
        public async Task<ApiResponse<bool>> Update(BrandDTO brandId)
        {
            var updateData = _adminDbContext.Brand.FirstOrDefault(i => i.BrandId == brandId.BrandId);
            ApiResponse<bool> updateResponse = new ApiResponse<bool>();
            if (updateData != null)
            {
                if (updateData.Status == 0)
                {
                    if (brandId.BrandName == null)
                    {
                        updateData.BrandName = updateData.BrandName;
                    }
                    else
                    {
                        updateData.BrandName = brandId.BrandName;

                    }
                    if (brandId.Logo == null)
                    {
                        updateData.LogoPath = updateData.LogoPath;
                    }
                    else
                    {
                        updateData.LogoPath = await SaveLogo(brandId.Logo);
                    }
                    updateResponse.Success = true;
                    updateResponse.Message = " Brand updated";
                    updateResponse.Data = true;
                    updateData.UpdatedDate = DateTime.Now;
                    _adminDbContext.Brand.Update(updateData);
                    _adminDbContext.SaveChanges();
                    BrandDTOReq brandDTOReq = new BrandDTOReq();
                    brandDTOReq.Name = updateData.BrandName;
                    brandDTOReq.BrandDotNetId__c = updateData.BrandId.ToString();
                    var response = await _buyerService.EditBrand(brandDTOReq, updateData.SalesForceId);
                    _adminDbContext.Brand.Update(updateData);
                    _adminDbContext.SaveChanges();
                    return updateResponse;
                }
                else
                {
                    updateResponse.Success = false;
                    updateResponse.Message = " Brand not updated";
                    updateResponse.Data = false;
                    return updateResponse;
                }
            }
            else
            {
                updateResponse.Success = false;
                updateResponse.Message = "Null";
                return updateResponse;
            }
        }
        #endregion

        #region(Delete Brand)
        /// <summary>  
        ///  Delete Brand by id 
        /// </summary>  
        /// <param set status field in database as one when brand deleted</param> 
        public ApiResponse<bool> Delete(int brandId)
        {
            BrandModel brand = _adminDbContext.Brand.FirstOrDefault(i => i.BrandId == brandId);
            ApiResponse<bool> response = new ApiResponse<bool>();

            if (brand != null)
            {
                if (brand.Status == 0)
                {
                    brand.Status = 1;
                    brand.UpdatedDate = DateTime.Now;
                    _adminDbContext.Brand.Update(brand);
                    _adminDbContext.SaveChanges();
                    BrandDTOReq brandDTOReq = new BrandDTOReq();
                    brandDTOReq.Name = brand.BrandName;
                    brandDTOReq.BrandDotNetId__c = brand.BrandId.ToString();
                    _buyerService.DeleteBrand(brand.SalesForceId);
                    _adminDbContext.Brand.Update(brand);
                    _adminDbContext.SaveChanges();
                    response.Success = true;
                    response.Message = "Brand Deleted";
                    response.Data = true;
                    return response;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Already Deleted brand";
                    response.Data = false;
                    return response;
                }
            }
            response.Success = false;
            response.Message = "ID doesn't exist.";
            return response;
        }
        #endregion

    }
}

