using Application.ProductCategories;
using Application.Products;
using Application.Users;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.General
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterDto, User>();
            CreateMap<User, UserDto>();

            CreateMap<ProductCommandDto, Product>();

            CreateMap<Product, ProductQueryDto>()
                .ForMember(p => p.UpdatedBy, o => o.MapFrom(s => s.UpdatedBy.Name))
                .ForMember(p => p.CreatedBy, o => o.MapFrom(s => s.CreatedBy.Name))
                .ForMember(p => p.ProducerName, o => o.MapFrom(s => s.Producer.Name))
                .ForMember(p => p.CategoryName, o => o.MapFrom(s => s.Category.Name))
                .ForMember(p => p.CategoryId, o => o.MapFrom(s => s.Category.Id));

            CreateMap<ProductCategoryCommandDto, ProductCategory>();
            CreateMap<ProductCategory, ProductCategoryQueryDto>()
                .ForMember(p => p.UpdatedBy, o => o.MapFrom(s => s.UpdatedBy.Name))
                .ForMember(p => p.CreatedBy, o => o.MapFrom(s => s.CreatedBy.Name));

            CreateMap<ProductCategory, ProductCategoryDropdownItemDto>()
                .ForMember(pc => pc.Label, o => o.MapFrom(s => s.Name))
                .ForMember(pc => pc.Value, o => o.MapFrom(s => s.Id));
        }
    }
}
