using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmileShop.API.Data;
using SmileShop.API.DTOs.Product;
using SmileShop.API.Models;

namespace SmileShop.API.Services.Product
{
    public class ProductService : ServiceBase, IProductService
    {
        #region Constructor
        private readonly AppDBContext _dBContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _log;
        public ProductService(AppDBContext dBContext, IMapper mapper, ILogger<ProductService> log, IHttpContextAccessor httpContext) : base(dBContext, mapper, httpContext)
        {
            _dBContext = dBContext;
            _mapper = mapper;
            _log = log;
        }
        #endregion
        public async Task<ServiceResponse<List<GetProductDto>>> GetAll()
        {
            try
            {
                _log.LogInformation("Start [GetAll] Process.");
                var product = await _dBContext.Products.Include(x => x.ProductGroup).AsNoTracking().ToListAsync();

                _log.LogInformation("[GetAll] Success.");
                var dto = _mapper.Map<List<GetProductDto>>(product);

                _log.LogInformation("End [GetAll] Process.");
                return ResponseResult.Success(dto);
            }
            catch (System.Exception ex)
            {
                _log.LogError(ex.Message);
                return ResponseResult.Failure<List<GetProductDto>>(ex.Message);
            }
        }
        public async Task<ServiceResponse<GetProductDto>> GetById(int productId)
        {
            try
            {
                _log.LogInformation("Start [GetById] Process");
                var product = await _dBContext.Products.Include(x => x.ProductGroup).FirstOrDefaultAsync(x => x.Id == productId);

                if (product is null)
                {
                    _log.LogInformation(String.Format("Product ID {0} not exists.", productId));
                    return ResponseResult.Failure<GetProductDto>("Not Found.");
                }

                _log.LogInformation("[GetById] Success");
                var dto = _mapper.Map<GetProductDto>(product);

                _log.LogInformation("End [GetById] Process.");
                return ResponseResult.Success(dto);

            }
            catch (System.Exception ex)
            {
                _log.LogError(ex.Message);
                return ResponseResult.Failure<GetProductDto>(ex.Message);
            }
        }
        public async Task<ServiceResponse<GetProductDto>> Add(AddProductDto newProduct)
        {
            try
            {
                _log.LogInformation("Start [Add] Process");
                var product = await _dBContext.Products.FirstOrDefaultAsync(x => x.Name == newProduct.Name.Trim());

                if (!(product is null))
                {
                    var msg = $"Duplicate name exists.";
                    _log.LogError(msg);
                    return ResponseResult.Failure<GetProductDto>(msg);
                }

                _log.LogInformation("Check ProductGroup.");
                var productGroup = await _dBContext.ProductGroups.FirstOrDefaultAsync(x => x.Id == newProduct.ProductGroupId);
                if (productGroup is null)
                {
                    var msg = $"Product Group not exists.";
                    _log.LogError(msg);
                    return ResponseResult.Failure<GetProductDto>(msg);
                }

                _log.LogInformation("Add New Product.");
                var addProduct = new Models.Product.Product
                {
                    Name = newProduct.Name.Trim(),
                    Price = newProduct.Price,
                    Stock = newProduct.Stock,
                    ProductGroupId = newProduct.ProductGroupId,
                    CreatedBy = GetUserId(),
                    CreatedDate = Now(),
                    UpdatedBy = GetUserId(),
                    UpdatedDate = Now(),
                    isActive = true
                };

                _dBContext.Products.Add(addProduct);
                await _dBContext.SaveChangesAsync();
                _log.LogInformation("[Add] Success.");

                var getProduct = await _dBContext.Products.Include(x => x.ProductGroup).AsNoTracking().FirstOrDefaultAsync(x => x.Name == addProduct.Name);

                var dto = _mapper.Map<GetProductDto>(getProduct);

                _log.LogInformation("End [Add] process.");
                return ResponseResult.Success(dto);

            }
            catch (System.Exception ex)
            {
                _log.LogError(ex.Message);
                return ResponseResult.Failure<GetProductDto>(ex.Message);
            }
        }
        public async Task<ServiceResponse<GetProductDto>> Update(UpdateProductDto updateProduct)
        {
            try
            {
                _log.LogInformation("Start [Update] Process");
                var product = await _dBContext.Products.FirstOrDefaultAsync(x => x.Id == updateProduct.Id);

                _log.LogInformation("Check Product ID.");
                if (product is null)
                {
                    _log.LogInformation(String.Format("Product ID {0} not exists.", updateProduct.Id));
                    return ResponseResult.Failure<GetProductDto>("Not Found.");
                }

                _log.LogInformation("Check Product Name.");
                var duplicateName = await _dBContext.Products.FirstOrDefaultAsync(x => x.Name == updateProduct.Name && x.Id != updateProduct.Id);

                if (!(duplicateName is null))
                {
                    var msg = $"Duplicate name exists.";
                    _log.LogError(msg);
                    return ResponseResult.Failure<GetProductDto>(msg);
                }

                _log.LogInformation("Check ProductGroup.");
                var productGroup = await _dBContext.ProductGroups.FirstOrDefaultAsync(x => x.Id == updateProduct.ProductGroupId);
                if (productGroup is null)
                {
                    var msg = $"Product Group not exists.";
                    _log.LogError(msg);
                    return ResponseResult.Failure<GetProductDto>(msg);
                }

                _log.LogInformation("Update Product Group.");

                product.Name = updateProduct.Name.Trim();
                product.Price = updateProduct.Price;
                product.Stock = updateProduct.Stock;
                product.ProductGroupId = updateProduct.ProductGroupId;
                product.UpdatedBy = GetUserId();
                product.UpdatedDate = Now();

                _dBContext.Products.Update(product);
                await _dBContext.SaveChangesAsync();
                _log.LogInformation("[Update] Success.");

                var dto = _mapper.Map<GetProductDto>(product);

                _log.LogInformation("End [Update] process.");
                return ResponseResult.Success(dto);

            }
            catch (System.Exception ex)
            {
                _log.LogError(ex.Message);
                return ResponseResult.Failure<GetProductDto>(ex.Message);
            }
        }
        public async Task<ServiceResponse<GetProductDto>> Remove(int productId)
        {
            try
            {
                _log.LogInformation("Start [Remove] Process");
                var product = await _dBContext.Products.FirstOrDefaultAsync(x => x.Id == productId);

                _log.LogInformation("Check Product ID.");
                if (product is null)
                {
                    _log.LogInformation(String.Format("Product ID {0} not exists.", productId));
                    return ResponseResult.Failure<GetProductDto>("Not Found.");
                }

                _log.LogInformation("Remove [isActive = false] Product.");
                product.isActive = false;

                _dBContext.Products.Update(product);
                await _dBContext.SaveChangesAsync();
                _log.LogInformation("[Remove] Success.");

                var dto = _mapper.Map<GetProductDto>(product);

                _log.LogInformation("End [Remove] process.");
                return ResponseResult.Success(dto, "Remove Success (isActive:false)");

            }
            catch (System.Exception ex)
            {
                _log.LogError(ex.Message);
                return ResponseResult.Failure<GetProductDto>(ex.Message);
            }
        }
    }

}