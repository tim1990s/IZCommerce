using AutoMapper;
using IZCommerce.Core.Models;
using IZCommerce.Infrastructure.DTO.Product;
using IZCommerce.Infrastructure.ModelBinders;
using IZCommerce.Infrastructure.Repositories.Interfaces;
using IZCommerce.Logging.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IZCommerce.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public ProductsController(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet(Name = "GetProducts")]
        public async Task<IActionResult> GetProductsAsync()
        {
            var products = await _repository.Product.GetAllProductsAsync(trackChanges: false);
            var productsDto = _mapper.Map<IEnumerable<Product>>(products);
            return Ok(productsDto);
        }

        [HttpGet("{productId}", Name = "ProductById")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            var product = await _repository.Product.GetProductAsync(productId, trackChanges: false);
            if (product == null)
            {
                _logger.LogInfo($"Product with ProductId: {productId} doesn't exist in the database.");
                return NotFound();
            }

            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpPost(Name = "CreateProduct")]
        public async Task<IActionResult> CreateCompany([FromBody] ProductForCreationDto product)
        {
            var productEntity = _mapper.Map<Product>(product);
            _repository.Product.CreateProduct(productEntity);
            await _repository.SaveAsync();

            var productToReturn = _mapper.Map<ProductDto>(productEntity);
            return CreatedAtRoute("ProductById", new { productId = productToReturn.ProductId }, productToReturn);
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, [FromBody] ProductForUpdateDto product)
        {
            if (product == null)
            {
                _logger.LogError("Product For Update object sent from client is null.");
                return BadRequest("Product For Update object sent from client is null.");
            }

            var productEntity = await _repository.Product.GetProductAsync(productId, trackChanges: true);
            if (productEntity == null)
            {
                _logger.LogError($"Product with ProductId {productId} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(product, productEntity);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var product = await _repository.Product.GetProductAsync(productId, trackChanges: false);
            if(product == null)
            {
                _logger.LogError($"Product with ProductId {productId} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Product.DeleteProduct(product);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpGet("collection/{ids}", Name ="ProductCollection")]
        public async Task<IActionResult> GetProductCollection([ModelBinder(BinderType =typeof(ArrayModelBinder))] IEnumerable<int> ids)
        { 
            if(ids == null)
            {
                _logger.LogError("Parameter ids is null.");
                return BadRequest("Parameter ids is null.");
            }

            var productEntities = await _repository.Product.GetByIdsAsync(ids, trackChanges:false);
            if(ids.Count() != productEntities.Count())
            {
                _logger.LogInfo("Some ids are not valid in a collection.");
                return NotFound();
            }

            var productsToReturn = _mapper.Map<IEnumerable<ProductDto>>(productEntities);
            return Ok(productsToReturn);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateProductCollection([FromBody] IEnumerable<ProductForCreationDto> productCollection)
        {
            if (productCollection == null)
            {
                _logger.LogError("Product collection sent from client is null");
                return BadRequest("Product collection is null");
            }

            var productEntities = _mapper.Map<IEnumerable<Product>>(productCollection);
            foreach (var product in productEntities)
            {
                _repository.Product.CreateProduct(product);
            }

            await _repository.SaveAsync();

            var productCollectionToReturn = _mapper.Map<IEnumerable<ProductDto>>(productEntities);
            var ids = string.Join(",", productCollectionToReturn.Select(c => c.ProductId));

            return CreatedAtRoute("ProductCollection", new {ids}, productCollectionToReturn);
        }
    }
}
