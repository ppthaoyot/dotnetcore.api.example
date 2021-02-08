using AutoMapper;
using SmileShop.API.DTOs;
using SmileShop.API.DTOs.Product;
using SmileShop.API.DTOs.ProductGroup;
using SmileShop.API.Models;
using SmileShop.API.Models.Product;
using SmileShop.API.Models.ProductGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            CreateMap<ProductGroup, GetProductGroupDto>();
        }
    }
}