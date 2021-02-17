using AutoMapper;
using SmileShop.API.DTOs;
using SmileShop.API.DTOs.Product;
using SmileShop.API.DTOs.ProductGroup;
using SmileShop.API.Models;
using SmileShop.API.Models.ProductModel;
using SmileShop.API.Models.ProductGroupModel;

namespace SmileShop.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Role, RoleDto>()
                .ForMember(x => x.RoleName, x => x.MapFrom(x => x.Name));
            CreateMap<RoleDtoAdd, Role>()
                .ForMember(x => x.Name, x => x.MapFrom(x => x.RoleName)); ;
            CreateMap<UserRole, UserRoleDto>();

            CreateMap<Product, GetProductDto>();
            CreateMap<Product, GetProductNameDto>();
            CreateMap<Product, RemoveProductDto>();
            CreateMap<ProductGroup, GetProductGroupDto>();
            CreateMap<ProductGroup, GetProductGroupNameDto>();
            CreateMap<ProductGroup, GetProductGroupFilterDto>();
            CreateMap<ProductGroup, RemoveProductGroupDto>();
        }
    }
}