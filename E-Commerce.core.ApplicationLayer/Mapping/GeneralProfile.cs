﻿using AutoMapper;
using E_Commerce.core.DomainLayer.Entities;
using E_Commerce.core.ApplicationLayer.DTOModel.Brand;
using E_Commerce.core.ApplicationLayer.DTOModel.Login;
using E_Commerce.core.ApplicationLayer.DTOModel.SubCategory;
using E_Commerce.core.ApplicationLayer.DTOModel.Product;
using E_Commerce.core.ApplicationLayer.DTOModel.Order;
using E_Commerce.core.ApplicationLayer.DTOModel.Customer;
using E_Commerce.core.ApplicationLayer.DTOModel.Image;

namespace E_Commerce.core.ApplicationLayer.DTOModel.Helpers
{
    public class GeneralProfile:Profile
    {
        public GeneralProfile()
        {
            CreateMap<LoginModel, LoginDTO>().ReverseMap();

            CreateMap<BrandModel, BrandDTO>().ReverseMap();

            CreateMap<CategoryModel, CategoryDTO>().ReverseMap();   

            CreateMap<SubCategoryModel, SubCategoryDTO>().ReverseMap();

            CreateMap<ProductModel, ProductDTO>().ReverseMap();

            CreateMap<OrderModel, OrderDTO>().ReverseMap();

            CreateMap<CustomerModel, CustomerDTO>().ReverseMap();

            CreateMap<ImageModel, ImageDTO>().ReverseMap();

        }
    }
}