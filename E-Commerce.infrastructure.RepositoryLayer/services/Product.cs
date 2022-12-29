﻿using AutoMapper;
using Azure;
using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;
using E_Commerce.core.ApplicationLayer.DTOModel.Image;
using E_Commerce.core.ApplicationLayer.DTOModel.Product;
using E_Commerce.core.ApplicationLayer.DTOModel.SubCategory;
using E_Commerce.core.ApplicationLayer.Interface;
using E_Commerce.core.DomainLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.infrastructure.RepositoryLayer.services
{
    public class Product : IProduct
    {
        #region(Private Variables)
        private readonly AdminDbContext _adminDbContext;
        private readonly IMapper _mapper;
        private readonly IHostEnvironment _hostEnvironment;
        #endregion

        #region(Constructor)
        public Product(AdminDbContext adminDbContext, IMapper mapper, IHostEnvironment hostEnvironment)
        {
            _adminDbContext = adminDbContext;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }
        #endregion

        #region(Delete Product)
        /// <summary>  
        ///  Delete Product by id 
        /// </summary>  
        /// <param set status field in database as one when product deleted</param> 
        public ApiResponse<bool> Delete(int productId)
        {
            ProductModel product = _adminDbContext.Product.FirstOrDefault(i => i.ProductId == productId);
            ApiResponse<bool> response = new ApiResponse<bool>();

            if (product != null)
            {
                if (product.Status == 0)
                {
                    product.Status = 1;
                    _adminDbContext.Product.Update(product);
                    _adminDbContext.SaveChanges();
                    response.Success = true;
                    response.Message = "Product Deleted";
                    return response;
                }
                else
                {

                    response.Success = false;
                    response.Message = "Already Deleted";
                    return response;


                }
            }
            else
            {
                response.Success = false;
                response.Message = "ID doesn't exist.";
                return response;
            }
        }
        #endregion

        #region(Get ProductById)
        /// <summary>  
        /// Gets ProductBy Id  
        /// </summary>  
        /// <returns>Get Product details by Id.</returns> 
        public ApiResponse<List<ProductDTO>> GetProductById(int id, String Scheme, HostString Host, PathString PathBase)
        {
            ApiResponse<List<ProductDTO>> response = new ApiResponse<List<ProductDTO>>();
           // var entity = _adminDbContext.Product.FirstOrDefault(e => e.ProductId == id);
            var list = new List<ProductDTO>();
            //var subdata = new SubCategoryModel();
            var data = _adminDbContext.Product.Where(e => e.Status == 0 && e.ProductId == id).Include(x => x.SubCategoryModel).Include(y => y.BrandModel).Include(b => b.SubCategoryModel.CategoryModel).ToList();
            if (data != null && data.Count > 0)
            {
                foreach (var content in data)
                {
                    ProductDTO productDTO = new ProductDTO();
                    productDTO = _mapper.Map<ProductModel, ProductDTO>(content);
                    //productDTO.ProductId = content.ProductId;
                    //productDTO.ProductName = content.ProductName;
                    //productDTO.Price = content.Price;
                    //productDTO.Description = content.Description;
                    //productDTO.Quantity = content.Quantity;
                    productDTO.SubCategoryId = content.SubCategoryModel.SubCategoryId;
                    productDTO.CategoryName = content.SubCategoryModel.CategoryModel.CategoryName;
                    productDTO.BrandId = content.BrandModel.BrandId;

                    
                    productDTO.Image = _mapper.Map<List<ImageModel>, List<ImageDTO>>(_adminDbContext.Image.Where(i => i.ProductId == content.ProductId && i.Status == 0).Include(y=>y.ImageSrc).ToList());
                    //ImageDTO imageDTO = new ImageDTO();
                    //imageDTO.ImagePath = content.ImagePath;

                    //imageDTO.ImageSrc = String.Format("{0}://{1}{2}/Images/{3}", Scheme, Host, PathBase, imageDTO.ImagePath);
                    list.Add(productDTO);
                    

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

        #region(Get ProductList)
        /// <summary>  
        /// Gets all data  
        /// </summary>  
        /// <returns>collection of products.</returns> 
        public ApiResponse<List<ProductListDTO>> Get()
        {
            ApiResponse<List<ProductListDTO>> response = new ApiResponse<List<ProductListDTO>>();
            var list = new List<ProductListDTO>();
            var data = _adminDbContext.Product.Where(e => e.Status == 0).Include(x => x.SubCategoryModel).Include(y => y.BrandModel).Include(b => b.SubCategoryModel.CategoryModel).ToList();
            if (data != null && data.Count > 0)
            {
                foreach (var content in data)
                {

                    ProductListDTO productListDTO = new ProductListDTO();
                    productListDTO.ProductId = content.ProductId;
                    productListDTO.ProductName = content.ProductName;
                    productListDTO.Price = content.Price;
                    productListDTO.Quantity = content.Quantity;
                    productListDTO.Description = content.Description;

                    //add ternary operator here
                    productListDTO.SubCategoryId = content.SubCategoryModel.SubCategoryId;
                    productListDTO.CategoryId = content.SubCategoryModel.CategoryModel.CategoryId;
                    productListDTO.BrandId = content.BrandModel.BrandId;

                    list.Add(productListDTO);
                }
                response.Message = "Product Listed";
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


        #region(get ProductName By Name)
        /// <summary>  
        ///  Get Product by name  
        /// </summary>  
        /// <param Display product exist if it is product existing otherwise Product doesnt exists </param> 
        public ApiResponse<bool> GetByProductName(string Name)
        {
            var entity = _adminDbContext.Product.FirstOrDefault(e => e.ProductName == Name);
            ApiResponse<bool> response = new ApiResponse<bool>();

            if (entity != null)
            {
                if (entity.Status == 0)
                {
                    response.Success = true;
                    response.Message = "Product exists";
                    response.Data = true;
                    return response;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Product doesnt exists";
                    response.Data = false;
                    return response;
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Product doesnt exists";
                return response;
            }

        }
        #endregion

        #region(POST)
        public async Task<ApiResponse<bool>> Post(ProductDTO product)
        {
            ApiResponse<bool> Response = new ApiResponse<bool>();
            var productId = 0;
            ProductModel productModel = new ProductModel();
            
            productModel = _mapper.Map<ProductDTO, ProductModel>(product);
            
            try
            {
                var subCategoryId = _adminDbContext.SubCategory.Where(x => x.SubCategoryId == product.SubCategoryId && x.Status == 0).Select(x => x.SubCategoryId).FirstOrDefault();
                var BrandId = _adminDbContext.Brand.Where(x => x.BrandId == product.BrandId && x.Status == 0).Select(x => x.BrandId).FirstOrDefault();
                _adminDbContext.Product.Add(productModel);
                productId = productModel.ProductId;
                _adminDbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                Response.Success = false;
                Response.Message = "catogery or subcatogery not added";
                Response.Data = false;
                return Response;
            }
            ImageModel imageModel = new ImageModel();
            try
            {
                for (var i = 1; i <= product.productImage.Count; i++)
                {
                    imageModel.ProductId = productId;
                    imageModel.ImageName = "Image" + i;
                    imageModel.Priority = i;
                    imageModel.ImagePath = await SaveLogo(product.productImage[i - 1]);
                    _adminDbContext.Image.Add(imageModel);
                    _adminDbContext.SaveChanges();

                }
            }
            catch(Exception ex)
            {
                Response.Success = false;
                Response.Message = "moonji makkale";
                Response.Data = false;
                return Response;
            }

            return null;
            //ApiResponse<bool> Response = new ApiResponse<bool>();

            //if (subCategoryId > 0)
            //{
            //    var productModel = new ProductModel()
            //    {
            //        ProductName = product.ProductName,
            //        Price = product.Price,
            //        Description = product.Description,
            //        Quantity = product.Quantity,
            //        SubCategoryId = subCategoryId,
            //        BrandId = BrandId,
            //        // productModel.Image = _mapper.Map<List<ImageModel>, List<ImageDTO>>(_adminDbContext.Image.Where(i => i.ProductId == content.ProductId).ToList());


            //};
            //    _adminDbContext.Product.Add(productModel);

            //    for (var i = 1; i <= product.productImage.Count; i++)
            //    {

            //        ProductImageRow[i].ImageName = await SaveLogo(product.productImage[i]);
            //        _adminDbContext.Image.Add(ProductImageRow[i]);
            //    }

            //    _adminDbContext.SaveChanges();

            //    Response.Success = true;
            //    Response.Message = "Product is added";
            //    Response.Data = true;
            //    return Response;
            //}
            //else
            //{
            //    Response.Success = false;
            //    Response.Message = "Product not added";
            //    Response.Data = false;
            //    return Response;
            //}
        }
        #endregion
        public async Task<string> SaveLogo(IFormFile image)
        {

            string imagePath = new String(Path.GetFileNameWithoutExtension(image.FileName).Take(10).ToArray()).Replace(' ', '-');
            imagePath = imagePath + DateTime.Now.ToString("yyyyMMddhhmmfff") + Path.GetExtension(image.FileName);
            var path = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imagePath);

            using (var filestream = new FileStream(path, FileMode.Create))
            {
                await image.CopyToAsync(filestream);
            }
            return imagePath;
        }



        public ApiResponse<bool> Update(int id, ProductDTO product)
        {
            throw new NotImplementedException();
        }
    }
}
