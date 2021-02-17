using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmileShop.API.Data;
using SmileShop.API.DTOs.ProductGroup;
using SmileShop.API.Models;
using System.Linq.Dynamic.Core;
using SmileShop.API.Helpers;
using SmileShop.API.Models.ProductGroupModel;

namespace SmileShop.API.Services.ProductGroup
{
    public class ProductGroupService : ServiceBase, IProductGroupService
    {
        #region Constructor
        private readonly AppDBContext _dBContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductGroupService> _log;
        private readonly IHttpContextAccessor _httpContext;

        public ProductGroupService(AppDBContext dBContext, IMapper mapper, ILogger<ProductGroupService> log, IHttpContextAccessor httpContext) : base(dBContext, mapper, httpContext)
        {
            _dBContext = dBContext;
            _mapper = mapper;
            _log = log;
            _httpContext = httpContext;
        }

        #endregion

        public async Task<ServiceResponse<List<GetProductGroupDto>>> GetAll()
        {
            try
            {
                _log.LogInformation("Start [GetAll] Process.");
                var productGroup = await _dBContext.ProductGroups
                .Include(x => x.Products).ThenInclude(x => x.CreatedBy)
                .Include(x => x.Products).ThenInclude(x => x.UpdatedBy)
                .Include(x => x.CreatedBy)
                .Include(x => x.UpdatedBy)
                .AsNoTracking().ToListAsync();

                _log.LogInformation("[GetAll] Success.");
                var dto = _mapper.Map<List<GetProductGroupDto>>(productGroup);

                _log.LogInformation("End [GetAll] Process.");
                return ResponseResult.Success(dto);
            }
            catch (System.Exception ex)
            {
                _log.LogError(ex.Message);
                return ResponseResult.Failure<List<GetProductGroupDto>>(ex.Message);
            }
        }
        public async Task<ServiceResponse<GetProductGroupDto>> GetById(int productGroupId)
        {
            try
            {
                _log.LogInformation("Start [GetById] Process");
                var productGroup = await _dBContext.ProductGroups.Include(x => x.Products).Include(x => x.CreatedBy).Include(x => x.UpdatedBy).FirstOrDefaultAsync(x => x.Id == productGroupId);

                if (productGroup is null)
                {
                    _log.LogInformation(String.Format("Product Group ID {0} not exists.", productGroupId));
                    return ResponseResult.Failure<GetProductGroupDto>("Not Found.");
                }

                _log.LogInformation("[GetById] Success");
                var dto = _mapper.Map<GetProductGroupDto>(productGroup);

                _log.LogInformation("End [GetById] Process.");
                return ResponseResult.Success(dto);

            }
            catch (System.Exception ex)
            {

                _log.LogError(ex.Message);
                return ResponseResult.Failure<GetProductGroupDto>(ex.Message);
            }
        }
        public async Task<ServiceResponse<GetProductGroupDto>> Add(AddProductGroupDto newProductGroup)
        {
            try
            {
                _log.LogInformation("Start [Add] Process");
                var productGroup = await _dBContext.ProductGroups.Include(x => x.CreatedBy).FirstOrDefaultAsync(x => x.Name == newProductGroup.Name.Trim());

                if (!(productGroup is null))
                {
                    var msg = $"Duplicate name exists.";
                    _log.LogError(msg);
                    return ResponseResult.Failure<GetProductGroupDto>(msg);
                }

                _log.LogInformation("Add New Product Group.");
                var addProductGroup = new Models.ProductGroupModel.ProductGroup
                {
                    Name = newProductGroup.Name.Trim(),
                    CreatedById = Guid.Parse(GetUserId()),
                    CreatedDate = Now(),
                    UpdatedById = Guid.Parse(GetUserId()),
                    UpdatedDate = Now(),
                    isActive = true
                };

                _dBContext.ProductGroups.Add(addProductGroup);
                await _dBContext.SaveChangesAsync();
                _log.LogInformation("[Add] Success.");

                var getProductGroup = await _dBContext.ProductGroups.Include(x => x.Products).AsNoTracking().FirstOrDefaultAsync(x => x.Name == addProductGroup.Name);

                var dto = _mapper.Map<GetProductGroupDto>(getProductGroup);

                _log.LogInformation("End [Add] process.");
                return ResponseResult.Success(dto);

            }
            catch (System.Exception ex)
            {
                _log.LogError(ex.Message);
                return ResponseResult.Failure<GetProductGroupDto>(ex.Message);
            }
        }
        public async Task<ServiceResponse<GetProductGroupDto>> Update(int productGroupId, UpdateProductGroupDto updateProductGroup)
        {
            try
            {
                _log.LogInformation("Start [Update] Process");
                var productGroup = await _dBContext.ProductGroups.Include(x => x.UpdatedBy).FirstOrDefaultAsync(x => x.Id == productGroupId);

                _log.LogInformation("Check Product Group ID.");
                if (productGroup is null)
                {
                    _log.LogInformation(String.Format("Product Group ID {0} not exists.", productGroupId));
                    return ResponseResult.Failure<GetProductGroupDto>("Not Found.");
                }

                _log.LogInformation("Check Product Group Name.");
                var duplicateName = await _dBContext.ProductGroups.FirstOrDefaultAsync(x => x.Name == updateProductGroup.Name && x.Id != productGroupId);
                if (!(duplicateName is null))
                {
                    var msg = $"Duplicate name exists.";
                    _log.LogError(msg);
                    return ResponseResult.Failure<GetProductGroupDto>(msg);
                }

                _log.LogInformation("Update Product Group.");

                productGroup.Name = updateProductGroup.Name.Trim();
                productGroup.isActive = updateProductGroup.isActive;
                productGroup.UpdatedById = Guid.Parse(GetUserId());
                productGroup.UpdatedDate = Now();



                _dBContext.ProductGroups.Update(productGroup);
                await _dBContext.SaveChangesAsync();
                _log.LogInformation("[Update] Success.");

                var dto = _mapper.Map<GetProductGroupDto>(productGroup);

                _log.LogInformation("End [Update] process.");
                return ResponseResult.Success(dto);

            }
            catch (System.Exception ex)
            {
                _log.LogError(ex.Message);
                return ResponseResult.Failure<GetProductGroupDto>(ex.Message);
            }
        }
        public async Task<ServiceResponse<RemoveProductGroupDto>> Remove(int productGroupId)
        {
            try
            {
                _log.LogInformation("Start [Remove] Process");
                var productGroup = await _dBContext.ProductGroups.Include(x => x.UpdatedBy).FirstOrDefaultAsync(x => x.Id == productGroupId);

                _log.LogInformation("Check Product Group ID.");
                if (productGroup is null)
                {
                    _log.LogInformation(String.Format("Product Group ID {0} not exists.", productGroupId));
                    return ResponseResult.Failure<RemoveProductGroupDto>("Not Found.");
                }

                _log.LogInformation("Remove [isActive = false] Product Group.");
                productGroup.isActive = false;

                _dBContext.ProductGroups.Update(productGroup);
                await _dBContext.SaveChangesAsync();
                _log.LogInformation("[Remove] Success.");

                var dto = _mapper.Map<RemoveProductGroupDto>(productGroup);

                _log.LogInformation("End [Remove] process.");
                return ResponseResult.Success(dto, "Remove Success (isActive:false)");

            }
            catch (System.Exception ex)
            {
                _log.LogError(ex.Message);
                return ResponseResult.Failure<RemoveProductGroupDto>(ex.Message);
            }
        }
        public async Task<ServiceResponseWithPagination<List<GetProductGroupFilterDto>>> Filter(FilterProductGroup filter)
        {
            try
            {
                _log.LogInformation("Start [Filter] Process.");
                var queryable = _dBContext.ProductGroups.Include(x => x.CreatedBy).Include(x => x.UpdatedBy).AsQueryable();

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
                        return ResponseResultWithPagination.Failure<List<GetProductGroupFilterDto>>(string.Format("Could not order by field : {0}", filter.OrderingField));
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
                var dto = _mapper.Map<List<GetProductGroupFilterDto>>(lstFilter);

                _log.LogInformation($"[Filter] Success.");
                _log.LogInformation($"End [Filter] Process.");
                return ResponseResultWithPagination.Success(dto, paginationResult);
            }
            catch (System.Exception ex)
            {
                _log.LogError(ex.Message);
                return ResponseResultWithPagination.Failure<List<GetProductGroupFilterDto>>(ex.Message);
            }
        }
    }
}