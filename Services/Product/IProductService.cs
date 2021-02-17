using System.Collections.Generic;
using System.Threading.Tasks;
using SmileShop.API.DTOs.Product;
using SmileShop.API.Models;

namespace SmileShop.API.Services.Product
{
    public interface IProductService
    {
        Task<ServiceResponse<List<GetProductDto>>> GetAll();
        Task<ServiceResponse<GetProductDto>> GetById(int productId);
        Task<ServiceResponse<GetProductDto>> Add(AddProductDto newProduct);
        Task<ServiceResponse<GetProductDto>> Update(int productId, UpdateProductDto updateProduct);
        Task<ServiceResponse<RemoveProductDto>> Remove(int productId);
        Task<ServiceResponseWithPagination<List<GetProductDto>>> Filter(FilterProduct filter);
    }
}