using System.Collections.Generic;
using System.Threading.Tasks;
using SmileShop.API.DTOs.ProductGroup;
using SmileShop.API.Models;

namespace SmileShop.API.Services.ProductGroup
{
    public interface IProductGroupService
    {
        Task<ServiceResponse<List<GetProductGroupDto>>> GetAll();
        Task<ServiceResponse<GetProductGroupDto>> GetById(int productGroupId);
        Task<ServiceResponse<GetProductGroupDto>> Add(AddProductGroupDto newProductGroup);
        Task<ServiceResponse<GetProductGroupDto>> Update(UpdateProductGroupDto updateProductGroup);
        Task<ServiceResponse<GetProductGroupDto>> Remove(int productGroupId);
    }
}