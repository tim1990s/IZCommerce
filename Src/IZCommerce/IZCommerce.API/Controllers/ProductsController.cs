using AutoMapper;
using IZCommerce.Core.Models;
using IZCommerce.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
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

        public ProductsController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetProducts()
        {
            var products = await _repository.Product.GetAllProductsAsync(trackChanges: false);
            var productsDto = _mapper.Map<IEnumerable<Product>>(products);
            return Ok(productsDto);
        }
    }
}
