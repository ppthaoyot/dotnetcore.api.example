using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmileShop.API.Data;
using SmileShop.API.DTOs.Product;
using SmileShop.API.Models;
using SmileShop.API.Helpers;

namespace SmileShop.API.Services.Product
{
    public class ProductService : ServiceBase, IProductService
    {
        #region Constructor
        private readonly AppDBContext _dBContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _log;
        private readonly IHttpContextAccessor _httpContext;

        public ProductService(AppDBContext dBContext, IMapper mapper, ILogger<ProductService> log, IHttpContextAccessor httpContext) : base(dBContext, mapper, httpContext)
        {
            _dBContext = dBContext;
            _mapper = mapper;
            _log = log;
            _httpContext = httpContext;
        }
        #endregion
        public async Task<ServiceResponse<List<GetProductDto>>> GetAll()
        {
            try
            {
                _log.LogInformation("Start [GetAll] Process.");
                var product = await _dBContext.Products.Include(x => x.ProductGroup).Include(x => x.CreatedBy).Include(x => x.UpdatedBy).AsNoTracking().ToListAsync();

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
                var product = await _dBContext.Products.Include(x => x.ProductGroup).Include(x => x.CreatedBy).Include(x => x.UpdatedBy).FirstOrDefaultAsync(x => x.Id == productId);

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
                var addProduct = new Models.ProductModel.Product
                {
                    Name = newProduct.Name.Trim(),
                    Price = newProduct.Price,
                    Stock = newProduct.Stock,
                    ProductGroupId = newProduct.ProductGroupId,
                    CreatedById = Guid.Parse(GetUserId()),
                    CreatedDate = Now(),
                    UpdatedById = Guid.Parse(GetUserId()),
                    UpdatedDate = Now(),
                    isActive = true
                };

                _dBContext.Products.Add(addProduct);
                await _dBContext.SaveChangesAsync();
                _log.LogInformation("[Add] Success.");

                var getProduct = await _dBContext.Products
                                        .Include(x => x.ProductGroup)
                                        .Include(x => x.CreatedBy)
                                        .Include(x => x.UpdatedBy)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(x => x.Name == addProduct.Name);

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
        public async Task<ServiceResponse<GetProductDto>> Update(int productId, UpdateProductDto updateProduct)
        {
            try
            {
                _log.LogInformation("Start [Update] Process");
                var product = await _dBContext.Products
                                    .Include(x => x.ProductGroup)
                                    .Include(x => x.CreatedBy)
                                    .Include(x => x.UpdatedBy)
                                    .FirstOrDefaultAsync(x => x.Id == productId);

                _log.LogInformation("Check Product ID.");
                if (product is null)
                {
                    _log.LogInformation(String.Format("Product ID {0} not exists.", productId));
                    return ResponseResult.Failure<GetProductDto>("Not Found.");
                }

                _log.LogInformation("Check Product Name.");
                var duplicateName = await _dBContext.Products.FirstOrDefaultAsync(x => x.Name == updateProduct.Name && x.Id != productId);

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
                product.isActive = updateProduct.isActive;
                product.UpdatedById = Guid.Parse(GetUserId());
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
        public async Task<ServiceResponse<RemoveProductDto>> Remove(int productId)
        {
            try
            {
                _log.LogInformation("Start [Remove] Process");
                var product = await _dBContext.Products.FirstOrDefaultAsync(x => x.Id == productId);

                _log.LogInformation("Check Product ID.");
                if (product is null)
                {
                    _log.LogInformation(String.Format("Product ID {0} not exists.", productId));
                    return ResponseResult.Failure<RemoveProductDto>("Not Found.");
                }

                _log.LogInformation("Remove [isActive = false] Product.");
                product.isActive = false;

                _dBContext.Products.Update(product);
                await _dBContext.SaveChangesAsync();
                _log.LogInformation("[Remove] Success.");

                var dto = _mapper.Map<RemoveProductDto>(product);

                _log.LogInformation("End [Remove] process.");
                return ResponseResult.Success(dto, "Remove Success (isActive:false)");

            }
            catch (System.Exception ex)
            {
                _log.LogError(ex.Message);
                return ResponseResult.Failure<RemoveProductDto>(ex.Message);
            }
        }
        public async Task<ServiceResponseWithPagination<List<GetProductDto>>> Filter(FilterProduct filter)
        {
            try
            {
                _log.LogInformation("Start [Filter] Process.");
                var queryable = _dBContext.Products.Include(x => x.CreatedBy).Include(x => x.UpdatedBy).Include(x => x.ProductGroup).AsQueryable();

                _log.LogInformation($"[Filter] Name : {filter.Name}");
                //Filter
                if (!string.IsNullOrWhiteSpace(filter.Name))
                {
                    queryable = queryable.Where(x => x.Name.Contains(filter.Name));
                }

                _log.LogInformation($"[Filter] Ordering");
                //Ordering
                if (!string.IsNullOrWhiteSpace(filter.OrderingField))
                {
                    try
                    {
                        _log.LogInformation($"[Filter] Ordering by Field {filter.OrderingField} {(filter.AscendingOrder ? "asc" : "desc")}");
                        queryable = queryable.OrderBy($"{filter.OrderingField} {(filter.AscendingOrder ? "asc" : "desc")}");
                    }
                    catch (System.Exception ex)
                    {
                        _log.LogError($"[Filter] Ordering Fail :{ex.Message}");
                        return ResponseResultWithPagination.Failure<List<GetProductDto>>(string.Format("Could not order by field : {0}", filter.OrderingField));
                    }
                }
                else
                {
                    _log.LogInformation($"[Filter] Ordering by Default : Id");
                    queryable = queryable.OrderBy(x => x.Id);
                }

                _log.LogInformation($"[Filter] Insert Pagination Parameters InResponse");
                var paginationResult = await _httpContext.HttpContext.InsertPaginationParametersInResponse(queryable, filter.RecordsPerPage, filter.Page);

                _log.LogInformation($"[Filter] Result Paginate");
                var lstFilter = await queryable.Paginate(filter).ToListAsync();

                _log.LogInformation($"[Filter] Map Data");
                var dto = _mapper.Map<List<GetProductDto>>(lstFilter);

                _log.LogInformation($"[Filter] Success.");
                _log.LogInformation($"End [Filter] Process.");
                return ResponseResultWithPagination.Success(dto, paginationResult);
            }
            catch (System.Exception ex)
            {
                _log.LogError(ex.Message);
                return ResponseResultWithPagination.Failure<List<GetProductDto>>(ex.Message);
            }
        }


    }

}