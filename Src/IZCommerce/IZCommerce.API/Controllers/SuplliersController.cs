using AutoMapper;
using IZCommerce.Core.Models;
using IZCommerce.Infrastructure.DTO.Supplier;
using IZCommerce.Infrastructure.ModelBinders;
using IZCommerce.Infrastructure.Repositories.Interfaces;
using IZCommerce.Logging.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IZCommerce.API.Controllers
{
    [Route("api/suppliers")]
    [ApiController]
    public class SuplliersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public SuplliersController(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet(Name = "GetSuppliers")]
        public async Task<IActionResult> GetProductsAsync()
        {
            var suppliers = await _repository.Supplier.GetAllSuppliersAsync(trackChanges: false);
            var suppliersDto = _mapper.Map<IEnumerable<Supplier>>(suppliers);
            return Ok(suppliersDto);
        }


        [HttpGet("{supplierId}", Name = "SupplierById")]
        public async Task<IActionResult> GetSupplier(int supplierId)
        {
            var supplier = await _repository.Supplier.GetSupplierAsync(supplierId, trackChanges: false);
            if (supplier == null)
            {
                _logger.LogInfo($"Supplier with SupplierId: {supplierId} doesn't exist in the database.");
                return NotFound();
            }

            var supplierDto = _mapper.Map<SupplierDto>(supplier);
            return Ok(supplierDto);
        }

        [HttpPost(Name = "CreateSupplier")]
        public async Task<IActionResult> CreateSupplier([FromBody] SupplierForCreationDto product)
        {
            var supplierEntity = _mapper.Map<Supplier>(product);
            _repository.Supplier.CreateSupplier(supplierEntity);
            await _repository.SaveAsync();

            var supplierToReturn = _mapper.Map<SupplierDto>(supplierEntity);
            return CreatedAtRoute("SupplierById", new { supplierId = supplierToReturn.SupplierId }, supplierToReturn);
        }

        [HttpPut("{supplierId}")]
        public async Task<IActionResult> UpdateSupplier(int supplierId, [FromBody] SupplierForUpdateDto supplier)
        {
            if (supplier == null)
            {
                _logger.LogError("Supplier For Update object sent from client is null.");
                return BadRequest("Supplier For Update object sent from client is null.");
            }

            var supplierEntity = await _repository.Supplier.GetSupplierAsync(supplierId, trackChanges: true);
            if (supplierEntity == null)
            {
                _logger.LogError($"Supplier with SupplilerId {supplierId} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(supplier, supplierEntity);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{supplierId}")]
        public async Task<IActionResult> DeleteSupplier(int supplierId)
        {
            var suppliler = await _repository.Supplier.GetSupplierAsync(supplierId, trackChanges: false);
            if (suppliler == null)
            {
                _logger.LogError($"Supplier with SupplierId {supplierId} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Supplier.DeleteSupplier(suppliler);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpGet("collection/{ids}", Name = "SupplierCollection")]
        public async Task<IActionResult> GetSupplierCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> ids)
        {
            if (ids == null)
            {
                _logger.LogError("Parameter ids is null.");
                return BadRequest("Parameter ids is null.");
            }

            var supplierEntities = await _repository.Supplier.GetByIdsAsync(ids, trackChanges: false);
            if (ids.Count() != supplierEntities.Count())
            {
                _logger.LogInfo("Some ids are not valid in a collection.");
                return NotFound();
            }

            var suppliersToReturn = _mapper.Map<IEnumerable<SupplierDto>>(supplierEntities);
            return Ok(suppliersToReturn);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateSupplierCollection([FromBody] IEnumerable<SupplierForCreationDto> supplierCollection)
        {
            if (supplierCollection == null)
            {
                _logger.LogError("Supplier collection sent from client is null");
                return BadRequest("Supplier collection is null");
            }

            var supplierEntities = _mapper.Map<IEnumerable<Supplier>>(supplierCollection);
            foreach (var supplier in supplierEntities)
            {
                _repository.Supplier.CreateSupplier(supplier);
            }

            await _repository.SaveAsync();

            var supplierCollectionToReturn = _mapper.Map<IEnumerable<SupplierDto>>(supplierEntities);
            var ids = string.Join(",", supplierCollectionToReturn.Select(s => s.SupplierId));

            return CreatedAtRoute("SupplierCollection", new { ids }, supplierCollectionToReturn);
        }
    }
}
