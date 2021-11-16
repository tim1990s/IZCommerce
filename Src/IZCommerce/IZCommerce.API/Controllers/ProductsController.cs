using AutoMapper;
using IZCommerce.Core.Models;
using IZCommerce.Infrastructure.DTO.Product;
using IZCommerce.Infrastructure.Repositories.Interfaces;
using IZCommerce.Logging.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var products = await _repository.Product.GetAllProductsAsync(trackChanges: false);
            var productsDto = _mapper.Map<IEnumerable<Product>>(products);     
            return Ok(productsDto);
        }

        [HttpGet("{productId}", Name ="ProductById")]
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
    }
}
