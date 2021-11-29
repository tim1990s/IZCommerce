using AutoMapper;
using IZCommerce.Core.Models;
using IZCommerce.Infrastructure.DTO.Category;
using IZCommerce.Infrastructure.ModelBinders;
using IZCommerce.Infrastructure.Repositories.Interfaces;
using IZCommerce.Logging.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IZCommerce.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public CategoriesController(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet(Name ="GetCategories")]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            var categories = await _repository.Category.GetAllCategoriesAsync(trackChanges:false);
            var categoriesDto = _mapper.Map<IEnumerable<Category>>(categories);

            return Ok(categoriesDto);
        }

        [HttpGet("{CategoryId}", Name = "CategoryById")]
        public async Task<IActionResult> GetCategory(int categoryId)
        {
            var category = await _repository.Category.GetCategoryAsync(categoryId, trackChanges: false);
            if (category == null)
            {
                _logger.LogInfo($"Category with CategoryId: {categoryId} doesn't exist in the database.");
                return NotFound();
            }

            var categoryDto = _mapper.Map<CategoryDto>(category);
            return Ok(categoryDto);
        }

        [HttpPost(Name = "CreateCategory")]
        public async Task<IActionResult> CreateCompany([FromBody] CategoryForCreationDto category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            _repository.Category.CreateCategory(categoryEntity);
            await _repository.SaveAsync();

            var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);
            return CreatedAtRoute("CategoryById", new { categoryId = categoryToReturn.CategoryId }, categoryToReturn);
        }

        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateCategory(int categoryId, [FromBody] CategoryForUpdateDto category)
        {
            if (category == null)
            {
                _logger.LogError("Category For Update object sent from client is null.");
                return BadRequest("Category For Update object sent from client is null.");
            }

            var categoryEntity = await _repository.Category.GetCategoryAsync(categoryId, trackChanges: true);
            if (categoryEntity == null)
            {
                _logger.LogError($"Category with ProductId {categoryId} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(category, categoryEntity);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var category = await _repository.Category.GetCategoryAsync(categoryId, trackChanges: false);
            if (category == null)
            {
                _logger.LogError($"Category with CategoryId {categoryId} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Category.DeleteCategory(category);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpGet("collection/{ids}", Name = "CategoryCollection")]
        public async Task<IActionResult> GetProductCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> ids)
        {
            if (ids == null)
            {
                _logger.LogError("Parameter ids is null.");
                return BadRequest("Parameter ids is null.");
            }

            var categoryEntities = await _repository.Category.GetByIdsAsync(ids, trackChanges: false);
            if (ids.Count() != categoryEntities.Count())
            {
                _logger.LogInfo("Some ids are not valid in a collection.");
                return NotFound();
            }

            var productsToReturn = _mapper.Map<IEnumerable<CategoryDto>>(categoryEntities);
            return Ok(productsToReturn);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateCategoryCollection([FromBody] IEnumerable<CategoryForCreationDto> categoryCollection)
        {
            if (categoryCollection == null)
            {
                _logger.LogError("Category collection sent from client is null");
                return BadRequest("Category collection is null");
            }

            var categoryEntities = _mapper.Map<IEnumerable<Category>>(categoryCollection);
            foreach (var category in categoryEntities)
            {
                _repository.Category.CreateCategory(category);
            }

            await _repository.SaveAsync();

            var categoryCollectionToReturn = _mapper.Map<IEnumerable<CategoryDto>>(categoryEntities);
            var ids = string.Join(",", categoryCollectionToReturn.Select(c => c.CategoryId));

            return CreatedAtRoute("CategoryCollection", new { ids }, categoryCollectionToReturn);
        }
    }
}
